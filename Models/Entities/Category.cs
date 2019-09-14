using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task2.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
