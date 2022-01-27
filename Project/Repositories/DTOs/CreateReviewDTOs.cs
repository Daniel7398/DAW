using Project.Entities;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories.DTOs
{
    public class CreateReviewDTOs
    {
        public int ReviewId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int Rating { get; set; }

        public string UserId { get; set; }


        public virtual User User { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
    }
}
