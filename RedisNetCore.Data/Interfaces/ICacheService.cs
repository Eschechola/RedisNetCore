using RedisNetCore.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisNetCore.Data.Interfaces
{
    public interface ICacheService
    {
        Task<IList<Product>> GetProductList();
        Task<Product> CreateInMemoryProduct(Product product);
    }
}
