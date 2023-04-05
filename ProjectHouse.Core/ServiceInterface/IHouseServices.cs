using ProjectHouse.Core.Domain;
using ProjectHouse.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHouse.Core.ServiceInterface
{
    public interface IHouseServices
    {
        Task<House> Create(HouseDto dto);
    }
}
