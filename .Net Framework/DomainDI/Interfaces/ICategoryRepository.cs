using System.Collections.Generic;
using System.Threading.Tasks;
using DomainDI.DataContext;

namespace DomainDI.Interfaces
{
    public interface ICategoryRepository
    {
        #region Methods

        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);

        Task<Category> CreateCategoryAsync(Category create);
        Task<bool> UpdateCategoryAsync(int id, Category update);
        Task<bool> DeleteCategoryAsync(int id);
        
        #endregion
    }
}
