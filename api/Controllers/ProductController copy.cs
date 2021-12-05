using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        private static List<Product> productList = new List<Product>
        {
            new Product() { ProductId = 1, title = "Æble", price = 4},
            new Product() { ProductId = 1, title = "Pære", price = 3},
            new Product() { ProductId = 1, title = "Banan", price = 2},
        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productList;
        }
    }
}
