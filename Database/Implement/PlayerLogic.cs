using Database.Models;
using Logic.BindingModel;
using Logic.Interface;
using Logic.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Implement
{
    public class PlayerLogic : IPlayer
    {
        public void CreateOrUpdate(PlayerBindingModel model)
        {
            using (var context = new Database())
            {
                Player element = context.Players.FirstOrDefault(rec => rec.PlayerName == model.PlayerName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть игрок с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Players.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Player();
                    context.Players.Add(element);
                }
                element.PlayerName = model.PlayerName;
                element.DateDeath = model.DateDeath;
                element.Score = model.Score;
                element.Type = model.Type;
                element.GameId = model.GameId;
                context.SaveChanges();
            }
        }
        public void Delete(PlayerBindingModel model)
        {
            using (var context = new Database())
            {
                Player element = context.Players.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Players.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<PlayerViewModel> Read(PlayerBindingModel model)
        {
            using (var context = new Database())
            {
                return context.Players.Include(x => x.Game)
                .Where(rec => model == null || rec.Id == model.Id 
                || (model.DateFrom.HasValue && model.DateTo.HasValue 
                && rec.Game.DateCreate >= model.DateFrom && rec.Game.DateCreate <= model.DateTo))
                .Select(rec => new PlayerViewModel
                {
                    Id = rec.Id,
                    GameId = rec.GameId,
                    PlayerName = rec.PlayerName,
                    DateDeath = rec.DateDeath,
                    Type = rec.Type,
                    Score = rec.Score                    
                })
                .ToList();
            }
        }
    }
}
