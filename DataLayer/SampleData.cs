using System.Collections.Generic;
using DataLayer.Context;
using DataLayer.Entities;

namespace DataLayer
{
    public class SampleData
    {
        private readonly EfDbContext _db;
        public SampleData(EfDbContext db)
        {
            _db = db;
        }
        public void InitData()
        {
            var company = new Company { Name = "Company1" };
            var product = new Product { Name = "Product1", Company = company, Genre = new Genre[] {
                                        new Genre { Name = "Genre1" },
                                        new Genre { Name = "Genre2" }}};

            _db.Products.Add(product);
            _db.SaveChanges();
       }
    }
}
