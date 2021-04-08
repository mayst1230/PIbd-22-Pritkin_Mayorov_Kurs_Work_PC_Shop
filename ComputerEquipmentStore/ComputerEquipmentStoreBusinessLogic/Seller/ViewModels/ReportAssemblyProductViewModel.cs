﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Seller.ViewModels
{
    public class ReportAssemblyProductViewModel
    {
        public string AssemblyName { get; set; }
        public Dictionary<int, (string, decimal)> Products { get; set; }
    }
}
