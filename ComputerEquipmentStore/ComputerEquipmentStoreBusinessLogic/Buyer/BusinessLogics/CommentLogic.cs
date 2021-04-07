using System;
using System.Collections.Generic;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using System.Text;

namespace ComputerEquipmentStoreBusinessLogic.Buyer.BusinessLogics
{
    public class CommentLogic
    {
        
        private readonly ICommentStorage _commentStorage;

        public CommentLogic(ICommentStorage commentStorage)
        {
            _commentStorage = commentStorage;
        }

        public List<CommentViewModel> Read(CommentBindingModel model, int BuyerId)
        {
            if (model == null)
            {
                return _commentStorage.GetFullList(BuyerId);
            }
            if (model.Id.HasValue)
            {
                return new List<CommentViewModel> { _commentStorage.GetElement(model) };
            }
            return _commentStorage.GetFilteredList(model);
        }

        //Создать или обновить комментарий
        public void CreateOrUpdate(CommentBindingModel model)
        {
            var element = _commentStorage.GetElement(new CommentBindingModel { Text = model.Text });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть подобный комментарий");
            }
            if (model.Id.HasValue)
            {
                _commentStorage.Update(model);
            }
            else
            {
                _commentStorage.Insert(model);
            }
        }

        //Удалить комментарий
        public void Delete(CommentBindingModel model)
        {
            var element = _commentStorage.GetElement(new CommentBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _commentStorage.Delete(model);
        } 
    }
}
