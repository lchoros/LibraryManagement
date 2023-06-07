using Microsoft.AspNetCore.Identity;

namespace LibraryManagement.Data.Initialization
{
    public class ApplicationDbInitializer
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationDbInitializer(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            string[] roleNames = { "Standard", "Premium", "PremiumPlus" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}