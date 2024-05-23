using Application.Abstractions.IRepositories;
using Application.Abstractions;
using Application.Abstractions.IServices;
using Application.Abstractions.IUnitOfWorks;
using Application.DTOs.AgentDtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.CategoryDtos;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Implementations.Services
{
    public class CategoryService:ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IGenericRepository<Category> _categoryRepo;


        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryRepo = _unitOfWork.GetRepository<Category>();


        }
        public async Task<GenericResponseModel<CreateUpdateCategoryDTO>> AddAsync(CreateUpdateCategoryDTO model)
        {
            GenericResponseModel<CreateUpdateCategoryDTO> response = new GenericResponseModel<CreateUpdateCategoryDTO>() { Data = null, StatusCode = 400 };



            Category categ = _mapper.Map<Category>(model);

            if (categ != null)
            {
                await _categoryRepo.Add(categ);
                var affect = await _unitOfWork.SaveAsync();
                if (affect > 0)
                {
                    response.Data = model;
                    response.StatusCode = 200;
                }
            }

            return response;
        }

        public async Task<GenericResponseModel<bool>> DeleteAsync(int id)
        {
            GenericResponseModel<bool> response = new GenericResponseModel<bool>() { Data = false, StatusCode = 400 };

            var categ = await _categoryRepo.GetById(id);

            if (categ == null)
            {
                return response;
            }

            _categoryRepo.Delete(categ);
            var affect = await _unitOfWork.SaveAsync();

            if (affect > 0)
            {
                response.Data = true;
                response.StatusCode = 200;
            }


            return response;
        }

       
        public async Task<GenericResponseModel<List<GetCategoryDTO>>> GetAllAsync()
        {
            GenericResponseModel<List<GetCategoryDTO>> response = new GenericResponseModel<List<GetCategoryDTO>>()
            {
                Data = null,
                StatusCode = 400,
            };
            List<Category> data = await _categoryRepo.GetAll().ToListAsync();
            if (data.Count > 0)
            {
                List<GetCategoryDTO> agent = _mapper.Map<List<GetCategoryDTO>>(data);
                response.Data = agent;
                response.StatusCode = 200;
            }
            return response;
        }

        public async Task<GenericResponseModel<GetCategoryDTO>> GetByIdAsync(int id)
        {
            GenericResponseModel<GetCategoryDTO> response = new GenericResponseModel<GetCategoryDTO>()
            {
                Data = null,
                StatusCode = 400,
            };

           Category categ = await _categoryRepo.GetById(id);

            if (categ != null)
            {
                var data = _mapper.Map<GetCategoryDTO>(categ);
                if (data != null)
                {
                    response.Data = data;
                    response.StatusCode = 200;
                }
            }

            return response;
        }

        public async Task<GenericResponseModel<bool>> UpdateAsync(CreateUpdateCategoryDTO model, int id)
        {

            GenericResponseModel<bool> response = new GenericResponseModel<bool>() { Data = false, StatusCode = 400 };

            var category = await _categoryRepo.GetById(id);

            if (category != null)
            {
                _mapper.Map<CreateUpdateCategoryDTO, Category>(model, category);
                var affect = await _unitOfWork.SaveAsync();
                if (affect > 0)
                {
                    response.StatusCode = 200;
                    response.Data = true;
                }
            }




            return response;
        }

    }
}
