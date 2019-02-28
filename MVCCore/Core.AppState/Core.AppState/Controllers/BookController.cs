using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
    }
}