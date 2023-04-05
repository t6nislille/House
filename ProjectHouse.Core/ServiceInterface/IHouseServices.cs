using ProjectHouse.Core.Domain;
using ProjectHouse.Core.Dto;

namespace ProjectHouse.Core.ServiceInterface
{
    public interface IHouseServices
    {
        Task<House> Create(HouseDto dto);
        Task<House> GetAsync(Guid id);
        Task<House> Update(HouseDto dto);
        Task<House> Delete(Guid id);

    }
}
