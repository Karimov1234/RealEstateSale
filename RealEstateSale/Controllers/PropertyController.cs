using Application.Abstractions.IServices;
using Application.DTOs.AgentDtos;
using Application.DTOs.PropertyDtos;
using Application.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        public readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;

        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetAll()
        {

            var data = await _propertyService.GetAllAsync();


            return StatusCode(data.StatusCode, data);
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _propertyService.GetByIdAsync(id);
            return StatusCode(data.StatusCode, data);
        }



        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ValidateModel]
        public async Task<IActionResult> Update(UpdatePropertyDTO mdl, int id)
        {
            var data = await _propertyService.UpdateAsync(mdl, id);
            return StatusCode(data.StatusCode, data);

        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _propertyService.DeleteAsync(id);
            return StatusCode(data.StatusCode, data);

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ValidateModel]
        public async Task<IActionResult> Create(CreatePropertyDTO mdl)
        {
            var data = await _propertyService.AddAsync(mdl);
            return StatusCode(data.StatusCode, data);

        }
        [HttpGet("by-owner/{ownerId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetProtertyByOwnerId(int ownerId)
        {
            var data = await _propertyService.GetProtertyByOwnerId(ownerId);
            return StatusCode(data.StatusCode, data);
        }
        [HttpGet("by-agent/{agentId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetProtertyByAgentId(int agentId)
        {
            var data = await _propertyService.GetProtertyByAgentId(agentId);
            return StatusCode(data.StatusCode, data);
        }
        [HttpGet("by-region/{regionId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetProtertyByRegionOfCityId(int regionId)
        {
            var data = await _propertyService.GetProtertyByRegionOfCityId(regionId);
            return StatusCode(data.StatusCode, data);
        }
    }
}
