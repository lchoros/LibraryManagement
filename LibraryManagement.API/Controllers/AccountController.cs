using AutoMapper;
using LibraryManagement.Core.DTOs;
using LibraryManagement.Core.Settings;
using LibraryManagement.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
        {
            if (ModelState.IsValid)
            {
                // Check if the email already exists
                var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
                if (existingUser != null)
                {
                    return Conflict(new { message = "Email already in use" });
                }

                var user = _mapper.Map<User>(registerDto);

                var result = await _userManager.CreateAsync(user, registerDto.Password);

                if (!result.Succeeded)
                {
                    return BadRequest(new { errors = result.Errors });
                }

                // Assign the role
                await _userManager.AddToRoleAsync(user, "Standard");

                // Generate email confirmation token
                var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                // Send the email to user. You could use services like SendGrid or other SMTP service

                // For simplicity, just return the token for manual confirmation
                return Ok(new { token = emailConfirmationToken, email = user.Email });
            }
            return BadRequest(new { message = "Invalid data" });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

                var token = new JwtSecurityToken(
                    issuer: "https://dotnettemplates.com",
                    audience: "https://dotnettemplates.com",
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
    }
}