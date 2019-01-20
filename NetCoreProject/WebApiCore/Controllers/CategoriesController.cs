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
    public class CategoriesController : DIController
    {
        #region Properties

        private readonly ICategoriesRepository _categoriesRepository;

        #endregion

        #region Contruct

        public CategoriesController(
            ICategoriesRepository categoriesRepository,
            ILogger<CategoriesController> logger) : base(logger)
        => _categoriesRepository = categoriesRepository;

        #endregion

        #region GetAll GetById

        [HttpGet]
        public async Task<IEnumerable<Categories>> GetAllCategories()
        {
            _logger.LogInformation("Acces to all categories");
            var response = await _categoriesRepository.GetAllCategoriesAsync();
            if (response == null)
            {
                _logger.LogInformation("Some error ocurred");
                return response;
            }

            _logger.LogInformation("All categories was show");
            return response;
        }
        
        [HttpGet("{id}", Name = "categoriesCreated")]
        public async Task<Categories> GetCategoryById(int id)
        {
            _logger.LogInformation("Acces to category with ID: {0}", id);
            var response = await _categoriesRepository.GetCategoryById(id);
            if (response == null)
            {
                _logger.LogInformation("Some error ocurred");
                return response;
            }

            _logger.LogInformation("Category with ID: {0} showed", id);
            return response;
        }

        #endregion

        #region CRUD
        
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Categories create)
        {
            _logger.LogInformation("Try create a new category with: {0}", create);
            if(ModelState.IsValid)
            {
                var response = await _categoriesRepository.CreateCategoryAsync(create);
                if(response == false)
                {
                    _logger.LogInformation("Some error ocurred while create the new category");
                    return NotFound(create);
                }

                _logger.LogInformation("Category create succesful");
                return new CreatedAtRouteResult("categoriesCreated", new { id = create.Id }, create);
            }

            _logger.LogInformation("ModelState wrong");
            return BadRequest(ModelState);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] Categories update)
        {
            _logger.LogInformation("Try to update Category with id {0} and info is: {1}", id, update);
            if(ModelState.IsValid && id == update.Id)
            {
                var response = await _categoriesRepository.UpdateCategoryAsync(id, update);
                if(response == false)
                {
                    _logger.LogInformation("Some error ocurred while update Category: {0}", update);
                    return NotFound(update);
                }

                _logger.LogInformation("Category update succesful");
                return Ok(update);
            }

            _logger.LogInformation("ModelSate is wrong");
            return BadRequest(ModelState);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var response = await _categoriesRepository.DeleteCategoryAsync(id);
            if(response == false)
            {
                _logger.LogInformation("A error ocurred while delete category with ID: {0}", id);
                return NotFound(id);
            }

            _logger.LogInformation("Category with Id: {0} deleted", id);
            return Ok();
        }

        #endregion
    }
}
