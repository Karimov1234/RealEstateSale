using Application.Abstractions;
using Application.Abstractions.IServices;
using Application.DTOs.UserDtos;
using Application.DTOs;
using AutoMapper;
using Domain.Entities.Identities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {

            _userManager = userManager;
            _mapper = mapper;


        }

        public async Task<GenericResponseModel<CreateUserResponseDTO>> AddAsync(CreateUserDTO st)
        {
            GenericResponseModel<CreateUserResponseDTO> responseModel = new GenericResponseModel<CreateUserResponseDTO>() { Data = null, StatusCode = 400 };
            var id = Guid.NewGuid().ToString();
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = id,
                LastName = st.LastName,
                FirstName = st.FirstName,
                Email = st.Email,
                UserName = st.UserName,

            }, st.Password);

            responseModel.Data = new CreateUserResponseDTO { Succeeded = result.Succeeded };
            responseModel.StatusCode = result.Succeeded ? 200 : 400;
            if (!result.Succeeded)
            {
                responseModel.Data.Message = string.Join(" \n ", result.Errors.Select(error => $"{error.Code} - {error.Description}"));
            }

            AppUser appUser = await _userManager.FindByEmailAsync(st.Email);
            if (appUser == null)
            {
                appUser = await _userManager.FindByNameAsync(st.UserName);
            }
            if (appUser == null)
            {
                appUser = await _userManager.FindByIdAsync(id);
            }
            if (appUser != null)
            {
                await _userManager.AddToRoleAsync(appUser, "User");
            }

            return responseModel;
        }

        public async Task<GenericResponseModel<bool>> AssignRolesToUserAsync(string userid, string[] roles)
        {
            GenericResponseModel<bool> responseModel = new GenericResponseModel<bool>() { Data = false, StatusCode = 400 };
            var user = await _userManager.FindByIdAsync(userid);
            if (user == null)
            {
                return responseModel;
            }

            var getroles = await _userManager.GetRolesAsync(user);
            var roless = await _userManager.RemoveFromRolesAsync(user, getroles);
            if (!getroles.ToList().Contains("User"))
            {
                await _userManager.AddToRoleAsync(user, "User");

            }
            await _userManager.AddToRolesAsync(user, roles);

            responseModel.StatusCode = 200;
            responseModel.Data = true;

            return responseModel;

        }

        public async Task<GenericResponseModel<bool>> DeleteAsync(string idOrName)
        {
            GenericResponseModel<bool> responseModel = new GenericResponseModel<bool>() { Data = false, StatusCode = 400 };
            var user = await _userManager.FindByIdAsync(idOrName);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(idOrName);
            }
            if (user == null)
            {
                return responseModel;
            }
            IdentityResult res = await _userManager.DeleteAsync(user);

            if (res == IdentityResult.Success)
            {
                responseModel.Data = true;
                responseModel.StatusCode = 200;

            }

            return responseModel;
        }

        public async Task<GenericResponseModel<List<GetUserDTO>>> GetAllUserAsync()
        {
            GenericResponseModel<List<GetUserDTO>> responseModel = new GenericResponseModel<List<GetUserDTO>>();
            var data = await _userManager.Users.ToListAsync();

            if (data != null && data.Count > 0)
            {
                var users = _mapper.Map<List<GetUserDTO>>(data);
                responseModel.Data = users;
                responseModel.StatusCode = 200;
            }
            else
            {
                responseModel.StatusCode = 400;
                responseModel.Data = null;
            }

            return responseModel;
        }

        public async Task<GenericResponseModel<GetUserDTO>> GetById(string id)
        {
            GenericResponseModel<GetUserDTO> responseModel = new GenericResponseModel<GetUserDTO>();
            var data = await _userManager.FindByIdAsync(id);

            if (data != null)
            {
                var user = _mapper.Map<GetUserDTO>(data);
                responseModel.Data = user;
                responseModel.StatusCode = 200;
            }
            else
            {
                responseModel.StatusCode = 400;
                responseModel.Data = null;
            }
            return responseModel;
        }

        public async Task<GenericResponseModel<string[]>> GetRolesToUserAsync(string usernameOrId)
        {
            GenericResponseModel<string[]> response = new GenericResponseModel<string[]>() { Data = null, StatusCode = 400 };
            var user = await _userManager.FindByNameAsync(usernameOrId);
            if (user == null)
            {
                user = await _userManager.FindByIdAsync(usernameOrId);

            }
            if (user == null)
            {
                return response;
            }
            var data = await _userManager.GetRolesAsync(user);
            if (data != null && data.Count > 0)
            {
                response.StatusCode = 200;
                response.Data = data.ToArray();
            }

            return response;
        }

        public async Task<GenericResponseModel<bool>> UpdateAsync(UpdateUserDTO st)
        {
            GenericResponseModel<bool> responseModel = new GenericResponseModel<bool>() { Data = false, StatusCode = 400 };
            var user = await _userManager.FindByIdAsync(st.Id);

            if (user == null)
            {
                user = await _userManager.FindByNameAsync(st.UserName);
            }
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.Id = st.Id;
            user.FirstName = st.FirstName;
            user.LastName = st.LastName;
            user.UserName = st.UserName;
            user.BirthDay = st.BirthDay;
            user.Email = st.Email;
            IdentityResult res = await _userManager.UpdateAsync(user);

            if (res == IdentityResult.Success)
            {
                responseModel.Data = true;
                responseModel.StatusCode = 200;
            }

            return responseModel;
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime dateTime)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndTime = dateTime.AddMinutes(10);
                await _userManager.UpdateAsync(user);
            }

        }
    }
}
