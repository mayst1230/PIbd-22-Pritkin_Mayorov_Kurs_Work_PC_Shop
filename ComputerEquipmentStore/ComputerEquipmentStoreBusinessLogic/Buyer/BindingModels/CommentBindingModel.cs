using System;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels
{
    /// <summary>
    /// Комментарий к сборке
    /// </summary>
    public class CommentBindingModel
    {
        //ID комментария
        public int? Id { get; set; }

        //ID сборки
        public int AssemblyId { get; set; }

        //ID покупателя
        public int BuyerId { get; set; }

        //Текст комментария
        public string Text { get; set; }

        //Дата комментария
        public DateTime DateComment { get; set; }
    }
}
