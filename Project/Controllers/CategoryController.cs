using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models.Entities;
using Project.Repositories.CategoryRepository;
using Project.Repositories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categ = await _repository.GetAllCategories();

            var categoriesToReturn = new List<CategoriesDTOs>();

            foreach (var cat in categ)
            {
                categoriesToReturn.Add(new CategoriesDTOs(cat));
            }


            return Ok(categoriesToReturn);
        }


        [HttpPost]

        public async Task<IActionResult> CreateCategory(CreateCategoryDTOs dto)
        {
            Category newCategory = new Category();

            newCategory.CategoryId = dto.CategoryId;
            newCategory.CategoryName = dto.CategoryName;
            newCategory.Products = dto.Products;

            _repository.Create(newCategory);

            await _repository.SaveAsync();

            return Ok(new CategoriesDTOs (newCategory ));

        }

    }
}
