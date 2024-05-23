using Application.DTOs.OwnerDtos;

namespace Application.Abstractions.IServices
{
    public interface IOwnerService
    {
        public Task<GenericResponseModel<GetOwnerDTO>> GetByIdAsync(int id);
        public Task<GenericResponseModel<List<GetOwnerDTO>>> GetAllAsync();
        public Task<GenericResponseModel<CreateUpdateOwnerDTO>> AddAsync(CreateUpdateOwnerDTO model);
        public Task<GenericResponseModel<bool>> UpdateAsync(CreateUpdateOwnerDTO model, int id);
        public Task<GenericResponseModel<bool>> DeleteAsync(int id);
        public Task<GenericResponseModel<GetOwnerDTO>> GetOwnerByPropertyId(int propertyId);
    }
}
