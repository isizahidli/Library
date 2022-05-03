using Library.Mappers;
using Library.Models;
using Library.ViewModels;
using Library.ViewModels.UserControls;
using Library.Views.UserControls;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.MainPageCommands
{
    public class OpenRoomsCommand : MainPageBaseCommand
    {
        public override void Execute(object parameter)
        {
            RoomControl roomControl = new RoomControl();
            RoomViewModel roomViewModel = new RoomViewModel();
            roomViewModel.MessageDialog = roomControl.MessageDialog;

            List<Room> rooms = DB.RoomRepository.Get();
            List<RoomModel> models = new List<RoomModel>();
            foreach (var room in rooms)
            {
                var model = RoomMapper.Map(room);
                models.Add(model);
            }

            roomViewModel.AllRooms = new List<RoomModel>(models);
            roomViewModel.InitializeViewModel();
            roomControl.DataContext = roomViewModel;

            viewModel.Grid.Children.Clear();
            viewModel.Grid.Children.Add(roomControl);
        }
    }
}
