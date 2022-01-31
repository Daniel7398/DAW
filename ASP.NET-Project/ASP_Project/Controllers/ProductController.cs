using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ASP_Project.Repositories;
using ASP_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ASP_Project.Models.Entities;
using ASP_Project.Models.Constants;

namespace ASP_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IWebHostEnvironment _hostingEnvironment;
        readonly IProductRepository _productRepository;
        readonly IConfiguration _config;
        readonly string coverImage = string.Empty;


        public ProductController(IConfiguration config, IWebHostEnvironment hostingEnvironment, IProductRepository productRepository)
        {
            _config = config;
            _productRepository = productRepository;
            _hostingEnvironment = hostingEnvironment;
            coverImage = Path.Combine(_hostingEnvironment.WebRootPath, "Upload");
            if (!Directory.Exists(coverImage))
            {
                Directory.CreateDirectory(coverImage);
            }
        }

        [HttpGet]
        public async Task<List<Product>> Get()
        {
            return await Task.FromResult(_productRepository.GetAllProducts()).ConfigureAwait(true);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = _productRepository.GetProductData(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("GetCategoriesList")]
        public async Task<IEnumerable<Categories>> CategoryDetails()
        {
            return await Task.FromResult(_productRepository.GetCategories()).ConfigureAwait(true);
        }

        [HttpGet]
        [Route("GetSimilarProducts/{productId}")]
        public async Task<List<Product>> SimilarProducts(int productId)
        {
            return await Task.FromResult(_productRepository.GetSimilarProducts(productId)).ConfigureAwait(true);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public int Post()
        {
            Product product = JsonConvert.DeserializeObject<Product>(Request.Form["productFormData"].ToString());

            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];

                if (file.Length > 0)
                {
                    string fileName = Guid.NewGuid() + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(coverImage, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    product.Cover = fileName;
                }
            }
            else
            {
                product.Cover = _config["DefaultCoverImageFile"];
            }
            return _productRepository.AddProduct(product);
        }
    }
}
