using System.ComponentModel.DataAnnotations;

namespace ApiStore.Modules.Orders
{
    public class UpdateOrderDto: IValidatableObject
    {
        public bool? Pay { get; set; }
        public Guid CustomerId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            return results;
        }
    }
}
