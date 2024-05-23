using Application.DTOs.AgentDtos;

namespace Application.Abstractions.IServices
{
    public interface IAgentService
    {
        public Task<GenericResponseModel<List<GetAgentDTO>>> GetAllAsync();
        public Task<GenericResponseModel<GetAgentDTO>> GetByIdAsync(int id);
        public Task<GenericResponseModel<CreateUpdateAgentDTO>> AddAsync(CreateUpdateAgentDTO model);
        public Task<GenericResponseModel<bool>> UpdateAsync(CreateUpdateAgentDTO model,int id);
        public Task<GenericResponseModel<bool>> DeleteAsync(int id);
        public Task<GenericResponseModel<GetAgentDTO>> GetAgentByPropertyId(int propertyId);

    }
}
