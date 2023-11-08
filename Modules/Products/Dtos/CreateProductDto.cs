using ApiStore.Data;
using System.ComponentModel.DataAnnotations;

namespace ApiStore.Modules.Products
{
    public class CreateProductDto : IValidatableObject
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { set; get; }
        public decimal Stock { set; get; }
        public string Description { set; get; } = string.Empty;
        public string Image { set; get; } = string.Empty;
        public int Igv { get; set; }
        public DateTime FechaCreacion { set; get; }
        public UnitMeasurement UnitMeasurement { set; get; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            return results;
        }
    }
}
