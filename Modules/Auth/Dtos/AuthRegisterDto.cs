using System.ComponentModel.DataAnnotations;

namespace ApiStore.Modules.Auth
{
    public class AuthRegisterDto : IValidatableObject
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Name))
            {
                results.Add(new ValidationResult("El nombre es obligatorio", new[] { nameof(Name) }));
            }

            if (string.IsNullOrEmpty(Email))
            {
                results.Add(new ValidationResult("El nombre es obligatorio", new[] { nameof(Email) }));
            }

            if (string.IsNullOrEmpty(Password))
            {
                results.Add(new ValidationResult("El nombre es obligatorio", new[] { nameof(Password) }));
            }

            return results;
        }
    }
}
