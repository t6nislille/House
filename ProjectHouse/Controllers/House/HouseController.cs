using Microsoft.AspNetCore.Mvc;
using ProjectHouse.Data;
using ProjectHouse.Models.House;
using ProjectHouse.Core.Dto;
using ProjectHouse.Core.ServiceInterface;

namespace ProjectHouse.Controllers.House
{
    public class HouseController : Controller
    {
        private readonly ProjectHouseContext _context;
        private readonly IHouseServices _houseServices;

        public HouseController
            (
                ProjectHouseContext context,
                IHouseServices houseServices
            )
        {
            _context = context;
            _houseServices = houseServices;
        }
        public IActionResult Index()
        {
            var result = _context.Houses
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new HouseIndexViewModel
                {
                    Id = x.Id,
                    Size = x.Size,
                    NumberOfFloors = x.NumberOfFloors,
                    NumberOfBathrooms = x.NumberOfBathrooms,
                    NumberOfBedrooms = x.NumberOfBedrooms
                });
            return View(result);
        }
        public IActionResult Create()
        {
            HouseCreateUpdateViewModel house = new HouseCreateUpdateViewModel();

            return View("CreateUpdate", house);
        }

        [HttpPost]
        public async Task<IActionResult> Create(HouseCreateUpdateViewModel vm)
        {
            var dto = new HouseDto()
            {
                Id = vm.Id,
                Size = vm.Size,
                NumberOfFloors = vm.NumberOfFloors,
                NumberOfBathrooms = vm.NumberOfBathrooms,
                NumberOfBedrooms = vm.NumberOfBedrooms,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
            };

            var result = await _houseServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
    }
}
