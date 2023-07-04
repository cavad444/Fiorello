using AutoMapper;
using Fiorello.Core.Entities;
using Fiorello.Core.Repositories;
using Fiorello.Services.Dtos.CommonDtos;
using Fiorello.Services.Dtos.FlowerDtos;
using Fiorello.Services.Exceptions;
using Fiorello.Services.Helpers;
using Fiorello.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fiorello.Services.Implementations
{
    public class FlowerService : IFlowerService
    {
        private readonly IMapper _mapper;
        private readonly IFlowerRepository _flowerRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public FlowerService(IMapper mapper, IFlowerRepository flowerRepository, ICategoryRepository categoryRepository, IHttpContextAccessor contextAccessor)
        {
            _flowerRepository = flowerRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _contextAccessor = contextAccessor;
        }
        public CreatedEntityDto Create(FlowerPostDto dto)
        {
            List<RestExceptionError> errors = new List<RestExceptionError>();

            if(_flowerRepository.IsExist(x => x.Name == dto.Name))
            {
                errors.Add(new RestExceptionError("Name", "Name is already exists"));
            }
            if(errors.Count > 0)
            {
                throw new RestException(System.Net.HttpStatusCode.BadRequest,errors);
            }
            var entity = _mapper.Map<Flower>(dto);
            string rootPath = Directory.GetCurrentDirectory() + "/wwwroot";
            entity.ImageName = FileManager.Save(dto.ImageFile, rootPath, "uploads/flowers");
            _flowerRepository.Add(entity);
            _flowerRepository.Commit();

           
            return new CreatedEntityDto { Id = entity.Id };
        }

        public void Delete(int id)
        {
            var entity = _flowerRepository.Get(x=>x.Id ==  id);
            if (entity == null) throw new RestException(System.Net.HttpStatusCode.NotFound, "Flower not found");
            _flowerRepository.Delete(entity);
            _flowerRepository.Commit();
            string rootPath = Directory.GetCurrentDirectory() + "/wwwroot";
            FileManager.Delete(rootPath, "uploads/flowers", entity.ImageName);
             
        }

        public void Edit(int id, FlowerPutDto dto)
        {
            var entity = _flowerRepository.Get(x => x.Id == id);
            if (entity == null) throw new RestException(System.Net.HttpStatusCode.NotFound, "Flower not found");
            List<RestExceptionError> errors = new List<RestExceptionError>();
            if (dto.Name != entity.Name && _flowerRepository.IsExist(x => x.Name == dto.Name))
            {
                errors.Add(new RestExceptionError("Name", "Name is already exists"));
            }
            entity.Name = dto.Name;
            entity.Price = dto.Price;
            entity.CategoryId = dto.CategoryId;

            string? removeableFileName = null;
            string rootPath = Directory.GetCurrentDirectory() + "/wwwroot";

            if (dto.ImageFile != null)
            {
                removeableFileName = entity.ImageName;
                entity.ImageName = FileManager.Save(dto.ImageFile, rootPath, "uploads/flowers");
            }
            _flowerRepository.Commit();
            if(removeableFileName!= null)
            { 
                FileManager.Delete(rootPath, "uploads/flowers",removeableFileName);
            }
        }

        public List<FlowerGetAllItemDto> GetAll()
        {
            var entities = _flowerRepository.GetAll(x => true, "Category");
            return _mapper.Map<List<FlowerGetAllItemDto>>(entities);
        }

        public FlowerGetDto GetById(int id)
        {
            var entity = _flowerRepository.Get(x => x.Id == id,"Category");
            if (entity == null) throw new RestException(System.Net.HttpStatusCode.NotFound, "Flower not found");
           
            return _mapper.Map<FlowerGetDto>(entity);
        }
    }
}
