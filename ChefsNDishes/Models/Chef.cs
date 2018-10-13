using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }

        [Required(ErrorMessage = "You must enter a first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must enter a last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a date of birth.")]
        [DateValidation]
        public DateTime DateOfBirth { get; set; }

        public List<Dish> Dishes { get; set; }

        [NotMapped]
        public int Age {
            get {
                return (int) (DateTime.Now.Year - DateOfBirth.Year);
            }
        }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
