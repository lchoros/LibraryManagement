using LibraryManagement.Core.DTOs;
using AutoMapper;
using LibraryManagement.Data.Models;

namespace LibraryManagement.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}