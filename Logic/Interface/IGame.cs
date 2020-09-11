using Logic.BindingModel;
using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interface
{
    public interface IGame
    {
        List<GameViewModel> Read(GameBindingModel model);
        void CreateOrUpdate(GameBindingModel model);
        void Delete(GameBindingModel model);
    }
}
