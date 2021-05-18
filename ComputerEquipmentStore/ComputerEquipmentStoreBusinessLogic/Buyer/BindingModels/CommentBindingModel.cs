using System;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels
{
    /// <summary>
    /// Комментарий к сборке
    /// </summary>
    public class CommentBindingModel
    {
        /// <summary>
        /// ID комментария
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// ID сборки
        /// </summary>
        public int AssemblyId { get; set; }

        /// <summary>
        /// ID покупателя
        /// </summary>
        public int? BuyerId { get; set; }

        /// <summary>
        /// Текст комментария
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Дата комментария
        /// </summary>
        public DateTime DateComment { get; set; }
    }
}
