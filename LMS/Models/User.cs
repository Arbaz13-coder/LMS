namespace LMS.Models
{
    public class User
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
