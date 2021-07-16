using System.Collections.Generic;
using Newtonsoft.Json;

namespace DataLayer.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int GenreId { get; set; }
        public ICollection<Genre> Genre { get; set; }
    }   
}
