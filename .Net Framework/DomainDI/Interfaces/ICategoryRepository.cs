using System.Collections.Generic;
using System.Threading.Tasks;
using DomainDI.Entities;

namespace DomainDI.Interfaces
{
    public interface ICategoryRepository
    {
        #region Methods

        Task<IEnumerable<Categories>> GetAllCategories();
        Task<Categories> GetCategoryById(int id);

        Task<Categories> CreateCategoryAsync(Categories create);
        Task<bool> UpdateCategoryAsync(int id, Categories update);
        Task<bool> DeleteCategoryAsync(int id);
        
        #endregion
    }
}
