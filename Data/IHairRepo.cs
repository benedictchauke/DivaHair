﻿using System.Collections.Generic;
using DivaHair.Data.Entities;

namespace DivaHair.Data
{
    public interface IHairRepo
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(int id);

        bool SaveAll();
        void AddEntity(object model);
    }
}