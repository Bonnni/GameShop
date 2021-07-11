using System.Threading.Tasks;
using BuissenesLayer.Interfaces;
using DataLayer.Entities;
using DataLayer.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BuissenesLayer.Implementations
{
    public class EFProductRepository : IProductRepository
    {
        private EfDbContext _db;
        public EFProductRepository(EfDbContext db)
        {
            _db = db;
        }

        public async Task<Product> GetProduct(int? id)
        {
            if(_db != null)
            {
                return await _db.Products.FirstOrDefaultAsync(x => x.ID == id);
            }
            return null;
        }

        public async Task<int> CreateProduct(Product product)
        {
            if (_db != null)
            {
                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();

                return product.ID;
            }

            return 0;
        }

        public async Task<int> DeleteProduct(int? id)
        {
            int result = 0;

            if (_db != null)
            {
                var product = await _db.Products.FirstOrDefaultAsync(x => x.ID == id);
                
                if (product != null)
                {
                    _db.Products.Remove(product);

                    result = await _db.SaveChangesAsync();
                }
                return result;
            }

            return 0;
        }

        public async Task<Product> GetProductByGenre(string category)
        {
            if (_db != null)
            {
                return await _db.Products.Include(x => x.Company).FirstOrDefaultAsync(x => x.Company.Name == category);
            }

            return null;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            if (_db != null)
            {
                return await _db.Products.ToListAsync();
            }

            return null;
        }

        public async Task UpdateProduct(Product product)
        {
            if (_db != null)
            {
                _db.Products.Update(product);

                await _db.SaveChangesAsync();
            }
        }
    }
}
