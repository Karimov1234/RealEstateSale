using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.IServices
{
    public interface IAuthService
    {
        public Task<GenericResponseModel<TokenDTO>> LoginAsync(string usernameOrEmail, string password);
        public Task<GenericResponseModel<TokenDTO>> CreateNewResreshTokenAsync(string refreshToken);
        public Task<GenericResponseModel<bool>> LogOutAsync(string userNameOrEmail);
        public Task<GenericResponseModel<bool>> PasswordResetAsync(string email, string curPas, string newPas);
     

    }
}
