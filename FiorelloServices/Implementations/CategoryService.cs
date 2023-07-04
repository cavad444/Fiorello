using AutoMapper;
using Fiorello.Core.Entities;
using Fiorello.Core.Repositories;
using Fiorello.Services.Dtos.CategoryDtos;
using Fiorello.Services.Dtos.CommonDtos;
using Fiorello.Services.Exceptions;
using FiorelloServices.Interfaces;
using System.Net;

namespace Fiorello.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            
        }
        public CreatedEntityDto Create(CategoryPostDto dto)
        {
            if(_categoryRepository.IsExist(x => x.Name == dto.Name))
            {
                throw new RestException(System.Net.HttpStatusCode.BadRequest,"Name","Name is already exists");
            }
            var entity = _mapper.Map<Category>(dto);
            _categoryRepository.Add(entity);
            _categoryRepository.Commit();
            return new CreatedEntityDto { Id = entity.Id };
        }

        public void Delete(int id)
        {
            var entity = _categoryRepository.Get(x => x.Id == id);
            if (entity == null) throw new RestException(System.Net.HttpStatusCode.NotFound,"Entity not found");
            _categoryRepository.Delete(entity);
            _categoryRepository.Commit();
        }

        public void Edit(int id, CategoryPutDto dto)
        {
            var entity = _categoryRepository.Get(x => x.Id == id);
            if (entity == null) throw new RestException(System.Net.HttpStatusCode.NotFound, "Entity not found");
            if (entity.Name != dto.Name && _categoryRepository.IsExist(x => x.Name == dto.Name))
            {
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "Name", "Name is already exists");
            }
            entity.Name = dto.Name;
            _categoryRepository.Commit();
        }

        public List<CategoryGetAllItemDto> GetAll()
        {
            var entities = _categoryRepository.GetAll(x=>true);
            return _mapper.Map<List<CategoryGetAllItemDto>>(entities);
        }


        public CategoryGetDto GetById(int id)
        {
            var entity = _categoryRepository.Get(x => x.Id == id,"Flowers");
            if (entity == null) throw new RestException(System.Net.HttpStatusCode.NotFound, "Entity not found");
            return _mapper.Map<CategoryGetDto>(entity);
        }
    }

}
