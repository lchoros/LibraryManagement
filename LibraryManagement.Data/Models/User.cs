using Microsoft.AspNetCore.Identity;

namespace LibraryManagement.Data.Models
{
    public class User : IdentityUser
    {
        // Add additional profile data for application users by adding properties to this class
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Maybe a Role string if you're not using Role Management
        public string Role { get; set; }
        public string Address { get; set; }
    }
}
