using Application.Abstractions.IServices;
using Application.DTOs.ReviewDtos;
using Application.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RealEstateSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _reviewService.GetAllReviews();
            return StatusCode(data.StatusCode, data);
        }
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var data = await _reviewService.GetReviewById(id);
            return StatusCode(data.StatusCode, data);
        }
        [HttpGet("by-property/{propertyId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetAllReviewsByPropertyId(int propertyId)
        {
            var data = await _reviewService.GetAllReviewsByPropertyId(propertyId);
            return StatusCode(data.StatusCode, data);
        }
        [HttpGet("by-user/{userId}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetAllReviewsByUserId(string userId)
        {
            var data = await _reviewService.GetAllReviewsByUserId(userId);
            return StatusCode(data.StatusCode, data);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ValidateModel]
        public async Task<IActionResult> Create(ReviewCreateDTO dto)
        {
            var data = await _reviewService.CreateReview(dto);
            return StatusCode(data.StatusCode, data);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ValidateModel]
        public async Task<IActionResult> Update(ReviewUpdateDTO dto)
        {
            var data = await _reviewService.UpdateReview(dto);
            return StatusCode(data.StatusCode, data);
        }
        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _reviewService.DeleteReview(id);
            return StatusCode(data.StatusCode, data);
        }
    }
}
