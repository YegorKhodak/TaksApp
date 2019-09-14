using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task2.Models.ViewModels;

namespace Task2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationContext _db;

        public ProductsController(ApplicationContext db)
        {
            _db = db;
        }
        public IActionResult Index(int userId, int categoryId)
        {
            var products = _db.Products.Where(_ => _.CategoryId == categoryId).ToList();

            var vm = new ProductsViewModel()
            {
                Products = products,
                CurrentUserId = userId
            };

            return View(vm);
        }
    }
}