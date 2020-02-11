using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivaHair.Data.Entities
{
  public class Product
  {
    public int Id { get; set; }
    public string Category { get; set; }
    public string Size { get; set; }
    public decimal Price { get; set; }
    public decimal HairClosurePrice { get; set; }
    public string Grade { get; set; }
    public string HairDescription { get; set; }
    public DateTime PurchaseDate { get; set; }
    public DateTime DeliveryDate { get; set; }
  }
}
