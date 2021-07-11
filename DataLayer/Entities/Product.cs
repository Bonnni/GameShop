using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
