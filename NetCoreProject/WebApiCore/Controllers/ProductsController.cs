using System.Collections.Generic;
using System.Threading.Tasks;
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

        #region GetAll GetById

        [HttpGet]
        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            _logger.LogInformation("Acces to all products");
            return await _productsRepository.GetAllProductsAsync();
        }
        
        [HttpGet("{id}", Name = "productCreated")]
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
            if(ModelState.IsValid)
            {
                _logger.LogInformation("Create a new product: {0}", create);
                create.Create = System.DateTime.Now;
                var response = await _productsRepository.CreateProductAsync(create);
                if (response == false)
                {
                    _logger.LogInformation("Some error ocurred while create the products");
                    return NotFound("Some error ocurred");
                }

                _logger.LogInformation("Product {0} create succesful", create);
                return new CreatedAtRouteResult("productCreated", new { id= create.Id }, create);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] Products update)
        {
            if(ModelState.IsValid && id == update.Id)
            {
                _logger.LogInformation("Update a product: {0}", update);
                var response = await _productsRepository.UpdateProductAsync(id, update);
                if (response == false)
                {
                    _logger.LogInformation("Some error ocurred while update the products");
                    return NotFound("Some error ocurred");
                }

                _logger.LogInformation("Product {0} update succesful", update);
                return Ok(update);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            _logger.LogInformation("Try to delete product with ID: {0}", id);
            var response = await _productsRepository.DeleteProductAsync(id);
            if(response == false)
            {
                _logger.LogInformation("Ups, product can't delete");
                return NotFound();
            }

            _logger.LogInformation("Product delete succesful");
            return Ok();
        }
        
        #endregion
    }
}
