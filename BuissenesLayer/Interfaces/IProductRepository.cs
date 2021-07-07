using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace BuissenesLayer.Interfaces
{
    public interface IProductRepository
    {
        Task<IQueryable<Product>> GetProducts();
        Task<int> DeleteProduct(int? id);
        Task<int> UpdateProduct(Product product);
        Task<int> CreateProduct(Product product);
        Task<Product> GetProductByCategory(string category);
    }
}
