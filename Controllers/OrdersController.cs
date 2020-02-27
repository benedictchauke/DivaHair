using AutoMapper;
using DivaHair.Data;
using DivaHair.Data.Entities;
using DivaHair.ViewModels;
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
        private readonly IMapper _mapper;

        public OrdersController(IHairRepo repository, ILogger<OrdersController> logger, IMapper _mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = this._mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<Order>, IEnumerable<ViewHairOrder>>(_repository.GetAllOrders()));
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
                if (order != null) return Ok(_mapper.Map<Order, ViewHairOrder>(order));
                else return NotFound();                 
            }
            catch (Exception exc)
            {
                _logger.LogError($"Failed to get orders: {exc}");
                return BadRequest("Failed to get orders");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]ViewHairOrder model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = _mapper.Map<ViewHairOrder, Order>(model);

                    if(newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }

                    _repository.AddEntity(model);
                    if (_repository.SaveAll())
                    {
                        return Created($"/api/orders/{newOrder.Id}", _mapper.Map<Order, ViewHairOrder>(newOrder));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception exc)
            {
                _logger.LogError($"Failed to save the order: {exc}");
            }
            return BadRequest("Failed to save the order");
        }

    }
}