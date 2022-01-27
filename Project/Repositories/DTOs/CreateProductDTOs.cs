using Project.Entities;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories.DTOs
{
    public class CreateProductDTOs
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Descriere { get; set; }
        public float Pret { get; set; }

        public string Poza { get; set; }

        public int CategoryId { get; set; }

        public float Rating { get; set; }

        public DateTime Date { get; set; }
        public string UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<ProductReview> ProductReviews { get; set; }

        public virtual List<Quantity> Quantities { get; set; }
    }
}
