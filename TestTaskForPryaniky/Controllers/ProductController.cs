using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestTaskForPryaniky.Models;

namespace TestTaskForPryaniky.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    { 
        [HttpGet]
        public IEnumerable<Product> GetList()
        {
            return StaticDB.Products;
        }

    }
}
