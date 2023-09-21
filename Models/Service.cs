using Microsoft.AspNetCore.Mvc;

namespace EcoPower_Logistics.Models
{
    public class Service : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
