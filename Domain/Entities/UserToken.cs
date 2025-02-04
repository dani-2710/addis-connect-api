namespace Domain.Entities
{
    public class UserToken : BaseEntity
    {
        public Guid Id { get; set; }
        public required string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;

    }
}
