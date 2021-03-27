﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.BindingModels
{
    public class ComponentBindingModel
    {
        public int? Id { get; set; }
        public int SellerId { get; set; }
        public string ComponentName { get; set; }
        public decimal Price { get; set; }
    }
}