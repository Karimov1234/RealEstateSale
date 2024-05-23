using Application.Abstractions;
using Application.Abstractions.IServices;
using Application.DTOs;
using Domain.Entities.Identities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Implementations.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IUserService _userService;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }

        public async Task<GenericResponseModel<TokenDTO>> LoginAsync(string usernameOrEmail, string password)
        {
            GenericResponseModel<TokenDTO> responseModel = new GenericResponseModel<TokenDTO>() { Data = null, StatusCode = 404 };
            var user = await _userManager.FindByEmailAsync(usernameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(usernameOrEmail);
            }
            var signinres = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (signinres.Succeeded)
            {
                if (user != null)
                {
                    var token = await _tokenHandler.CreateAccessToken(user);
                    await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expired);

                    responseModel.StatusCode = 200;
                    responseModel.Data = token;

                }

            }

            return responseModel;
        }

        public async Task<GenericResponseModel<TokenDTO>> CreateNewResreshTokenAsync(string refreshToken)
        {
            GenericResponseModel<TokenDTO> responseModel = new GenericResponseModel<TokenDTO>() { Data = null, StatusCode = 404 };
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);

            if (user != null && user?.RefreshTokenEndTime > DateTime.UtcNow)
            {
                var token = await _tokenHandler.CreateAccessToken(user);

                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expired);

                responseModel.StatusCode = 200;
                responseModel.Data = token;


            }
            else
            {
                responseModel.Data = null;
                responseModel.StatusCode = 401;
            }
            return responseModel;

        }

        public async Task<GenericResponseModel<bool>> LogOutAsync(string userNameOrEmail)
        {
            GenericResponseModel<bool> responseModel = new GenericResponseModel<bool>() { Data = false, StatusCode = 404 };
            var user = await _userManager.FindByEmailAsync(userNameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(userNameOrEmail);

            }
            if (user != null)
            {
                user.RefreshToken = null;
                user.RefreshTokenEndTime = null;
                var res = await _userManager.UpdateAsync(user);
                await _signInManager.SignOutAsync();
                if (res.Succeeded)
                {
                    responseModel.Data = true;
                    responseModel.StatusCode = 200;
                }

            }
            else
            {
                responseModel.Data = false;
                responseModel.StatusCode = 401;
            }

            return responseModel;
        }

        public async Task<GenericResponseModel<bool>> PasswordResetAsync(string email, string curPas, string newPas)
        {
            GenericResponseModel<bool> responseModel = new GenericResponseModel<bool>() { Data = false, StatusCode = 400 };
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, curPas, false);
                if (result.Succeeded)
                {
                    var changePassword = await _userManager.ChangePasswordAsync(user, curPas, newPas);

                    if (changePassword.Succeeded)
                    {
                        responseModel.Data = true;
                        responseModel.StatusCode = 200;
                    }
                }
            }
            return responseModel;
        }

        
    }
}
