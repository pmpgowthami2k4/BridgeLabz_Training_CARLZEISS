using ModelLayer.Entities;
using System.Threading.Tasks;

namespace DataBaseLayer.Interfaces
{
    public interface IUserDL
    {
        // Register user
        Task<User> CreateUser(User user);

        // Get user by email (used for login + validation)
        Task<User> GetUserByEmail(string email);
    }
}