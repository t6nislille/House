using ProjectHouse.Core.Domain;
using ProjectHouse.Core.Dto;
using ProjectHouse.Data;

namespace ProjectHouse.ApplicationServices.Services
{
    public class HouseServices
    {
        private readonly ProjectHouseContext _context;
        public HouseServices(ProjectHouseContext context)
        {
            _context = context;
        }

        public async Task<House> Create(HouseDto dto)
        {
            House house = new House()
            {
                id = Guid.NewGuid(),
                Size = dto.Size,
                NumberOfFloors = dto.NumberOfFloors,
                NumberOfBathrooms = dto.NumberOfBathrooms,
                NumberOfBedrooms = dto.NumberOfBedrooms,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now

            };

            await _context.Houses.AddAsync(house);
            await _context.SaveChangesAsync();

            return house;
        }
    }
}

