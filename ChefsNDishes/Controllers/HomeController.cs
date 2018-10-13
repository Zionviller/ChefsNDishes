using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;

        public HomeController(Context con)
        {
            _context = con;
        }

        [HttpGet]
        [Route("")]
        [Route("Chefs")]
        public ViewResult Chefs()
        {
            List<Chef> allChefs = _context.Chefs
                                          .Include(c => c.Dishes)
                                          .ToList<Chef>();
            return View(allChefs);
        }

        [HttpGet]
        [Route("AddChef")]
        public ViewResult AddChef()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            if (ModelState.IsValid)
            {
                // create new chef
                Chef newChef = new Chef
                {
                    FirstName = chef.FirstName,
                    LastName = chef.LastName,
                    DateOfBirth = chef.DateOfBirth,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.Chefs.Add(newChef);
                _context.SaveChanges();

                return RedirectToAction("Chefs");
            }

            return View("AddChef");
        }

        [HttpGet]
        [Route("Dishes")]
        public ViewResult Dishes()
        {
            List<Dish> dishes = _context.Dishes
                                        .Include(d => d.Creator)
                                        .ToList();
            return View(dishes);
        }

        [HttpGet]
        [Route("AddDish")]
        public ViewResult AddDish()
        {

            ViewData["AllChefs"] = _context.Chefs.ToList<Chef>();
            return View();
        }

        [HttpPost]
        public IActionResult CreateDish(Dish dish)
        {
            if(ModelState.IsValid)
            {
                dish.CreatedAt = DateTime.Now;
                dish.UpdatedAt = DateTime.Now;

                _context.Dishes.Add(dish);
                _context.SaveChanges();

                return RedirectToAction("Dishes");
            }
            Console.WriteLine($"\n\n**** MODEL NOT VALID");
            ViewData["AllChefs"] = _context.Chefs.ToList<Chef>();
            return View("AddDish");
        }

    }
}
