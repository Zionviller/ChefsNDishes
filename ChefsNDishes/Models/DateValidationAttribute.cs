using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class DateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime v = (DateTime) value;
            Console.WriteLine($"\n\nTHE VALUE: {v}");

            if((DateTime.Now.Year - v.Year) < 18)
            {
                return new ValidationResult("You must be 18 or older to be a Chef. It's the LAW!");
            }

            if( (DateTime) value  > DateTime.Now )
            {
                return new ValidationResult("Date of birth is invalid.");
            }
            return ValidationResult.Success;
        }
    }
}
