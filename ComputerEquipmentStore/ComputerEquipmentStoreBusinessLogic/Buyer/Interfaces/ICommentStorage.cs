using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces
{
    /// <summary>
    /// Интерфейс хранилища комментариев
    /// </summary>
    public interface ICommentStorage
    {
        /// <summary>
        /// Метод получения полного списка комментариев
        /// </summary>
        /// <param name="BuyerId"> ID покупателя </param>
        /// <param name="superAccess"> Супер-доступ </param>
        /// <returns> Список комментариев </returns>
        List<CommentViewModel> GetFullList(int BuyerId, bool superAccess);

        /// <summary>
        /// Метод получения отфильтрованного списка комментариев
        /// </summary>
        /// <param name="model"> Модель комментария </param>
        /// <returns> Список комментариев </returns>
        List<CommentViewModel> GetFilteredList(CommentBindingModel model);

        /// <summary>
        /// Метод получения комментария
        /// </summary>
        /// <param name="model"> Модель комментария </param>
        /// <returns> Модель комментария </returns>
        CommentViewModel GetElement(CommentBindingModel model);

        /// <summary>
        /// Добавить новый комментария
        /// </summary>
        /// <param name="model"> Модель комментария </param>
        void Insert(CommentBindingModel model);

        /// <summary>
        /// Обновить комментарий
        /// </summary>
        /// <param name="model"> Модель комментария </param>
        void Update(CommentBindingModel model);

        /// <summary>
        /// Удалить комментарий
        /// </summary>
        /// <param name="model"> Модель комментария </param>
        void Delete(CommentBindingModel model);
    }
}
