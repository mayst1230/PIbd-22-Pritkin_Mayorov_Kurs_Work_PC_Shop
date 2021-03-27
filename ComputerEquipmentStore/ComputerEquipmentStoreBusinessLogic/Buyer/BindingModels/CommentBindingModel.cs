using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels
{
    /// <summary>
    /// Комментарий к сборке
    /// </summary>
    public class CommentBindingModel
    {
        //ID комментария
        public int? Id { get; set; }

        public int AssemblyId { get; set; }

        public int BuyerId { get; set; }

        //Текст комментария
        public string Text { get; set; }

        //Дата комментария
        public DateTime DateComment { get; set; }
    }
}
