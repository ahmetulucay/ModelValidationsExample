
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Section7.CustomValidators;

public class DateRangeValidatorAttribute : ValidationAttribute
{
    public string _otherPropertyName;
    public DateRangeValidatorAttribute(string otherPropertyName) 
    { 
        _otherPropertyName = otherPropertyName;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null)
        {
            //get to_date
            DateTime to_date = Convert.ToDateTime(value);

            //get from_date
            PropertyInfo? otherProperty = 
                validationContext.ObjectType.GetProperty(_otherPropertyName);

            if (otherProperty != null)
            {
                DateTime from_date = Convert.ToDateTime
                    (otherProperty.GetValue(validationContext.ObjectInstance));

                if (from_date > to_date)
                {
                    return new ValidationResult(ErrorMessage, new string[]
                    {_otherPropertyName, validationContext.MemberName});
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
        return null;
    }
}
