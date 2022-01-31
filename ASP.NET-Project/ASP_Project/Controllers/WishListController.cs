using ASP_Project.Models.Entities;
using ASP_Project.Repositories;
using ASP_Project.Services.UserServices;
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
    public class WishListController : ControllerBase
    {
        readonly IWishListRepository _wishListRepository;
        readonly IProductRepository _productRepository;
        readonly IUserService _userService;

        public WishListController(IWishListRepository wishListRepository, IProductRepository productRepository, IUserService userService)
        {
            _wishListRepository= wishListRepository;
            _productRepository = productRepository;
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<List<Product>> Get(int userId)
        {
            return await Task.FromResult(GetUserWishList(userId)).ConfigureAwait(true);
        }


        [Authorize]
        [HttpPost]
        [Route("ToggleWishList/{userId}/{productId}")]
        public async Task<List<Product>> Post(int userId, int productId)
        {
            _wishListRepository.ToggleWishListItem(userId, productId);
            return await Task.FromResult(GetUserWishList(userId)).ConfigureAwait(true);
        }


        [Authorize]
        [HttpDelete("{userId}")]
        public int Delete(int userId)
        {
            return _wishListRepository.ClearWishList(userId);
        }

        List<Product> GetUserWishList(int userId)
        {
            string WishListid = _wishListRepository.GetWishListId(userId);
            return _productRepository.GetProductsAvailableInWishList(WishListid);
        }
    }
}
