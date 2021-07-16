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

        public async Task<IEnumerable<ProductDTO>> GetProductByGenre(string genre)
        {
            if (_db != null)
            {
                var products = await GetProducts();
                products.Where(x => x.Genres.Select(x => x == genre).FirstOrDefault());
                return products;
            }
            return null;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            if (_db != null)
            {
                var lists = await _db.Products
                    .Include(x => x.Company)
                    .Include(x => x.Genre)
                    .Select(x => new ProductDTO
                    {
                        Id = x.ID,
                        Name = x.Name,
                        Company = x.Company.Name,
                        Genres = x.Genre!.Select(x => x.Name).ToArray()
                    }).ToListAsync();
                return lists;
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
