using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using System;
using System.Collections.Generic;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics
{
    /// <summary>
    /// Логика комментария
    /// </summary>
    public class CommentLogic
    {
        /// <summary>
        /// Хранилище комментариев
        /// </summary>
        private readonly ICommentStorage commentStorage;

        /// <summary>
        /// Конструктор логики комментария
        /// </summary>
        /// <param name="commentStorage"> Хранилище комментариев </param>
        public CommentLogic(ICommentStorage commentStorage)
        {
            this.commentStorage = commentStorage;
        }

        /// <summary>
        /// Получить список комментариев (либо одного комментария)
        /// </summary>
        /// <param name="model"> Модель комментария </param>
        /// <param name="BuyerId"> ID покупателя </param>
        /// <param name="SuperAccess"> Супер-доступ </param>
        /// <returns> Список комментариев (либо один комментариев) </returns>
        public List<CommentViewModel> Read(CommentBindingModel model, int BuyerId, bool SuperAccess)
        {
            if (model == null)
            {
                return commentStorage.GetFullList(BuyerId, SuperAccess);
            }
            if (model.Id.HasValue)
            {
                return new List<CommentViewModel> { commentStorage.GetElement(model) };
            }
            return commentStorage.GetFilteredList(model);
        }

        /// <summary>
        /// Создать или обновить комментарий
        /// </summary>
        /// <param name="model"> Модель комментария </param>
        public void CreateOrUpdate(CommentBindingModel model)
        {
            var element = commentStorage.GetElement(new CommentBindingModel { Text = model.Text });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть подобный комментарий");
            }
            if (model.Id.HasValue)
            {
                commentStorage.Update(model);
            }
            else
            {
                commentStorage.Insert(model);
            }
        }

        /// <summary>
        /// Удалить комментарий
        /// </summary>
        /// <param name="model"> Модель комментария </param>
        public void Delete(CommentBindingModel model)
        {
            var element = commentStorage.GetElement(new CommentBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            commentStorage.Delete(model);
        } 
    }
}
