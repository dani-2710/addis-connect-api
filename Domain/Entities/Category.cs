using Domain.Constants;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public string Status { get; set; } = CategoryStatus.Active;
    }
}
