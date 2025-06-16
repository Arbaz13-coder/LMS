using LMS.Data;
using LMS.DTOs;
using LMS.Models;
using System.Text;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;


namespace LMS.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        public AuthService(ApplicationDbContext context) { _context = context; }

        public User FindUserByUsernameOrEmail(string input)
        {
            return _context.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                .FirstOrDefault(u => u.Username == input || u.Email == input);
        }

        public (bool Success, User User) ValidatePassword(string usernameOrEmail, string password)
        {
            var user = FindUserByUsernameOrEmail(usernameOrEmail);
            if (user == null) return (false, null);
            var hash = HashPassword(password, user.PasswordSalt);
            return (hash == user.PasswordHash, user);
        }

        public (bool Success, string Message) RegisterUser(SignupDto dto)
        {
            if (_context.Users.Any(u => u.Username == dto.Username || u.Email == dto.Email))
                return (false, "User already exists.");

            var salt = Guid.NewGuid().ToString();
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordSalt = salt,
                PasswordHash = HashPassword(dto.Password, salt)
            };

            user.UserRoles = new List<UserRole>();
            foreach (var roleName in dto.Roles)
            {
                var role = _context.Roles.FirstOrDefault(r => r.RoleName == roleName);
                if (role == null) return (false, $"Role '{roleName}' not found.");
                user.UserRoles.Add(new UserRole { User = user, Role = role });
            }

            _context.Users.Add(user);
            _context.SaveChanges();
            return (true, "User created.");
        }

        private string HashPassword(string password, string salt) =>
            Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password + salt)));
    }
}
