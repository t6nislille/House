﻿using Microsoft.EntityFrameworkCore;
using ProjectHouse.Core.Domain;
using ProjectHouse.Core.Dto;
using ProjectHouse.Core.ServiceInterface;
using ProjectHouse.Data;

namespace ProjectHouse.ApplicationServices.Services
{
    public class HouseServices : IHouseServices
    {
        private readonly ProjectHouseContext _context;
        public HouseServices(ProjectHouseContext context)
        {
            _context = context;
        }

        public async Task<House> Create(HouseDto dto)
        {
            House house = new House();

            house.Id = Guid.NewGuid();
            house.Size = dto.Size;
            house.NumberOfFloors = dto.NumberOfFloors;
            house.NumberOfBathrooms = dto.NumberOfBathrooms;
            house.NumberOfBedrooms = dto.NumberOfBedrooms;
            house.CreatedAt = DateTime.Now;
            house.ModifiedAt = DateTime.Now;

            

            await _context.Houses.AddAsync(house);
            await _context.SaveChangesAsync();

            return house;
        }

        public async Task<House> GetAsync(Guid id)
        {
            var result = await _context.Houses
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}

