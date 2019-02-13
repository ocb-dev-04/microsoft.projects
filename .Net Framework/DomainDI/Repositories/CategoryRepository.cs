using DomainDI.Entities;
using DomainDI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        #region GetAll, GetById

        public async Task<IEnumerable<Categories>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<Categories> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region CRUD

        public async Task<Categories> CreateCategoryAsync(Categories create)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategoryAsync(int id, Categories update)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
