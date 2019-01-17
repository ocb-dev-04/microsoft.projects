using System.Collections.Generic;
using System.Threading.Tasks;
using ModelCore.Entities;

namespace ModelCore.Interfaces
{
    public interface ICategoriesRepository
    {
        #region GetAll, GetById

        Task<ICollection<Categories>> GetAllCategoriesAsync();
        Task<Categories> GetCategoryById(int id);

        #endregion

        #region CRUD

        Task CreateCategoryAsync(Categories categories);
        Task<bool> UpdateCategoryAsync(int id, Categories categories);
        Task DeleteCategoryAsync(int id);
        
        #endregion
    }
}
