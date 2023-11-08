using ApiStore.Data;
using System.ComponentModel.DataAnnotations;

namespace ApiStore.Modules.Orders
{
    public class CreateOrderItemDto : IValidatableObject
    {

        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public UnitMeasurement UnitMeasurement { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            return results;
        }
    }
}
