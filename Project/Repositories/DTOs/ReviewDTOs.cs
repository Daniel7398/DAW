using Project.Entities;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories.DTOs
{
    public class ReviewDTOs
    {
        public int ReviewId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int Rating { get; set; }

        public string UserId { get; set; }


        public virtual User User { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }

        public ReviewDTOs(Review review)
        {
            this.ReviewId = review.ReviewId;
            this.Content = review.Content;
            this.Date = review.Date;
            this.ProductId = review.ProductId;
            this.Rating = review.Rating;
            this.UserId = review.UserId;
            this.User = review.User;
            this.UserId = review.UserId;

        }
    }
}
