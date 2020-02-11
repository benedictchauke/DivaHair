using DivaHair.Data;
using DivaHair.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivaHair.Controllers
{
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IHairRepo _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IHairRepo repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch(Exception exc)
            {
                _logger.LogError("$Failed to get products: {exc}");
                return Json("Failed to get products");
            }
            
        }
        
    }
}
