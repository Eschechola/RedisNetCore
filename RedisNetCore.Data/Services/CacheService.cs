using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RedisNetCore.Data.Entities;
using RedisNetCore.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisNetCore.Data.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IConfiguration _configuration;

        public CacheService(
            IDistributedCache distributedCache,
            IConfiguration configuration)
        {
            _distributedCache = distributedCache;
            _configuration = configuration;
        }

        public async Task<Product> CreateInMemoryProduct(Product product)
        {
            List<Product> products = new List<Product>();

            var keyName = _configuration["Redis:KeyName"];
            var productsString = await _distributedCache.GetStringAsync(keyName);
            
            if(productsString != null)
                products = JsonConvert.DeserializeObject<List<Product>>(productsString);

            product.CreateNewId();
            products.Add(product);

            var productsUpdatedString = JsonConvert.SerializeObject(products);
            await _distributedCache.SetStringAsync(keyName, productsUpdatedString);

            return product;
        }

        public async Task<IList<Product>> GetProductList()
        {
            List<Product> products = new List<Product>();
            var keyName = _configuration["Redis:KeyName"];
            var productsString = await _distributedCache.GetStringAsync(keyName);
            
            if(productsString != null)
                products = JsonConvert.DeserializeObject<List<Product>>(productsString);

            return products;
        }
    }
}
