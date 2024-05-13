using MAFTLECOME.Data.Base;
using MAFTLECOME.Models;
using System.Collections;

namespace MAFTLECOME.Data.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddAsync(Product product);

        Task<Product> UpdateAsync (int id, Product newProduct);
        Task DeleteAsync(int id);
    }
}
