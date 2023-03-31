
using Section7.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace Section7.Models;
public class Person : IValidatableObject
{
    [Required(ErrorMessage ="{0} can not be empty or null.")]
    [Display (Name ="Person Name")]
    [StringLength (50, MinimumLength = 3, ErrorMessage ="{0} should be between {2} and " +
        "{1} characters long")]
    [RegularExpression("^[A-Za-z .]*$", ErrorMessage ="{0} should contain only alphabets," +
        "space and dot (.)")]
    public string? PersonName { get; set; } /*= "Jack";*/


    [EmailAddress(ErrorMessage = "{0} should be proper email address." )]
    [Required(ErrorMessage = "{0} can't be blank")]
    public string? Email { get; set; } = "jack@jack.com";


    [Phone(ErrorMessage ="{0} should contain 10 digits.")]
    //[ValidateNever]
    public string? Phone { get; set; } = "46-83-83-234";


    [Required(ErrorMessage ="{0} can't be blank")]
    public string? Password { get; set; } = "0";


    [Required(ErrorMessage = "{0} can't be blank")]
    [Compare("Password", ErrorMessage ="{0} and {1} do not match.")]
    [Display(Name = "Re-enter Password")]
    public string? ConfirmPassword { get; set; } = "0";


    [Range (0,999.99, ErrorMessage = "{0} should be between ${1} and ${2}")]
    public double? Price { get; set; } = 22323232;


    [MinimumYearValidator(2005, ErrorMessage ="Date of Birth should not be newer than Jan 01, {0}.")]
    //[BindNever]
    public DateTime? DateOfBirth { get; set; }

    public DateTime? FromDate { get; set; }

    [DateRangeValidator("FromDate", ErrorMessage="'From Date' should be older than or equal to 'To Date'.")]
    public DateTime? ToDate { get; set; }

    public int? Age { get; set; }

    public override string ToString()
    {
        return $"Person name: {PersonName}, \nEmail      : {Email}, \nPhone      : {Phone}, \n" +
          $"Password   : {Password}, \nConfirm Password: {ConfirmPassword}, \nPrice      : {Price}\n";
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (DateOfBirth.HasValue == false && Age.HasValue == false)
        {
            yield return new ValidationResult("Either of Date of Birth or Age" +
                " must be supplied", new[] {nameof(Age)}); 
        }

    }
}


