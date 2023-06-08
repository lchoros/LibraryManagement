using LibraryManagement.BlazorApp.Models;

namespace LibraryManagement.BlazorApp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResult> Login(UserLogin userLogin);
    }
}
