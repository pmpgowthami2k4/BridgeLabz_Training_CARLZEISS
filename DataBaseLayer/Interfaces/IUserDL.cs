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

        Task<bool> UpdatePassword(int userId, string newPassword); //for ssms
        //Task<bool> UpdatePassword(string userId, string newPassword); //for mongodb
        
    }
}