using System.Collections.Generic;
using System.Threading.Tasks;
using ModelCore.Entities;

namespace ModelCore.Interfaces
{
    public interface IProductsRepository
    {
        #region GetAll, GetById

        Task<ICollection<Products>> GetAllProductsAsync();
        Task<Products> GetProductById(int id);

        #endregion

        #region CRUD

        Task CreateProductAsync(Products create);
        Task<bool> UpdateProductAsync(int id, Products update);
        Task DeleteProductAsync(int id);

        #endregion
    }
}
