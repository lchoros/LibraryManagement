using LibraryManagement.BlazorApp.Models;
using System.Text.Json;
using System.Text;
using LibraryManagement.BlazorApp.Services.Interfaces;

namespace LibraryManagement.BlazorApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<LoginResult> Login(UserLogin userLogin)
        {
            var content = new StringContent(JsonSerializer.Serialize(userLogin), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync("api/account/login", content);

            var loginResult = new LoginResult
            {
                Success = response.IsSuccessStatusCode,
                Message = response.IsSuccessStatusCode ? string.Empty : "Login failed, please try again."
            };

            return loginResult;
        }
    }
}
