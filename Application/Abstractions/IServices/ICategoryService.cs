using Application.DTOs.AgentDtos;
using Application.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.IServices
{
    public interface ICategoryService
    {
        public Task<GenericResponseModel<List<GetCategoryDTO>>> GetAllAsync();
        public Task<GenericResponseModel<GetCategoryDTO>> GetByIdAsync(int id);
        public Task<GenericResponseModel<CreateUpdateCategoryDTO>> AddAsync(CreateUpdateCategoryDTO model);
        public Task<GenericResponseModel<bool>> UpdateAsync(CreateUpdateCategoryDTO model, int id);
        public Task<GenericResponseModel<bool>> DeleteAsync(int id);
    }
}
