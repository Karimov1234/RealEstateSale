using Application.Abstractions;
using Application.Abstractions.IServices;
using Application.DTOs;
using Application.DTOs.AgentDtos;
using Application.Extensions;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        public readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;

        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var data = await _agentService.GetAllAsync();


            return StatusCode(data.StatusCode, data);
        }
       
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _agentService.GetByIdAsync(id);
            return StatusCode(data.StatusCode, data);
        }

       

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ValidateModel]
        public async Task<IActionResult> Update(CreateUpdateAgentDTO mdl, int id)
        {
            var data = await _agentService.UpdateAsync(mdl, id);
            return StatusCode(data.StatusCode, data);

        }
       

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Delete(int agid)
        {
            var data = await _agentService.DeleteAsync(agid);
            return StatusCode(data.StatusCode, data);

        }
       
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ValidateModel]
        public async Task<IActionResult> Create(CreateUpdateAgentDTO mdl)
        {
            var data = await _agentService.AddAsync(mdl);
            return StatusCode(data.StatusCode, data);

        }
       
        [HttpGet("by-property/{propertyId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetAgentByPropertyId(int propertyId)
        {
            var data = await _agentService.GetAgentByPropertyId(propertyId);
            return StatusCode(data.StatusCode, data);
        }
       
    }
}
