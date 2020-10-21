using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController: Controller
    {
        [ViewData]
        public string customProperty { get; set; }
        [ViewData]
        public BookModel boookData { get; set; }
        public ViewResult Index()
        {
            boookData = new BookModel() { Id = 101, Title = "MVC Application", Author = "Sushmitha", Category = "Programming", Description = "Test Desc", Language = "English", TotalPages = 300 };
            customProperty = "Custom Value";
            //return View("../../TempView/SushTemp");
            ViewBag.Title1 = "Sushmitha";
            ViewBag.Desc = "WEB API";

            return View();
        }
        public ViewResult AboutUs()
        {
            ViewData.Add("Id", 1);
            ViewData.Add(new KeyValuePair<string, object>("Name", "Sushmitha Vanapalli"));
            ViewData.Add(new KeyValuePair<string, object>("Age", 24));
            ViewData.Add(new KeyValuePair<string, object>("Contact", 8097615423));
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
   }
}
