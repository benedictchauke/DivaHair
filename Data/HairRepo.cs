using DivaHair.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivaHair.Data
{
    public class HairRepo : IHairRepo
    {
        private readonly HairContext _ctx;
        private readonly ILogger<HairRepo> _logger;

        public HairRepo(HairContext ctx, ILogger<HairRepo> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _ctx.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToList();
        }

        public IEnumerable<Product>GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called");
                return _ctx.Products
                           .OrderBy(p => p.Size)
                           .ToList();
            }

            catch (Exception exc)
            {
                _logger.LogError($"Failed to get all products: {exc}");
                return null;
            }
        }

        public object GetOrderById(int id)
        {
            return _ctx.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Product>GetProductsByCategory(string category)
        {
            return _ctx.Products
                       .Where(p => p.Category == category)
                       .ToList(); 
        }
        
        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0; 
        }

    }
}
