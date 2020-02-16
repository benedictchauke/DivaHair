using DivaHair.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivaHair.Controllers
{
    [Route("Api/[Controller]")]
    public class OrdersController : Controller
    {
        
        private readonly IHairRepo _repository;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IHairRepo repository, ILogger<OrdersController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllOrders());
            }
            catch (Exception exc)
            {
                _logger.LogError($"Failed to get orders: {exc}");
                return BadRequest("Failed to get orders");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = _repository.GetOrderById(id);
                return order != null ? Ok(order) : (IActionResult)NotFound(); ;                
            }
            catch (Exception exc)
            {
                _logger.LogError($"Failed to get orders: {exc}");
                return BadRequest("Failed to get orders");
            }
        }

    }
}