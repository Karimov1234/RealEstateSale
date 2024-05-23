using Application.DTOs;
using Domain.Entities.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.IServices
{
    public interface ITokenHandler
    {
        Task<TokenDTO> CreateAccessToken(AppUser user);
        string CresteRefreshToken();
    }
}
