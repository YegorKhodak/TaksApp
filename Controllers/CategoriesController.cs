using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task2.Models.ViewModels;

namespace Task2.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationContext _db;

        public CategoriesController(ApplicationContext db)
        {
            _db = db;
        }
        public IActionResult Index(int userId)
        {
            var categories = _db.Categories.ToList();

            var vm = new CategoriesViewModel()
            {
                Categories = categories,
                CurrentUserId = userId
            };

            return View(vm);
        }
    }
}