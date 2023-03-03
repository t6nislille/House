using Microsoft.AspNetCore.Mvc;
using ProjectHouse.Data;
using ProjectHouse.Models.House;

namespace ProjectHouse.Controllers.House
{
    public class HouseController : Controller
    {
        private readonly ProjectHouseContext _context;

        public HouseController
            (
                ProjectHouseContext context
            )
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Houses
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new HouseIndexViewModel
                {
                    id = x.id,
                    Size = x.Size,
                    NumberOfFloors = x.NumberOfFloors,
                    NumberOfBathrooms = x.NumberOfBathrooms,
                    NumberOfBedrooms = x.NumberOfBedrooms
                });
            return View(result);
        }
        public IActionResult Create()
        {
            HouseCreateUpdateViewModel car = new HouseCreateUpdateViewModel();

            return View("CreateUpdate", car);
        }
    }
}
