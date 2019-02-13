using DomainDI.Entities;
using DomainDI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region GetAll, GetById

        public async Task<IEnumerable<Products>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public async Task<Products> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region CRUD

        public async Task<Products> CreateCategoryAsync(Products create)
        {
            throw new NotImplementedException();
        }
        
        public async Task<bool> UpdateCategoryAsync(int id, Products update)
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
