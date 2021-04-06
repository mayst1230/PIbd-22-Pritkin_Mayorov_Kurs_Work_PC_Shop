using System;
using System.Collections.Generic;
using System.Text;
using ComputerEquipmentStoreBusinessLogic.Buyer.BindingModels;
using ComputerEquipmentStoreBusinessLogic.Buyer.Interfaces;
using ComputerEquipmentStoreBusinessLogic.Buyer.ViewModels;
using ComputerEquipmentStoreDatabaseImplement.Models;
using System.Linq;

namespace ComputerEquipmentStoreDatabaseImplement.Implements
{
    public class CommentStorage : ICommentStorage
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CommentViewModel> GetFullList()
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                return context.Comments.Select(rec => new CommentViewModel
                {
                    Id = rec.Id,
                    Text = rec.Text,
                    DateComment = rec.DateComment,
                    BuyerId = rec.BuyerId,
                    AssemblyId = rec.AssemblyId,
                })
                .ToList();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<CommentViewModel> GetFilteredList(CommentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                return context.Comments
                .Where(rec => rec.Id.Equals(model.Id))
                .Select(rec => new CommentViewModel
                {
                    Id = rec.Id,
                    Text = rec.Text,
                    DateComment = rec.DateComment,
                    BuyerId = rec.BuyerId,
                    AssemblyId = rec.AssemblyId
                })
                .ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CommentViewModel GetElement(CommentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                var component = context.Comments.FirstOrDefault(
                    rec => rec.Id == model.Id);
                return component != null ?
                new CommentViewModel
                {
                    Id = component.Id,
                    Text = component.Text,
                    DateComment = component.DateComment,
                    BuyerId = component.BuyerId,
                    AssemblyId = component.AssemblyId
                }
                : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Insert(CommentBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                context.Comments.Add(CreateModel(model, new Comment()));
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Update(CommentBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                var element = context.Comments.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Delete(CommentBindingModel model)
        {
            using (var context = new ComputerEquipmentStoreDatabase())
            {
                Comment element = context.Comments.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Comments.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        private Comment CreateModel(CommentBindingModel model, Comment comment)
        {
            comment.Text = model.Text;
            comment.DateComment = model.DateComment;
            comment.BuyerId = model.BuyerId;
            comment.AssemblyId = model.AssemblyId;
            return comment;
        }
    }
}
