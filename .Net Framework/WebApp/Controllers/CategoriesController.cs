using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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
        
        public async Task<ActionResult> Index()
        {
            var list = await _categoryRepository.GetAllCategories();
            return View(list);
        }

    }
}