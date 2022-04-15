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
    public class OpenRoomTypesCommand : MainPageBaseCommand
    {
        public OpenRoomTypesCommand(MainPageViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            RoomTypeControl roomTypeControl = new RoomTypeControl();
            RoomTypeViewModel roomTypeViewModel = new RoomTypeViewModel();
            roomTypeViewModel.MessageDialog = roomTypeControl.MessageDialog;

            List<RoomType> roomTypes = DB.RoomTypeRepository.Get();
            List<RoomTypeModel> models = new List<RoomTypeModel>();
            foreach (var roomType in roomTypes)
            {
                var model = RoomTypeMapper.Map(roomType);
                models.Add(model);
            }

            roomTypeViewModel.AllRoomTypes = new List<RoomTypeModel>(models);
            roomTypeViewModel.InitializeViewModel();
            roomTypeControl.DataContext = roomTypeViewModel;

            viewModel.Grid.Children.Clear();
            viewModel.Grid.Children.Add(roomTypeControl);
        }
    }
}
