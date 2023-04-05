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

        
    }
}
  