using System.ComponentModel.DataAnnotations;


namespace ApiStore.Modules.Orders
{
    public class CreateFullOrderDto :IValidatableObject
    {
        [Required]
        public bool Pay { get; set; }
        public decimal TotalAmount { get; set; }

        public DateTime OrderDate { get; set; }
        public Guid UserId { get; set; }
        public Guid CashDrawerId { get; set; }
        public Guid CustomerId { get; set; }

        [Required]
        public ICollection<CreateOrderItemDto> CreateOrderItems { get; set; } = new List<CreateOrderItemDto>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (TotalAmount <= 0)
            {
                results.Add(new ValidationResult("El campo TotalAmount debe ser mayor que 0.", new[] { nameof(TotalAmount) }));
            }

            if (CreateOrderItems == null || CreateOrderItems.Count == 0)
            {
                results.Add(new ValidationResult("Debe proporcionar al menos un artículo en CreateOrderItems.", new[] { nameof(CreateOrderItems) }));
            }

            return results;
        }
    }
}
