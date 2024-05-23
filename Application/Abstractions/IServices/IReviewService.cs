using Application.DTOs.ReviewDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.IServices
{
    public interface IReviewService
    {
        public Task<GenericResponseModel<List<ReviewGetDTO>>> GetAllReviews();
        public Task<GenericResponseModel<ReviewGetDTO>> GetReviewById(int id);
        public Task<GenericResponseModel<List<ReviewGetDTO>>> GetAllReviewsByUserId(string userId);
        public Task<GenericResponseModel<List<ReviewGetDTO>>> GetAllReviewsByPropertyId(int propertyId);
        public Task<GenericResponseModel<ReviewCreateDTO>> CreateReview(ReviewCreateDTO dto);
        public Task<GenericResponseModel<bool>> DeleteReview(int id);
        public Task<GenericResponseModel<bool>> UpdateReview(ReviewUpdateDTO model);
    }
}
