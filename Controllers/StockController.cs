using MAFTLECOME.Data.Repository;
using MAFTLECOME.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MAFTLECOME.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockRepository _stockRepo;

        public StockController(IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
        }

        public async Task<IActionResult> Index(string sTerm = "")
        {
            var stocks = await _stockRepo.GetStocks(sTerm);
            return View(stocks);
        }

        [HttpGet]
        public async Task<IActionResult> ManageStock(int productId)
        {
            var existingStock = await _stockRepo.GetStockByProductId(productId);
            var stock = new StockDTO
            {
                ProductId = productId,
                Quantity = existingStock != null ? existingStock.Quantity : 0
            };
            return View(stock);
        }

        [HttpPost]
        public async Task<IActionResult> ManageStock(StockDTO stock)
        {
            if (ModelState.IsValid)
            {
                await _stockRepo.ManageStock(stock);
                return RedirectToAction("Index");
            }
            return View(stock);
        }
    }
}
