using Microsoft.AspNetCore.Mvc;

namespace Wardakstudio.Services.ProductsAPI.Controllers
{
    public class ProductCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
