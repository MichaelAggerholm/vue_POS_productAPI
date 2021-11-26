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
        /*private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };*/

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        private static List<Product> productList = new List<Product>
        {
            new Product() { ProductId = 1, title = "produkt 1", description = "test produkt ét", price = 199, category = "Kategori 1" },
            new Product() { ProductId = 2, title = "produkt 2", description = "test produkt to", price = 299, category = "Kategori 2" },
            new Product() { ProductId = 3, title = "produkt 3", description = "test produkt tre", price = 399, category = "Kategori 3" },
        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productList;
        }
    }
}
