using MAFTLECOME.Data.Repository;
using MAFTLECOME.Models;
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

        public async Task<IActionResult> ManangeStock(int productId)
        {
            var existingStock = await _stockRepo.GetStockByProductId(productId);
            var stock = new StockDTO
            {
                ProductId = productId,
                Quantity = existingStock != null
            ? existingStock.Quantity : 0
            };
            return View(stock);
        }

        }
    }

