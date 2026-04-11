using ModelLayer.DTOs;
using ModelLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        Task<string> Login(UserLoginDto dto);
        Task<User> Register(UserRegisterDto dto);
    }
}
