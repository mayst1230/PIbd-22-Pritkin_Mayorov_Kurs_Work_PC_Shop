using System;
using System.ComponentModel;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels
{
    /// <summary>
    /// Комментарий
    /// </summary>
    public class CommentViewModel
    {
        /// <summary>
        /// ID комментария
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// ID сборки
        /// </summary>
        [DisplayName("ID сборки")]
        public int AssemblyId { get; set; }

        /// <summary>
        /// ID покупателя
        /// </summary>
        [DisplayName("ID покупателя")]
        public int BuyerId { get; set; }

        /// <summary>
        /// Текст комментария
        /// </summary>
        [DisplayName("Текст комментария")]
        public string Text { get; set; }

        /// <summary>
        /// Дата комментария
        /// </summary>
        [DisplayName("Дата комментария")]
        public DateTime DateComment { get; set; }
    }
}
