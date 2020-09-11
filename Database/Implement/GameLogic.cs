using Database.Models;
using Logic.BindingModel;
using Logic.Interface;
using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Implement
{
    public class GameLogic : IGame
    {
        public void CreateOrUpdate(GameBindingModel model)
        {
            using (var context = new Database())
            {
                Game element = context.Games.FirstOrDefault(rec => rec.Name == model.Name && rec.Id != model.Id);
                if (element != null)
                {
                    //название
                    throw new Exception("Уже есть игра с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Games.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Game();
                    context.Games.Add(element);
                }
                element.Name = model.Name;
                element.Master = model.Master;
                element.DateCreate = model.DateCreate;
                context.SaveChanges();
            }
        }
        public void Delete(GameBindingModel model)
        {
            using (var context = new Database())
            {
                Game element = context.Games.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Games.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<GameViewModel> Read(GameBindingModel model)
        {
            using (var context = new Database())
            {
                return context.Games
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new GameViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Master = rec.Master,
                    DateCreate = rec.DateCreate
                })
                .ToList();
            }
        }
    }
}
