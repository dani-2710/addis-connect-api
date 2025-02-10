namespace Domain.Entities
{
    public class Discount : BaseEntity
    {
        public Guid Id { get; set; }
        public string AmountType { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
