using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using DomainDI.DataContext;
using DomainDI.Interfaces;

namespace DomainDI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Properties

        private readonly DataContext.AppContext _appContext = new DataContext.AppContext();

        #endregion

        #region GetAll, GetById

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                var response = await _appContext.Products.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(nameof(ex));
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                var response = await _appContext.Products.FindAsync(id);
                return response;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(nameof(ex));
            }
        }

        #endregion

        #region CRUD

        public async Task<Product> CreateProductAsync(Product create)
        {
            try
            {
                var add = _appContext.Products.Add(create);
                if (add == null)
                    throw new ArgumentNullException(nameof(add));

                await _appContext.SaveChangesAsync();
                return add;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(nameof(ex));
            }
        }

        public async Task<bool> UpdateProductAsync(int id, Product update)
        {
            try
            {
                var confirm = await _appContext.Products.FindAsync(id);
                if (confirm == null)
                    return false;

                confirm = update;
                var add = _appContext.Products.Add(confirm);
                if (add == null)
                    return false;

                await _appContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(nameof(ex));
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var confirm = await _appContext.Products.FindAsync(id);
                if (confirm == null)
                    return false;

                _appContext.Products.Remove(confirm);
                await _appContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(nameof(ex));
            }
        }

        #endregion
    }
}
