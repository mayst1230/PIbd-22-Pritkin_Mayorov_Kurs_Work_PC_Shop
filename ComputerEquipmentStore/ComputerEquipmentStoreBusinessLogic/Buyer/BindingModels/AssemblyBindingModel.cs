using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels
{
    /// <summary>
    /// Сборка
    /// </summary>
    public class AssemblyBindingModel
    {
        //ID сборки
        public int? Id { get; set; }

        //Общая стоимость сборки
        public int TotalCost { get; set; }

        //Покупки в которых присутствует эта сборка
        public Dictionary<int, (string, int)> Purchases { get; set; }

        //Комментарии к сборке
        public Dictionary<int, (string, int)> AssemblyComments { get; set; }

        //Комплектующие находящиеся в этой сборке
        public Dictionary<int, (string, int)> Components { get; set; }
    }
}
