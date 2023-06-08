using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.BlazorApp.Models
{
    public class UserLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
