using System.Threading.Tasks;
using System.Web.Mvc;
using DomainDI.DataContext;
using DomainDI.Interfaces;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        #region Properties

        private readonly IProductRepository _productRepository;

        #endregion

        #region Construct

        public ProductsController(IProductRepository productRepository)
            => _productRepository = productRepository;

        #endregion

        #region GeAll, GetById

        // list products
        public async Task<ActionResult> ListProducts()
        {
            var response = await _productRepository.GetAllProducts();
            return View(response);
        }

        //  show info of especific product
        public async Task<ActionResult> DetailsProduct(int id)
        {
            var response = await _productRepository.GetProductById(id);
            return View(response);
        }

        #endregion

        #region CRUD

        #region Create

        //  show the form fot complete and then received
        public ActionResult CreateProduct()
        {
            return View();
        }

        // create a new product
        [HttpPost]
        public async Task<ActionResult> CreateNewProduct(Product create)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var response = await _productRepository.CreateProductAsync(create);
                if (response == null)
                    return View();

                return RedirectToAction("ListProducts");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Update / Edit

        //  update product with select id
        public ActionResult Update(int id)
        {
            return View();
        }

        //  update product
        [HttpPost]
        public async Task<ActionResult> UpdateProduct(int id, Product update)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var response = await _productRepository.UpdateProductAsync(id, update);
                if (response == false)
                    return View();

                return RedirectToAction("ListProducts");
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
        public async Task<ActionResult> Delete(int id, Product delete)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                var response = await _productRepository.DeleteProductAsync(id);
                if (response == false)
                    return View("An error ocurred while delete this item");

                return RedirectToAction("ListProducts");
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