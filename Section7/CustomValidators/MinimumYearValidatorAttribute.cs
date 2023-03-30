using System.ComponentModel.DataAnnotations;

namespace Section7.CustomValidators;
public class MinimumYearValidatorAttribute : ValidationAttribute
{
    public int MinimumYear { get; set; } 
    //parameterless constructor
    public MinimumYearValidatorAttribute()
    {

    }

    public MinimumYearValidatorAttribute(int minimumYear)
    {
        MinimumYear = minimumYear;
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null) 
        {
            DateTime date = (DateTime)value;
            if (date.Year >= MinimumYear)
            {
                return new ValidationResult(string.Format(ErrorMessage, MinimumYear));
            }
            return ValidationResult.Success;
        }
        return null;
    }
}

