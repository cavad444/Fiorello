using Fiorello.Services.Dtos.CategoryDtos;
using Fiorello.Services.Dtos.CommonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiorelloServices.Interfaces
{
    public interface ICategoryService
    {
        CreatedEntityDto Create(CategoryPostDto dto);
        void Edit(int id, CategoryPutDto dto);
        List<CategoryGetAllItemDto> GetAll();
        void Delete(int id);    
        CategoryGetDto GetById(int id);

    }
}
