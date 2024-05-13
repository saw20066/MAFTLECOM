using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAFTLECOME.Data;
using MAFTLECOME.Models;
using Microsoft.EntityFrameworkCore;

namespace MAFTLECOME.Data.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _context;

        // Constructor for dependency injection
        public ProductsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
          
        }

        public async Task DeleteAsync(int id)
        {
            var reslt = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

             _context.Products.Remove(reslt);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var reslt = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return reslt;

        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var Result = await _context.Products.ToListAsync();
            return Result;
        }

        public async Task<Product> UpdateAsync(int id, Product newProduct)
        {
            _context.Update(newProduct);
            await _context.SaveChangesAsync();
            return newProduct;
        }
    }
}
