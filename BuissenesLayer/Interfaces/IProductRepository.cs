using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace BuissenesLayer.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int? id);
        Task<int> DeleteProduct(int? id);
        Task UpdateProduct(Product product);
        Task<int> CreateProduct(Product product);
        Task<Product> GetProductByGenre(string category);
    }
}
