using System.Threading.Tasks;
using System.Web.Mvc;
using DomainDI.DataContext;
using DomainDI.Interfaces;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        #region Properties

        private readonly ICategoryRepository _categoryRepository;

        #endregion

        #region Construct

        public CategoriesController(ICategoryRepository categoryRepository)
            => _categoryRepository = categoryRepository;

        #endregion

        #region GeAll, GetById

        // list categories
        public async Task<ActionResult> ListCategories()
        {
            var response = await _categoryRepository.GetAllCategories();
            return View(response);
        }

        //  show info of especific category
        public async Task<ActionResult> DetailsCategory(int id)
        {
            var response = await _categoryRepository.GetCategoryById(id);
            return View(response);
        }

        #endregion

        #region CRUD

        #region Create

        //  show the form fot complete and then received
        public ActionResult CreateCategory()
        {
            return View();
        }

        // create a new category
        [HttpPost]
        public async Task<ActionResult> CreateNewCategory(Category create)
        {
            if(!ModelState.IsValid)
                return View();

            try
            {
                var response = await _categoryRepository.CreateCategoryAsync(create);
                if (response == null)
                    return View();

                return RedirectToAction("ListCategories");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Update / Edit

        //  update category with select id
        public ActionResult Update(int id)
        {
            return View();
        }

        //  update category
        [HttpPost]
        public async Task<ActionResult> UpdateCategory(int id, Category update)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var response = await _categoryRepository.UpdateCategoryAsync(id, update);
                if (response == false)
                    return View();

                return RedirectToAction("ListCategories");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Delete
        
        // receive delete id
        public ActionResult Delete(int id)
        {
            return View();
        }

        // delete item with id
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Category delete)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var response = await _categoryRepository.DeleteCategoryAsync(id);
                if (response == false)
                    return View("An error ocurred while delete this item");

                return RedirectToAction("ListCategories");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #endregion
    }
}