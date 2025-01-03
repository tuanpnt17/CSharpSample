using System.ComponentModel.DataAnnotations;

namespace xuanthulab.attribute
{
    public class MinAgeAttribute(int minAge) : ValidationAttribute
    {
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext
        )
        {
            if (value is not DateTime birthDate)
                return new ValidationResult("Invalid birth date");
            var age = DateTime.Today.Year - birthDate.Year;

            // adjust age if birthday has not occurred this year
            if (birthDate > DateTime.Today.AddYears(-age))
                age--;

            if (age >= minAge)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(
                    ErrorMessage ?? $"Age must be at least {minAge} years."
                );
            }
        }
    }
}
