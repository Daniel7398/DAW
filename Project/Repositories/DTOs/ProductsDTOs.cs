using Project.Entities;
using Project.Models.Entities;
using Project.Repositories.CategoryRepository;
using Project.Repositories.ProductRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories.DTOs
{
    public class ProductsDTOs
    {
        private readonly IProductRepository _repository;

        public ProductsDTOs(IProductRepository repository)
        {
            _repository = repository;
        }

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


        public ProductsDTOs(Product product)
        {
            this.Id = product.Id;
            this.Nume = product.Nume;
            this.Descriere = product.Descriere;
            this.Pret = product.Pret;
            this.Poza = product.Poza;
            this.CategoryId = product.CategoryId;
            this.Rating = _repository.CalculateRating(product);
            this.Date = product.Date;
            this.UserId = product.UserId;
            this.User = product.User;
            this.Category = product.Category;
            this.ProductReviews = new List<ProductReview>();
            this.Quantities = new List<Quantity>();
        }
    }
}
