using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models.Entities;
using Project.Repositories.DTOs;
using Project.Repositories.ProductRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var prod = _repository.GetAllProducts();

            var productsToReturn = new List<ProductsDTOs>();

            foreach (var pr in await prod)
            {
                productsToReturn.Add(new ProductsDTOs(pr));
            }


            return Ok(productsToReturn);
        }


        [HttpPost]

        public async Task<IActionResult> CreateProduct(CreateProductDTOs dto)
        {
            Product newProduct= new Product();

            newProduct.Id = dto.Id;
            newProduct.Nume = dto.Nume;
            newProduct.Descriere = dto.Descriere;
            newProduct.Pret = dto.Pret;
            newProduct.Poza = dto.Poza;
            newProduct.CategoryId = dto.CategoryId;
            newProduct.Date = dto.Date;
            newProduct.UserId = dto.UserId;
            newProduct.User = dto.User;
            newProduct.Category = dto.Category;
            newProduct.ProductReviews = dto.ProductReviews;
            newProduct.Quantities = dto.Quantities;
            newProduct.Rating = dto.Rating;


            _repository.Create(newProduct);

            await _repository.SaveAsync();

            return Ok(new ProductsDTOs (newProduct ));

        }
    }
}
