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
            new Product() { ProductId = 1, title = "Æble", price = 2, category = "fruit"},
            new Product() { ProductId = 2, title = "Pære", price = 2, category = "fruit"},
            new Product() { ProductId = 3, title = "Banan", price = 3, category = "fruit"},
            new Product() { ProductId = 4, title = "Appelsin", price = 4, category = "fruit"},
            new Product() { ProductId = 5, title = "Melon", price = 11, category = "fruit"},
            new Product() { ProductId = 6, title = "Juice", price = 5, category = "beverage"},
            new Product() { ProductId = 7, title = "Saftevand", price = 16, category = "beverage"},
            new Product() { ProductId = 8, title = "Æg", price = 4, category = "food"},
            new Product() { ProductId = 9, title = "Blomme", price = 2, category = "fruit"},
        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productList;
        }
    }
}
