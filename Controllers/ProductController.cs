using MAFTLECOME.Data;
using MAFTLECOME.Data.Services;
using MAFTLECOME.Models;
using MAFTLECOME.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace MAFTLECOME.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsService _service;
        private readonly IFileService _fileService;

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
        //addproduct
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create([Bind("Name,Description,ImageURL,Price,ArticleNumber,Pricee,Stock,CartDetail,OrderDetail,Quantity")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _service.AddAsync(product);
            return RedirectToAction(nameof(Product_Index));


        }

        //getproduct

        public async Task<IActionResult> Details(int id)
        {
            var ProductDetails = await _service.GetProductByIdAsync(id);

            if (ProductDetails == null) return View("Null");
            return View(ProductDetails);



        }
        //editproduct/1
        public async Task<IActionResult> Edit(int id)
        {
            var ProductDetails = await _service.GetProductByIdAsync(id);
            if (ProductDetails == null) return View("Null");
            return View(ProductDetails);
        }


        [HttpPost]

        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,ImageURL,Price,ArticleNumber,Pricee,Stock,CartDetail,OrderDetail,Quantity")] Product product)

        {

            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _service.UpdateAsync(id, product);
            return RedirectToAction(nameof(Product_Index));
        }

        //DEleteproduct
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


    }

}


