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

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var house = await _houseServices.GetAsync(id);

            if(house == null)
            {
                return NotFound();
            }

            var vm = new HouseCreateUpdateViewModel();

            vm.Id = house.Id;
            vm.Size = house.Size;
            vm.NumberOfFloors = house.NumberOfFloors;
            vm.NumberOfBathrooms= house.NumberOfBathrooms;
            vm.NumberOfBedrooms = house.NumberOfBedrooms;
            vm.CreatedAt = house.CreatedAt;
            vm.ModifiedAt = house.ModifiedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(HouseCreateUpdateViewModel vm)
        {
            var dto = new HouseDto()
            {
                Id = vm.Id,
                Size = vm.Size,
                NumberOfFloors = vm.NumberOfFloors,
                NumberOfBathrooms = vm.NumberOfBathrooms,
                NumberOfBedrooms = vm.NumberOfBedrooms,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _houseServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var house = await _houseServices.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var vm = new HouseDetailsViewModel();

            vm.Id = house.Id;
            vm.Size = house.Size;
            vm.NumberOfFloors = house.NumberOfFloors;
            vm.NumberOfBathrooms = house.NumberOfBathrooms;
            vm.NumberOfBedrooms = house.NumberOfBedrooms;
            vm.CreatedAt = house.CreatedAt;
            vm.ModifiedAt = house.ModifiedAt;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var house = await _houseServices.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var vm = new HouseDeleteViewModel();

            vm.Id = house.Id;
            vm.Size = house.Size;
            vm.NumberOfFloors = house.NumberOfFloors;
            vm.NumberOfBathrooms = house.NumberOfBathrooms;
            vm.NumberOfBedrooms = house.NumberOfBedrooms;
            vm.CreatedAt = house.CreatedAt;
            vm.ModifiedAt = house.ModifiedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var houseId = await _houseServices.Delete(id);

            if (houseId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
