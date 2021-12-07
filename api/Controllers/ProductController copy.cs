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
            new Product() { ProductId = 1, title = "Æble", price = 2},
            new Product() { ProductId = 2, title = "Pære", price = 2},
            new Product() { ProductId = 3, title = "Banan", price = 2},
            new Product() { ProductId = 1, title = "Appelsin", price = 4},
            new Product() { ProductId = 2, title = "Melon", price = 11},
            new Product() { ProductId = 3, title = "Juice", price = 5},
        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productList;
        }
    }
}
