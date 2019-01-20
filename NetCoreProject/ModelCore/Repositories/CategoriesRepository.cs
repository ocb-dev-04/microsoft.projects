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
    public class CategoriesRepository : AllDIRepository, ICategoriesRepository
    {
        #region Properties

        
        
        #endregion

        #region Construct

        public CategoriesRepository(
            AppContext appContext,
            ILogger<CategoriesRepository> logger):base(appContext, logger)
        {}

        #endregion

        #region GetAll, GetById

        //get all
        public async Task<ICollection<Categories>> GetAllCategoriesAsync()
            => await _appContext.Categories.ToListAsync();

        //get by id
        public async Task<Categories> GetCategoryById(int id)
            => await _appContext.Categories.FindAsync(id);

        #endregion

        #region CRUD

        //create
        public async Task<bool> CreateCategoryAsync(Categories categories)
        {
            var responde = await _appContext.Categories.AddAsync(categories);
            if (responde == null)
                return false;

            await _appContext.SaveChangesAsync();
            return true;
        }

        //update
        public async Task<bool> UpdateCategoryAsync(int id, Categories categories)
        {
            var update = await _appContext.Categories.FindAsync(id);
            if (update == null)
                return false;

            _appContext.Entry(update).State = EntityState.Modified;
            await _appContext.SaveChangesAsync();
            return true;
        }

        //delete
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var delete = await _appContext.Categories.FindAsync(id);
            var response = _appContext.Categories.Remove(delete);
            if (response == null)
                return false;

            await _appContext.SaveChangesAsync();
            return true;
        }

        #endregion
    }
}
