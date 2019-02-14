using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using DomainDI.DataContext;
using DomainDI.Interfaces;

namespace DomainDI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        #region Properties

        private readonly DataContext.AppContext _appContext = new DataContext.AppContext();

        #endregion

        #region GetAll, GetById

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            try
            {
                var response = await _appContext.Categories.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(nameof(ex));
            }
        }

        public async Task<Category> GetCategoryById(int id)
        {
            try
            {
                var response = await _appContext.Categories.FindAsync(id);
                return response;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(nameof(ex));
            }
        }

        #endregion

        #region CRUD

        public async Task<Category> CreateCategoryAsync(Category create)
        {
            try
            {
                var add = _appContext.Categories.Add(create);
                if(add==null)
                    throw new ArgumentNullException(nameof(add));

                await _appContext.SaveChangesAsync();
                return add;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(nameof(ex));
            }
        }

        public async Task<bool> UpdateCategoryAsync(int id, Category update)
        {
            try
            {
                var confirm = await _appContext.Categories.FindAsync(id);
                if (confirm == null)
                    return false;

                confirm = update;
                var add = _appContext.Categories.Add(confirm);
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

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                var confirm = await _appContext.Categories.FindAsync(id);
                if (confirm == null)
                    return false;

                _appContext.Categories.Remove(confirm);
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
