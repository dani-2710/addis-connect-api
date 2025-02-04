using Domain.Constants;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public  string Email { get; set; } = null!;
        public  string PhoneNumber { get; set; } = null!;
        public  string Password { get; set; } = null!;
        public string? ProfileImage { get; set; }
        public string Status { get; set; } = UserStatus.Active;

        public virtual ICollection<UserRole> UserRoles { get; set; } = null!;  
        public virtual ICollection<UserToken> UserTokens { get; set; } = null!;  

    }
}
