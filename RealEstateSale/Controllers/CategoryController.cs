using Application.Abstractions.IServices;
using Application.DTOs.AgentDtos;
using Application.DTOs.CategoryDtos;
using Application.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var data = await _categoryService.GetAllAsync();


            return StatusCode(data.StatusCode, data);
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _categoryService.GetByIdAsync(id);
            return StatusCode(data.StatusCode, data);
        }



        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Update(CreateUpdateCategoryDTO mdl, int id)
        {
            var data = await _categoryService.UpdateAsync(mdl, id);
            return StatusCode(data.StatusCode, data);

        }


        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Delete(int agid)
        {
            var data = await _categoryService.DeleteAsync(agid);
            return StatusCode(data.StatusCode, data);

        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Create(CreateUpdateCategoryDTO mdl)
        {
            var data = await _categoryService.AddAsync(mdl);
            return StatusCode(data.StatusCode, data);

        }

      

    }
}
