using Domain.Constants;

namespace Domain.Entities
{
    public class Organizer : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Status { get; set; } = UserStatus.Active;
        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
