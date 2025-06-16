using LMS.Models;

namespace LMS.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);

    }
}
