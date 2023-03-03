using Microsoft.AspNetCore.Mvc;

namespace ProjectHouse.Controllers.House
{
    public class HouseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
