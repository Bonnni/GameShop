using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuissenesLayer.Interfaces;
using DataLayer.Entities;
using DataLayer.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BuissenesLayer.Implementations
{
    class EFProductRepository : IProductRepository
    {
        private EfDbContext _db;
        EFProductRepository(EfDbContext db)
        {
            _db = db;
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

        public async Task<IQueryable<Product>> GetProducts()
        {
            if (_db != null)
            {
                return (IQueryable<Product>)await _db.Products.ToListAsync();
            }

            return null;
        }

        public async Task<int> UpdateProduct(Product product)
        {
            if (_db != null)
            {
                _db.Products.Update(product);

                await _db.SaveChangesAsync();
            }

            return 0;
        }
    }
}
