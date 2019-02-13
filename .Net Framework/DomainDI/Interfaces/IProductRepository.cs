using System.Collections.Generic;
using System.Threading.Tasks;
using DomainDI.Entities;

namespace DomainDI.Interfaces
{
    public interface IProductRepository
    {
        #region Methods

        Task<IEnumerable<Products>> GetAllCategories();
        Task<Products> GetCategoryById(int id);

        Task<Products> CreateCategoryAsync(Products create);
        Task<bool> UpdateCategoryAsync(int id, Products update);
        Task<bool> DeleteCategoryAsync(int id);

        #endregion
    }
}
