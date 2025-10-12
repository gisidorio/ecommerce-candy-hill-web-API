using Microsoft.AspNetCore.Mvc;

namespace EcommerceCandyHill.MVC.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
