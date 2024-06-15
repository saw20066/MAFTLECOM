using MAFTLECOME.Data.Services;
using MAFTLECOME.Models;
using MAFTLECOME.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MAFTLECOME.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsService _service;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        // Constructor for dependency injection
        public ProductController(IProductsService service, IFileService fileService)
        {
            _service = service;
            _fileService = fileService;
        }

        public async Task<IActionResult> Product_Index()
        {
            var data = await _service.GetProductsAsync();
            return View(data);
        }

        // Add product
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description,ImageURL,Price,ArticleNumber")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _service.AddAsync(product);
            return RedirectToAction(nameof(Product_Index));
        } 

        // Get product details
        public async Task<IActionResult> Details(int id)
        {
            var ProductDetails = await _service.GetProductByIdAsync(id);
            if (ProductDetails == null) return View("Null");
            return View(ProductDetails);
        }

        // Edit product
        public async Task<IActionResult> Edit(int id)
        {
            var ProductDetails = await _service.GetProductByIdAsync(id);
            if (ProductDetails == null) return View("Null");
            return View(ProductDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImageURL,Price,ArticleNumber")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            try
            {
                await _service.UpdateAsync(id, product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProductExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Product_Index));
        }

        // Delete product
        public async Task<IActionResult> Delete(int id)
        {
            var ProductDetails = await _service.GetProductByIdAsync(id);
            if (ProductDetails == null) return View("Null");
            return View(ProductDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ProductDetails = await _service.GetProductByIdAsync(id);
            if (ProductDetails == null) return View("Null");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Product_Index));
        }

        private async Task<bool> ProductExists(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            return product != null;
        }
    }
}