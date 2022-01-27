using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models.Entities;
using Project.Repositories.DTOs;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _repository;

        public ReviewController(IReviewRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var rev = await _repository.GetAllReviews();

            var reviewsToReturn = new List<ReviewDTOs>();

            foreach (var revi in rev)
            {
                reviewsToReturn.Add(new ReviewDTOs(revi));
            }



            return Ok(reviewsToReturn);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetReviewById(int id)
        {
            var review = await _repository.GetByIdAsync(id);

            return Ok(new ReviewDTOs(review));
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _repository.GetByIdAsync(id);

            if (review == null)
            {
                return NotFound("Category does not exist!");
            }

            _repository.Delete(review);

            await _repository.SaveAsync();

            return NoContent();
        }


        [HttpPost]

        public async Task<IActionResult> CreateReview(CreateReviewDTOs dto)
        {
            Review newReview = new Review();

            newReview.ReviewId = dto.ReviewId;
            newReview.Content = dto.Content;
            newReview.Date = dto.Date;
            newReview.ProductId = dto.ProductId;
            newReview.Rating = dto.Rating;
            newReview.UserId = dto.UserId;
            newReview.User= dto.User;
            newReview.ProductReviews = dto.ProductReviews;

            _repository.Create(newReview);

            await _repository.SaveAsync();

            return Ok(new ReviewDTOs(newReview));

        }
    }
}
