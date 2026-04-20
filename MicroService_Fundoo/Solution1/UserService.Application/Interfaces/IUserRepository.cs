using UserService.Domain.Entities;

namespace UserService.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<string> AddAsync(User user);
}