﻿using System;
using System.Collections.Generic;

#nullable disable

namespace LAB3Northwind.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   ProductId == product.ProductId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductId);
        }

    }
}
