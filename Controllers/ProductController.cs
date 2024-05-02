using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MAFTLECOME.Controllers
{

    

    public class ProductController : Controller
    {
        public IActionResult GetALL()
        {
            return View();
        }
    }
}
