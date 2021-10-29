using Microsoft.AspNetCore.Mvc;
using RedisNetCore.Data.Entities;
using RedisNetCore.Data.Interfaces;
using System;
using System.Threading.Tasks;

namespace RedisNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        public HomeController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet]
        [Route("/api/get-cache-data")]
        public async Task<IActionResult> GetCacheData()
        {
            try
            {
                return Ok(await _cacheService.GetProductList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("/api/post-data")]
        public async Task<IActionResult> PostData([FromBody] Product product)
        {
            try
            {
                return Ok(await _cacheService.CreateInMemoryProduct(product));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
