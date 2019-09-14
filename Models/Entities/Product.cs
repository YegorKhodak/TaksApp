using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task2.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
    }
}
