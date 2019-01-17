using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelCore.Entities;
using ModelCore.Interfaces;
using WebApiCore.Controllers.AllController;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : DIController
    {
        #region Properties

        private readonly IProductsRepository _productsRepository;

        #endregion

        #region Construct

        public ProductsController(
            IProductsRepository productsRepository,
            ILogger<ProductsController> logger) : base(logger)
                => _productsRepository = productsRepository;

        #endregion
        
        [HttpGet]
        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            _logger.LogInformation("Acces to all products");
            return await _productsRepository.GetAllProductsAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            _logger.LogInformation("Get for product with id: ", id);
            var response = await _productsRepository.GetProductById(id);
            if(response == null)
            {
                _logger.LogInformation("Ups, product not found!");
                return NotFound("Ups, product not found!");
            }

            _logger.LogInformation("Product found succesful!");
            return Ok(response);
        }

        // POST: api/Products
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
