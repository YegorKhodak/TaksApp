using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2.Models.Entities;
using Task2.Models.ViewModels;

namespace Task2.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationContext _db;

        public OrdersController(ApplicationContext db)
        {
            _db = db;
        }
        public IActionResult CreateOrder(int userId, int productId)
        {
            var newOrder = new Order();

            newOrder.UserId = userId;
            newOrder.ProductId = productId;
            newOrder.DateCreated = DateTime.Now;

            _db.Orders.Add(newOrder);
            _db.SaveChanges();

            var orderWithInclude = _db.Orders.Include(_ => _.Product).FirstOrDefault(_ => _.Id == newOrder.Id);

            return View(orderWithInclude);
        }
        public IActionResult ConfirmOrderByAdmin(int orderId)
        {
            var order = _db.Orders.Include(_ => _.Product).FirstOrDefault(_ => _.Id == orderId);

            return View(order);
        }

        [HttpPost]
        public JsonResult ConfirmOrderByUser([FromBody] ConfirmOrderByUserDto dto)
        {
            var order = _db.Orders.FirstOrDefault(_ => _.Id == dto.OrderId);
            var result = new JsonAnswer();
            if (order == null)
            {
                return Json(result);
            }

            order.OrderStatus = OrderStatus.ConfirmedByUser;
            _db.SaveChanges();

            result.Ok = true;
            result.UserId = order.UserId;

            return Json(result);
        }

        [HttpPost]
        public JsonResult ConfirmOrderByAdmin([FromBody] ConfirmOrderByUserDto dto)
        {
            var order = _db.Orders.FirstOrDefault(_ => _.Id == dto.OrderId);
            var result = new JsonAnswer();
            if (order == null)
            {
                return Json(result);
            }

            order.OrderStatus = OrderStatus.ConfirmedByAdmin;
            _db.SaveChanges();

            result.Ok = true;

            return Json(result);
        }

        public IActionResult ForUser(int userId)
        {
            var orders = _db.Orders.Include(_ => _.Product).Where(_ => _.UserId == userId).ToList();

            var vm = new ListOfOrderForUserViewModel();
            vm.Orders = orders;
            vm.CurrentUserId = userId;

            return View(vm);
        }
        public IActionResult ForAdmin()
        {
            var orders = _db.Orders.Include(_ => _.Product).ToList();

            var vm = new ListOfOrderForUserViewModel();
            vm.Orders = orders;

            return View(vm);
        }
    }

    public class ConfirmOrderByUserDto
    {
        public int OrderId { get; set; }
    }
}