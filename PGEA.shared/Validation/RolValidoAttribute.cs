using System;
using System.ComponentModel.DataAnnotations;

namespace PGEA.shared.Validation
{
    public class RolValidoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
                                                    ValidationContext validationContext)
        {
            var allowedRoles = new[] { "ponente", "asistente" };
            var inputValue = value as string;

            if (string.IsNullOrWhiteSpace(inputValue) || !allowedRoles.Contains(inputValue.ToLower()))
            {
                return new ValidationResult("El campo 'Rol' debe ser 'ponente' o 'asistente'.");
            }

            return ValidationResult.Success;
        }
    }
}

