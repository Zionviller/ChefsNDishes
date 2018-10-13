using System;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Models
{
    public class Context : DbContext
    {
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        public Context(DbContextOptions<Context> options):base(options)
        {
        }
    }
}
