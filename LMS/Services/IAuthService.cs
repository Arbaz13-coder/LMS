using LMS.DTOs;
using LMS.Models;

namespace LMS.Services
{
    public interface IAuthService
    {
        User FindUserByUsernameOrEmail(string input);
        (bool Success, User User) ValidatePassword(string usernameOrEmail, string password);
        (bool Success, string Message) RegisterUser(SignupDto dto);
    }
}
