using FinanceApp.Server.Models;

namespace FinanceApp.Server.Services
{
    public interface IAuthService
    {
        public Task<User> AuthenticateUser(string email, string password);
        public Task<User> AddUser(string email, string password);
        public Task SaveChangesToCredDb();
    }
}
