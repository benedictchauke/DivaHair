using DivaHair.Data.Entities;
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

        public HairRepo(HairContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Product>GetAllProducts()
        {
            return _ctx.Products
                       .OrderBy(p => p.Size)
                       .ToList();

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
