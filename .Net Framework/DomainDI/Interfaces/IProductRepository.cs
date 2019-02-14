using System.Collections.Generic;
using System.Threading.Tasks;
using DomainDI.DataContext;

namespace DomainDI.Interfaces
{
    public interface IProductRepository
    {
        #region Methods

        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);

        Task<Product> CreateProductAsync(Product create);
        Task<bool> UpdateProductAsync(int id, Product update);
        Task<bool> DeleteProductAsync(int id);

        #endregion
    }
}
