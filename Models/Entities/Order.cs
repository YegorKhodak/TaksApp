using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task2.Models.Entities
{
    public class Order
    {
        public Order()
        {
            OrderStatus = OrderStatus.Created;
        }
        public int Id { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public enum OrderStatus
    {
        Created = 0,
        ConfirmedByUser = 1,
        ConfirmedByAdmin = 2
    }
}
