using FinanceApp.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly CredentialsDbContext _context;

        public AuthService(CredentialsDbContext context)
        {
            _context = context;
        }
        private static string CreateHash(string email, string password)
        {
            var hasher = new PasswordHasher<string>();
            var hash = hasher.HashPassword(email, password);
            return hash;
        }
        private IQueryable<UserCredentials> GetUserCredentials(string email)
        {
            return _context.UsersCredentials.Where(e => e.Email == email);
        }
        public async Task<User> AddUser(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                    return null;
                if ((await GetUserCredentials(email).FirstOrDefaultAsync()) != null)
                    return null;
                await _context.AddAsync(new UserCredentials
                {
                    Email = email,
                    Password = CreateHash(email, password)
                });
                return new User(email);
            }
            catch
            {
                return null;
            }
        }

        public async Task<User> AuthenticateUser(string email, string password)
        {
            var hasher = new PasswordHasher<string>();
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;
            if ((await GetUserCredentials(email).FirstOrDefaultAsync()) == null)
                return null;
            if (hasher.VerifyHashedPassword(email, (await GetUserCredentials(email).FirstOrDefaultAsync()).Password, password).ToString() == "Failed")
                return null;
            return new User(email);
        }

        public async Task SaveChangesToCredDb()
        {
            await _context.SaveChangesAsync();
        }
    }
}
