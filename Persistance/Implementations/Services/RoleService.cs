using Application.Abstractions.IServices;
using Application.Abstractions;
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
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleService;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleService = roleManager;

        }

        public async Task<GenericResponseModel<bool>> AddRole(string name)
        {
            GenericResponseModel<bool> responseModel = new GenericResponseModel<bool>()
            {
                Data = true,
                StatusCode = 400
            };
            string id = Guid.NewGuid().ToString();
            IdentityResult result = await _roleService.CreateAsync(new() { Id = id, Name = name });
            if (result.Succeeded)
            {
                responseModel.Data = true;
                responseModel.StatusCode = 200;
            }
            return responseModel;



        }

        public async Task<GenericResponseModel<bool>> DeleteRole(string id)
        {
            GenericResponseModel<bool> responseModel = new GenericResponseModel<bool>() { Data = false, StatusCode = 400 };
            var data = await _roleService.FindByIdAsync(id);
            if (data != null)
            {
                IdentityResult res = await _roleService.DeleteAsync(data);
                if (res.Succeeded)
                {
                    responseModel.StatusCode = 200;
                    responseModel.Data = true;
                }

            }
            return responseModel;

        }

        public async Task<GenericResponseModel<object>> GetAllRoles()
        {
            GenericResponseModel<object> responseModel = new GenericResponseModel<object>() { Data = null, StatusCode = 400 };
            var data = await _roleService.Roles.ToListAsync();
            if (data != null)
            {
                responseModel.Data = data;
                responseModel.StatusCode = 200;
            }
            return responseModel;
        }

        public async Task<GenericResponseModel<object>> GetRolesById(string id)
        {
            GenericResponseModel<object> responseModel = new GenericResponseModel<object>() { Data = null, StatusCode = 400 };
            var data = await _roleService.FindByIdAsync(id);
            if (data != null)
            {
                responseModel.Data = data;
                responseModel.StatusCode = 200;
            }
            return responseModel;

        }

        public async Task<GenericResponseModel<bool>> UpdateAsync(string id, string name)
        {
            GenericResponseModel<bool> responseModel = new GenericResponseModel<bool>() { Data = false, StatusCode = 400 };
            var data = await _roleService.FindByIdAsync(id);
            if (data != null)
            {
                data.Name = name;
                IdentityResult res = await _roleService.UpdateAsync(data);
                if (res.Succeeded)
                {
                    responseModel.StatusCode = 200;
                    responseModel.Data = true;
                }

            }
            return responseModel;
        }

    }
}
