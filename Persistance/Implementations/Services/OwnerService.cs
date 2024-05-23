using Application.Abstractions;
using Application.Abstractions.IRepositories;
using Application.Abstractions.IServices;
using Application.Abstractions.IUnitOfWorks;
using Application.DTOs.AgentDtos;
using Application.DTOs.OwnerDtos;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Implementations.Services
{
   public class OwnerService : IOwnerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IGenericRepository<Owner> _ownerRepo;


        public OwnerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _ownerRepo = _unitOfWork.GetRepository<Owner>();


        }

        public async Task<GenericResponseModel<CreateUpdateOwnerDTO>> AddAsync(CreateUpdateOwnerDTO model)
        {
            GenericResponseModel<CreateUpdateOwnerDTO> response = new GenericResponseModel<CreateUpdateOwnerDTO>() { Data = null, StatusCode = 400 };



            Owner owner = _mapper.Map<Owner>(model);

            if (owner != null)
            {
                await _ownerRepo.Add(owner);
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

            var owner = await _ownerRepo.GetById(id);

            if (owner == null)
            {
                return response;
            }

            _ownerRepo.Delete(owner);
            var affect = await _unitOfWork.SaveAsync();

            if (affect > 0)
            {
                response.Data = true;
                response.StatusCode = 200;
            }


            return response;
        }

        public async Task<GenericResponseModel<List<GetOwnerDTO>>> GetAllAsync()
        {
            GenericResponseModel<List<GetOwnerDTO>> response = new GenericResponseModel<List<GetOwnerDTO>>()
            {
                Data = null,
                StatusCode = 400,
            };
            List<Owner> data = await _ownerRepo.GetAll().ToListAsync();
            if (data.Count > 0)
            {
                List<GetOwnerDTO> owner = _mapper.Map<List<GetOwnerDTO>>(data);
                response.Data = owner;
                response.StatusCode = 200;
            }
            return response;
        }

        public async Task<GenericResponseModel<GetOwnerDTO>> GetByIdAsync(int id)
        {
            GenericResponseModel<GetOwnerDTO> response = new GenericResponseModel<GetOwnerDTO>()
            {
                Data = null,
                StatusCode = 400,
            };

            Owner owner = await _ownerRepo.GetById(id);

            if (owner != null)
            {
                var data = _mapper.Map<GetOwnerDTO>(owner);
                if (data != null)
                {
                    response.Data = data;
                    response.StatusCode = 200;
                }
            }

            return response;
        }

        public async Task<GenericResponseModel<GetOwnerDTO>> GetOwnerByPropertyId(int propertyId)
        {
            GenericResponseModel<GetOwnerDTO> responseModel = new() { Data = null, StatusCode = 400 };
            if (propertyId <= 0)
            {
                return responseModel;
            }
            var data = await _ownerRepo.GetAll().Where(c => c.Properties.Any(p => p.Id == propertyId)).FirstOrDefaultAsync();

            if (data == null)
            {
                responseModel.StatusCode = 404;
                return responseModel;
            }
            var owner = _mapper.Map<GetOwnerDTO>(data);
            responseModel.StatusCode = 200;
            responseModel.Data = owner;
            return responseModel;
        }

        public async Task<GenericResponseModel<bool>> UpdateAsync(CreateUpdateOwnerDTO model, int id)
        {
            GenericResponseModel<bool> response = new GenericResponseModel<bool>() { Data = false, StatusCode = 400 };

            var owner = await _ownerRepo.GetById(id);

            if (owner != null)
            {
                _mapper.Map<CreateUpdateOwnerDTO, Owner>(model, owner);
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
