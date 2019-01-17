using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModelCore.Data;
using ModelCore.Entities;
using ModelCore.Interfaces;
using ModelCore.Repositories.DIRepository;

namespace ModelCore.Repositories
{
    public class ProductsRepository : AllDIRepository, IProductsRepository
    {
        #region Properties



        #endregion

        #region Construct

        public ProductsRepository(
            AppContext appContext,
            ILogger<ProductsRepository> logger) : base(appContext, logger)
        { }

        #endregion

        #region GetAll, GetById

        //get all
        public async Task<ICollection<Products>> GetAllProductsAsync()
            => await _appContext.Products.ToListAsync();

        //get by id
        public async Task<Products> GetProductById(int id)
            => await _appContext.Products.FindAsync(id);

        #endregion

        #region CRUD

        //create
        public async Task CreateProductAsync(Products create)
        {
            await _appContext.Products.AddAsync(create);
            await _appContext.SaveChangesAsync();
        }

        //update
        public async Task<bool> UpdateProductAsync(int id, Products updateP)
        {
            var update = await _appContext.Products.FindAsync(id);
            if (update == null)
                return false;

            _appContext.Entry(update).State = EntityState.Modified;
            await _appContext.SaveChangesAsync();
            return true;
        }

        //delete
        public async Task DeleteProductAsync(int id)
        {
            var delete = await _appContext.Products.FindAsync(id);
            _appContext.Products.Remove(delete);
            await _appContext.SaveChangesAsync();
        }

        #endregion
    }
}
