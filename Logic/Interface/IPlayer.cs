using Logic.BindingModel;
using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interface
{
    public interface IPlayer
    {
        List<PlayerViewModel> Read(PlayerBindingModel model);
        void CreateOrUpdate(PlayerBindingModel model);
        void Delete(PlayerBindingModel model);
    }
}
