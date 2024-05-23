using Application.Abstractions.IServices;
using Application.DTOs.AgentDtos;
using Application.DTOs.OwnerDtos;
using Application.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        public readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;

        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetAll()
        {

            var data = await _ownerService.GetAllAsync();


            return StatusCode(data.StatusCode, data);
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _ownerService.GetByIdAsync(id);
            return StatusCode(data.StatusCode, data);
        }



        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ValidateModel]
        public async Task<IActionResult> Update(CreateUpdateOwnerDTO mdl, int id)
        {
            var data = await _ownerService.UpdateAsync(mdl, id);
            return StatusCode(data.StatusCode, data);

        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Delete(int agid)
        {
            var data = await _ownerService.DeleteAsync(agid);
            return StatusCode(data.StatusCode, data);

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ValidateModel]
        public async Task<IActionResult> Add(CreateUpdateOwnerDTO mdl)
        {
            var data = await _ownerService.AddAsync(mdl);
            return StatusCode(data.StatusCode, data);

        }
        [HttpGet("by-property/{propertyId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetOwnerByPropertyId(int propertyId)
        {
            var data = await _ownerService.GetOwnerByPropertyId( propertyId);
            return StatusCode(data.StatusCode, data);
        }

    }
}
