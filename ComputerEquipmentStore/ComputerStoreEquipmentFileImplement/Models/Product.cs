﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComputerEquipmentStoreDatabaseImplement.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public decimal Price { get; set; }
        public string NameProduct { get; set; }
        public Seller Seller { get; set; }

        [ForeignKey("ProductID")]
        public virtual List<Order> Orders { get; set; }

        [ForeignKey("ProductId")]
        public virtual List<ProductComponent> ProductComponents { get; set; }

        [ForeignKey("ProductId")]
        public virtual List<PurchaseProduct> PurchaseProducts { get; set; }
    }
}
