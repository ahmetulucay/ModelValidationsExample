using System.ComponentModel.DataAnnotations;

namespace Section7.CustomValidators;
public class MinimumYearValidatorAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        string ErrorMessage = "Minimum year allowed is 2000";
        if (value != null) 
        {
            DateTime date = (DateTime)value;
            if (date.Year >= 2000)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
        return null;
    }
}

