using Microsoft.EntityFrameworkCore.Internal;
using ProjectHouse.Core.Domain;
using ProjectHouse.Core.Dto;
using ProjectHouse.Core.ServiceInterface;
using Xunit;

namespace ProjectHouse.HouseTest
{
    public class Test : TestBase
    {
        [Fact]
        public async Task Create_ValidHouse_ShouldBeCreated()
        {
            DateTime testStart = DateTime.Now;
            HouseDto houseDto = CreateValidHouse();

            var result = await Svc<IHouseServices>().Create(houseDto);
            AssertHouseFields(houseDto, result);
            Assert.True(testStart < result.CreatedAt);
            Assert.True(testStart < result.ModifiedAt);
        }

        [Fact]
        public async Task GetAsync_InValidId_ShouldNotGet()
        {
            Assert.Null(await Svc<IHouseServices>().GetAsync(Guid.NewGuid()));
        }

        [Fact]
        public async Task GetAsync_Valid_ShouldGet()
        {
            HouseDto houseDto = CreateValidHouse();
            var createdHouse = await Svc<IHouseServices>().Create(houseDto);

            var result = await Svc<IHouseServices>().GetAsync((Guid)createdHouse.Id);
            Assert.Equal(createdHouse, result);
        }

        [Fact]
        public async Task Delete_IsFoundById_ShouldBeDeleted()
        {
            HouseDto houseDto = CreateValidHouse();
            var createdHouse = await Svc<IHouseServices>().Create(houseDto);

            var result = await Svc<IHouseServices>().Delete((Guid)createdHouse.Id);
            Assert.Equal(createdHouse, result);
        }

        [Fact]
        public async Task Update_House_ShouldBeUpdated()
        {
            HouseDto houseDto = CreateValidHouse();
            await Svc<IHouseServices>().Create(houseDto);
            HouseDto newHouse = UpdateValidHouse(houseDto);

            var result = await Svc<IHouseServices>().Update(newHouse);
            AssertHouseFields(newHouse, result);
            Assert.Equal(newHouse.CreatedAt, result.CreatedAt);
            Assert.NotEqual(newHouse.ModifiedAt, result.ModifiedAt);
        }

        //ShortcutMethods
        private HouseDto CreateValidHouse()
        {
            HouseDto houseDto = new();
            houseDto.Size = 100;
            houseDto.NumberOfFloors = 1;
            houseDto.NumberOfBathrooms = 1;
            houseDto.NumberOfBedrooms = 1;

            return houseDto;
        }

        private void AssertHouseFields(HouseDto expected, House actual)
        {
            Assert.NotNull(actual.Id);
            Assert.Equal(expected.Size, actual.Size);
            Assert.Equal(expected.NumberOfFloors, actual.NumberOfFloors);
            Assert.Equal(expected.NumberOfBathrooms, actual.NumberOfBathrooms);
            Assert.Equal(expected.NumberOfBedrooms, actual.NumberOfBedrooms);
        }

        private HouseDto UpdateValidHouse(HouseDto house)
        {
            house.Size = 500;
            house.NumberOfFloors = 5;
            house.NumberOfBathrooms = 5;
            house.NumberOfBedrooms = 5;

            return house;
        }

        
    }
}
  