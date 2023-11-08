using System.ComponentModel.DataAnnotations;

namespace ApiStore.Modules.Categories;

public class UpdateCategoryDto
{
    [Required(AllowEmptyStrings = false)]
    public Guid Id { get; private set; }

    [MinLength(4, ErrorMessage = "El campo name debe tener al menos 4 caracteres")]
    [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "El campo Name debe contener solo letras.")]
    public string? Name { get; set; }

    [MinLength(4, ErrorMessage = "El campo name debe tener al menos 4 caracteres")]
    public string? Description { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();
        return results;
    }
}
