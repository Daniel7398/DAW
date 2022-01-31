using ASP_Project.Models.DTOs;
using ASP_Project.Models.Entities;
using ASP_Project.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        readonly ICartRepository _cartRepository;
        readonly IProductRepository _productRepository;

        public CartController(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        [Authorize]
        [HttpGet]
        [Route("SetCart/{oldUserId}/{newUserId}")]
        public int Get(int UserId1, int UserId2)
        {
            _cartRepository.CombineCarts(UserId1, UserId2);
            return _cartRepository.GetCartItemCount(UserId1);
        }

        [HttpGet("{userId}")]
        public async Task<List<CartItemDTO>> Get(int userId)
        {
            string cartid = _cartRepository.GetCartId(userId);
            return await Task.FromResult(_productRepository.GetProductsAvailableInCart(cartid)).ConfigureAwait(true);
        }

        [HttpPost]
        [Route("AddToCart/{userId}/{bookId}")]
        public int Post(int userId, int productId)
        {
            _cartRepository.AddProductToCart(userId, productId);
            return _cartRepository.GetCartItemCount(userId);
        }

        [HttpPut("{userId}/{productId}")]
        public int Put(int userId, int productId)
        {
            _cartRepository.DeleteOneCartItem(userId, productId);
            return _cartRepository.GetCartItemCount(userId);
        }

        [HttpDelete("{userId}/{productId}")]
        public int Delete(int userId, int productId)
        {
            _cartRepository.RemoveCartItem(userId, productId);
            return _cartRepository.GetCartItemCount(userId);
        }


        [HttpDelete("{userId}")]
        public int Delete(int userId)
        {
            return _cartRepository.ClearCart(userId);
        }

    }
}
