using Fiorello.Services.Dtos.CommonDtos;
using Fiorello.Services.Dtos.FlowerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiorello.Services.Interfaces
{
    public interface IFlowerService
    {
        CreatedEntityDto Create(FlowerPostDto dto);
        void Edit(int id, FlowerPutDto dto);
        FlowerGetDto GetById(int id);
        List<FlowerGetAllItemDto> GetAll();
        void Delete(int id);    
    }
}
