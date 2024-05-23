using Application.Abstractions;
using Application.Abstractions.IRepositories;
using Application.Abstractions.IServices;
using Application.Abstractions.IUnitOfWorks;
using Application.DTOs.PropertyDtos;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Persistance.Implementations.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IGenericRepository<Property> _propertyRepo;

        public PropertyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _propertyRepo = _unitOfWork.GetRepository<Property>();


        }
        public async Task<GenericResponseModel<CreatePropertyDTO>> AddAsync(CreatePropertyDTO model)
        {
            GenericResponseModel<CreatePropertyDTO> responseModel = new() { Data = null, StatusCode = 400 };
            if (model == null)
                return responseModel;
            Property prop = new();
            prop = _mapper.Map<Property>(model);
            await _propertyRepo.Add(prop);
            var affectedRows = await _unitOfWork.SaveAsync();
            if (affectedRows == 0)
            {
                responseModel.StatusCode = 500;
                return responseModel;
            }
            responseModel.StatusCode = 200;
            responseModel.Data = model;
            return responseModel;
        }

        public async Task<GenericResponseModel<bool>> DeleteAsync(int id)
        {
            GenericResponseModel<bool> responseModel = new() { StatusCode = 400, Data = false };
            if (id <= 0) { return responseModel; }
            var review = await _propertyRepo.GetById(id);
            if (review == null)
            {
                responseModel.StatusCode = 404;
                return responseModel;
            }
            await _propertyRepo.DeleteById(id);
            var affectedRows = await _unitOfWork.SaveAsync();
            if (affectedRows == 0)
            {
                responseModel.StatusCode = 500;
                return responseModel;
            }
            responseModel.StatusCode = 200;
            responseModel.Data = true;
            return responseModel;
        }

        public async Task<GenericResponseModel<List<GetPropertyDTO>>> GetAllAsync()
        {
            GenericResponseModel<List<GetPropertyDTO>> responseModel = new() { StatusCode = 404, Data = null };
            var data = await _propertyRepo.GetAll().ToListAsync();
            if (data.Count == 0)
                return responseModel;
            var prop = _mapper.Map<List<GetPropertyDTO>>(data);
            responseModel.StatusCode = 200;
            responseModel.Data = prop;
            return responseModel;
        }

        public async Task<GenericResponseModel<GetPropertyDTO>> GetByIdAsync(int id)
        {
            GenericResponseModel<GetPropertyDTO> responseModel = new() { StatusCode = 400, Data = null };
            if (id <= 0)
            {
                return responseModel;
            }
            var data = await _propertyRepo.GetById(id);
            if (data == null)
            {
                responseModel.StatusCode = 404;
                return responseModel;
            }
            var prop = _mapper.Map<GetPropertyDTO>(data);
            responseModel.StatusCode = 200;
            responseModel.Data = prop;
            return responseModel;
        }

        public async Task<GenericResponseModel<List<GetPropertyDTO>>> GetProtertyByAgentId(int agentId)
        {
            GenericResponseModel<List<GetPropertyDTO>> responseModel = new() { Data = null, StatusCode = 400 };
            if (agentId <= 0)
            {
                return responseModel;
            }
            var data = await _propertyRepo.GetAll().Where(x => x.AgentId == agentId).ToListAsync();
            if (data.Count == 0)
            {
                responseModel.StatusCode = 404;
                return responseModel;
            }
            var prop = _mapper.Map<List<GetPropertyDTO>>(data);
            responseModel.StatusCode = 200;
            responseModel.Data = prop;
            return responseModel;
        }

        
        public async Task<GenericResponseModel<List<GetPropertyDTO>>> GetProtertyByOwnerId(int ownerId)
        {
            GenericResponseModel<List<GetPropertyDTO>> responseModel = new() { Data = null, StatusCode = 400 };
            if (ownerId <= 0)
            {
                return responseModel;
            }
            var data = await _propertyRepo.GetAll().Where(x => x.OwnerId == ownerId).ToListAsync();
            if (data.Count == 0)
            {
                responseModel.StatusCode = 404;
                return responseModel;
            }
            var prop = _mapper.Map<List<GetPropertyDTO>>(data);
            responseModel.StatusCode = 200;
            responseModel.Data = prop;
            return responseModel;
        }

        public async Task<GenericResponseModel<List<GetPropertyDTO>>> GetProtertyByRegionOfCityId(int regionId)
        {
            GenericResponseModel<List<GetPropertyDTO>> responseModel = new() { Data = null, StatusCode = 400 };
            if (regionId <= 0)
            {
                return responseModel;
            }
            var data = await _propertyRepo.GetAll().Where(x => x.RegionOfCityId == regionId).ToListAsync();
            if (data.Count == 0)
            {
                responseModel.StatusCode = 404;
                return responseModel;
            }
            var prop = _mapper.Map<List<GetPropertyDTO>>(data);
            responseModel.StatusCode = 200;
            responseModel.Data = prop;
            return responseModel;
        }

        public async Task<GenericResponseModel<bool>> UpdateAsync(UpdatePropertyDTO model, int id)
        {
            GenericResponseModel<bool> response = new GenericResponseModel<bool>() { Data = false, StatusCode = 404 };
            var prop = await _propertyRepo.GetById(id);
            if (prop != null)
            {
                _mapper.Map<UpdatePropertyDTO, Property>(model, prop);
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
