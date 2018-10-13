using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required(ErrorMessage = "What's the dish called, though?")]
        [MaxLength(32, ErrorMessage = "Name cannot be longer than 32 characters.")]
        public string Name { get; set; }


        public int ChefId { get; set; }
        [ForeignKey("ChefId")]
        public Chef Creator { get; set; }

        //[Required(ErrorMessage = "Who's the chef, though?")]
        //[MaxLength(32, ErrorMessage = "Name cannot be longer than 32 characters.")]
        //public string Chef { get; set; }

        [Required(ErrorMessage = "How tasty is it, though?")]
        [Range(1,5, ErrorMessage = "Must be rated from 1 to 5.")]
        public int Tastiness { get; set; }

        [Required(ErrorMessage = "How many calories, though?")]
        [Range(1,Int32.MaxValue, ErrorMessage = "That looks wrong..")]
        public int Calories { get; set; }

        [Required(ErrorMessage = "You must enter a description.")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Dish()
        {
        }
    }
}
