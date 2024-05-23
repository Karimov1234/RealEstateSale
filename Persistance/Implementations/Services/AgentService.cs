using Application.Abstractions;
using Application.Abstractions.IRepositories;
using Application.Abstractions.IServices;
using Application.Abstractions.IUnitOfWorks;
using Application.DTOs.AgentDtos;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations.Services
{
    public class AgentService : IAgentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IGenericRepository<Agent> _agentRepo;
      

        public AgentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _agentRepo = _unitOfWork.GetRepository<Agent>();


        }
        public async Task<GenericResponseModel<CreateUpdateAgentDTO>> AddAsync(CreateUpdateAgentDTO model)
        {
            GenericResponseModel<CreateUpdateAgentDTO> response = new GenericResponseModel<CreateUpdateAgentDTO>() { Data = null, StatusCode = 400 };

         
                
            Agent agent = _mapper.Map<Agent>(model);
          
            if (agent != null)
            {
                await _agentRepo.Add(agent);
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

            var agent = await _agentRepo.GetById(id);

            if (agent == null)
            {
                return response;
            }

            _agentRepo.Delete(agent);
            var affect = await _unitOfWork.SaveAsync();

            if (affect > 0)
            {
                response.Data = true;
                response.StatusCode = 200;
            }
           

            return response;
        }

        public async Task<GenericResponseModel<GetAgentDTO>> GetAgentByPropertyId(int propertyId)
        {
            GenericResponseModel<GetAgentDTO> responseModel = new() { Data = null, StatusCode = 400 };
            if (propertyId <= 0)
            {
                return responseModel;
            }
            var data = await _agentRepo.GetAll().Where(c => c.Properties.Any(p => p.Id == propertyId)).FirstOrDefaultAsync();

            if (data == null)
            {
                responseModel.StatusCode = 404;
                return responseModel;
            }
            var agent = _mapper.Map<GetAgentDTO>(data);
            responseModel.StatusCode = 200;
            responseModel.Data = agent;
            return responseModel;
        }

        public async Task<GenericResponseModel<List<GetAgentDTO>>> GetAllAsync()
        {
            GenericResponseModel<List<GetAgentDTO>> response = new GenericResponseModel<List<GetAgentDTO>>()
            {
                Data = null,
                StatusCode = 400,
            };
            List<Agent> data = await _agentRepo.GetAll().ToListAsync();
            if (data.Count > 0)
            {
                List<GetAgentDTO> agent = _mapper.Map<List<GetAgentDTO>>(data);
                response.Data = agent;
                response.StatusCode = 200;
            }
            return response;
        }

        public async Task<GenericResponseModel<GetAgentDTO>> GetByIdAsync(int id)
        {
            GenericResponseModel<GetAgentDTO> response = new GenericResponseModel<GetAgentDTO>()
            {
                Data = null,
                StatusCode = 400,
            };

            Agent agent = await _agentRepo.GetById(id);

            if (agent != null)
            {
                var data = _mapper.Map<GetAgentDTO>(agent);
                if(data!= null)
                {
                    response.Data = data;
                    response.StatusCode = 200;
                }
            }

            return response;
        }

        public async Task<GenericResponseModel<bool>> UpdateAsync(CreateUpdateAgentDTO model,int id)
        {

            GenericResponseModel<bool> response = new GenericResponseModel<bool>() { Data = false, StatusCode = 400 };

            var agent = await _agentRepo.GetById(id);

            if (agent != null)
            {
               _mapper.Map<CreateUpdateAgentDTO,Agent>(model,agent);
                var affect = await _unitOfWork.SaveAsync();
                if (affect>0)
                {
                    response.StatusCode=200;
                    response.Data = true;
                }
            }


           

            return response;
        }

     
    }
}
