using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.AppState.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.AppState.Views
{
    public class BookController : Controller
    {
        public IActionResult Create()
        {
           


            TempData["StatusMessage"] = "Create book successfully";

            return View();
        }
        public IActionResult Index()
        {
            ViewData["Gree"] = "Hello I am ViewData ";
            ViewData["Address"] = new Address()
            {
                name = "Nam",
                city = "HaNoi",
            };

            ViewBag.Greeting = "Hello I am ViewBag ";
            ViewBag.Address = new Address()
            {
                name = "Nam",
                city = "HaNoi",
            };
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
    }
}