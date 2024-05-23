using Application.DTOs.UserDtos;
using Domain.Entities.Identities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Abstractions.IServices
{
    public interface IUserService
    {
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime dateTime);
        public Task<GenericResponseModel<bool>> AssignRolesToUserAsync(string userid, string[] roles);
        public Task<GenericResponseModel<List<GetUserDTO>>> GetAllUserAsync();
        public Task<GenericResponseModel<string[]>> GetRolesToUserAsync(string usernameOrId);
        public Task<GenericResponseModel<CreateUserResponseDTO>> AddAsync(CreateUserDTO st);
        public Task<GenericResponseModel<bool>> UpdateAsync(UpdateUserDTO st);
        public Task<GenericResponseModel<bool>> DeleteAsync(string idOrName);
        public Task<GenericResponseModel<GetUserDTO>> GetById(string id);







    }
}
