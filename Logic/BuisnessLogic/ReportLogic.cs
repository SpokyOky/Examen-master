using Logic.BindingModel;
using Logic.HelperInfo;
using Logic.Interface;
using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.BuisnessLogic
{
    public class ReportLogic
    {
        private readonly IGame Game;
        private readonly IPlayer Player;
        public ReportLogic(IGame Game, IPlayer Player)
        {
            this.Game = Game;
            this.Player = Player;
        }
        public List<ReportViewModel> GetPlayers(ReportBindingModel model)
        {
            var Players = Player.Read(new PlayerBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            });
            var list = new List<ReportViewModel>();
            foreach (var rec in Players)
            {
                var record = new ReportViewModel
                {
                    PlayerName = rec.PlayerName,
                    Name = Game.Read(new GameBindingModel
                    {
                        Id = rec.GameId
                    })[0].Name,
                    DateDeath = rec.DateDeath,
                    Score = rec.Score,
                    DateCreate = Game.Read(new GameBindingModel
                    {
                        Id = rec.GameId
                    })[0].DateCreate
                };
                list.Add(record);
            }
            return list;
        }
        public async void SavePlayersToPdfFile(ReportBindingModel model)
        {
            //названия
            string title = "Игры и игроки";
            await Task.Run(() =>
            {
                SaveToPdf.CreateDoc(new PdfInfo
                {
                    FileName = model.FileName,
                    Title = title,
                    Players = GetPlayers(model),
                });
            });
        }
    }
}
