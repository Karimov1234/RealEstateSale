using Application.DTOs.PropertyDtos;

namespace Application.Abstractions.IServices
{
    public interface IPropertyService
    {
        public Task<GenericResponseModel<GetPropertyDTO>> GetByIdAsync(int id);
        public Task<GenericResponseModel<List<GetPropertyDTO>>> GetAllAsync();
        public Task<GenericResponseModel<CreatePropertyDTO>> AddAsync(CreatePropertyDTO model);
        public Task<GenericResponseModel<bool>> UpdateAsync(UpdatePropertyDTO model, int id);
        public Task<GenericResponseModel<bool>> DeleteAsync(int id);
        public Task<GenericResponseModel<List<GetPropertyDTO>>> GetProtertyByOwnerId(int ownerId);
        public Task<GenericResponseModel<List<GetPropertyDTO>>> GetProtertyByAgentId(int agentId);
        public Task<GenericResponseModel<List<GetPropertyDTO>>> GetProtertyByRegionOfCityId(int regionId);
    }
}
