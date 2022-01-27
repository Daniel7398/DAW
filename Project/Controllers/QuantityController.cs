using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models.Entities;
using Project.Repositories.DTOs;
using Project.Repositories.QuantityRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuantityController : ControllerBase
    {
        private readonly IQuantityRepository _repository;

        public QuantityController(IQuantityRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuantities()
        {
            var quant= await _repository.GetAllQuantities();

            var quantitiesToReturn = new List<QuantitiesDTOs>();

            foreach (var qua in quant)
            {
                quantitiesToReturn.Add(new QuantitiesDTOs(qua));
            }


            return Ok(quantitiesToReturn);
        }


        [HttpPost]

        public async Task<IActionResult> CreateQuantity(CreateQuantityDTOs dto)
        {
            Quantity newQuantity = new Quantity();

           

            _repository.Create(newQuantity);

            await _repository.SaveAsync();

            return Ok(new QuantitiesDTOs(newQuantity));

        }
    }
}
