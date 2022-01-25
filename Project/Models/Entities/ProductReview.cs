using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Entities
{
    public class ProductReview
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int ReviewId { get; set; }

        public Review Review { get; set; }

    }
}
