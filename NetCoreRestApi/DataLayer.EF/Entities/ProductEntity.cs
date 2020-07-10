﻿using System.Collections.Generic;

namespace DataLayer.EF.Entities
{
    public class ProductEntity : ItemEntity<int>
    {      
        public ICollection<CategoryEntity> Categories { get; set; }
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
    }
}