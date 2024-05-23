using Microsoft.AspNetCore.Mvc;

namespace Application.Abstractions.IServices
{
    public interface IRoleService
    {
        public Task<GenericResponseModel<object>> GetAllRoles();
        public Task<GenericResponseModel<bool>> AddRole(string name);
        public Task<GenericResponseModel<object>> GetRolesById(string id);
        public Task<GenericResponseModel<bool>> DeleteRole(string st);
        public Task<GenericResponseModel<bool>> UpdateAsync(string id, string name);
    }
}
