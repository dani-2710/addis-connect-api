namespace Domain.Entities
{
    public class Role : BaseEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = null!;
    }
}
