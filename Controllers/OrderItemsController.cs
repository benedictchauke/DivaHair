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
    [Route("/api/orders/{orderid}/items")]
    public class OrderItemsController : Controller
    {
        private readonly IHairRepo _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderItemsController> _logger;


        public OrderItemsController(IHairRepo repository, ILogger<OrderItemsController> logger, IMapper mapper )
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int orderId)
        {
            var order = _repository.GetOrderById(orderId);
            if (order != null) return Ok(_mapper.Map < IEnumerable<OrderItem>, IEnumerable<OrderItemHairOrder>>(order.Items));
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int orderId, int id)
        {
            var order = _repository.GetOrderById(orderId);
            if (order != null)
            {
                var item = order.Items.Where(i => i.Id == id).FirstOrDefault();
                if (item != null)
                {
                    return Ok(_mapper.Map <OrderItem, OrderItemHairOrder>(item));
                }
            }
            return NotFound();
        }
        
    }
}
