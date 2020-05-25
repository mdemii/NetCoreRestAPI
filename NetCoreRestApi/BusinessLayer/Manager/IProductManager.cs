﻿using BusinessLayer.Models;
using System.Linq;

namespace BusinessLayer.Manager
{
    public interface IProductManager
    {
        IQueryable<ProductModel> GetAll();
    }
}