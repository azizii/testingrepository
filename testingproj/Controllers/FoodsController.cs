using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testingproj.Models;
using testingproj.ViewModel;

namespace testingproj.Controllers
{
    public class FoodsController : Controller
    {

        public readonly testingprojContext _Context;
        public IHostingEnvironment HostingEnvironment { get; }

        public FoodsController(testingprojContext context, IHostingEnvironment hostingEnvironment)
        {
            _Context = context;
            HostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateFood()
        {

          
          

      
            return View();
        }

        [HttpPost]
        public IActionResult CreateFood(Foodviewmode food)
        {
         
       
            if (ModelState.IsValid)
            {

                string uniqueFileName = Photopathfood(food);

                myfoods newfood = new myfoods
                {

                    myfoodsName = food.foodName,
                    foodCalories = food.foodCalories,
                    photopath = uniqueFileName,
                    Price = food.price,
                    photopath11="jjjjj"
                  

                };

                //if (Image != null)
                _Context.Add(newfood);







                _Context.SaveChanges();
                return RedirectToAction(nameof(FoodList));

            }
         
            return View(food);
        }
        public IActionResult FoodList()
        {
           
           
            var food = _Context.Myfoods.ToList();
            if (food.ToList().Count == 0)
            {
                return View("Empty");
            }
            return View(food);
        }
        public string Photopathfood(Foodviewmode food)
        {

            string uniqueFileName = null;
            string paths = null;
            if (food.photo != null)
            {
                string uploadFolder = Path.Combine(HostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + food.photo.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                food.photo.CopyTo(new FileStream(filePath, FileMode.Create));

            }
      ;
            return uniqueFileName;
        }

    }
}