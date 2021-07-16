using System.Collections.Generic;
using Newtonsoft.Json;

namespace DataLayer.Entities
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
