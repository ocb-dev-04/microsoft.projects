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
        private readonly Products products;

        #endregion

        #region Construct

        public ProductsController(
            IProductsRepository productsRepository,
            ILogger<ProductsController> logger) : base(logger)
                => _productsRepository = productsRepository;

        #endregion

        #region GetAll GetById

        [HttpGet]
        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            _logger.LogInformation("Acces to all products");
            return await _productsRepository.GetAllProductsAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            _logger.LogInformation("Get for product with ID -----> {0}", id);
            var response = await _productsRepository.GetProductById(id);
            if (response == null)
            {
                _logger.LogInformation("Product with ID -----> {0} not found!", id);
                return NotFound();
            }

            _logger.LogInformation("Product found succesful!");
            return Ok(response);
        }

        #endregion

        #region CRUD
        
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Products create)
        {
            _logger.LogInformation("Create a new product: {0}", create);
            var response = await _productsRepository.CreateProductAsync(create);
            if(response == null)
            {
                _logger.LogInformation("Some error ocurred while create the products");
                return NotFound("Some error ocurred");
            }

            _logger.LogInformation("Product {0} create succesful");
            return Ok(response);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Products update)
        {
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
        }
        
        #endregion
    }
}
