using System.ComponentModel.DataAnnotations;

namespace Section7.Models;
public class Person
{
    [Required(ErrorMessage ="{0} can not be empty or null.")]
    [Display (Name ="Person Name")]
    [StringLength (50, MinimumLength = 3, ErrorMessage ="{0} should be between {2} and " +
        "{1} characters long")]

    public string? PersonName { get; set; } /*= "Jack";*/
    public string? Email { get; set; } = "jack@jack.com";
    public string? Phone { get; set; } = "46-83-83-234";
    public string? Password { get; set; } = "0";
    public string? ConfirmPassword { get; set; } = "0";

    [Range (0,999.99, ErrorMessage = "{0} should be between ${1} and ${2}")]
    public double? Price { get; set; } = 22323232;
    public override string ToString()
    {
        return $"Person name: {PersonName}, \nEmail      : {Email}, \nPhone      : {Phone}, \n" +
          $"Password   : {Password}, \nConfirm Password: {ConfirmPassword}, \nPrice      : {Price}\n";
    }
}


