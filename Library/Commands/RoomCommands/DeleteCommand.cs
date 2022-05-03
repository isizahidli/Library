using Library.Mappers;
using Library.Models;
using Library.Utils;
using Library.ViewModels;
using Library.ViewModels.UserControls;
using Library.Views.Components;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.RoomCommands
{
    public class DeleteCommand : RoomBaseCommand
    {
        public DeleteCommand(RoomViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            DialogViewModel dialogViewModel = new DialogViewModel();
            dialogViewModel.DialogText = "Silmək istədiyinizdən əminsinizmi?";

            Dialog dialog = new Dialog();
            dialog.DataContext = dialogViewModel;
            if (dialog.ShowDialog() == true)
            {
                int id = viewModel.SelectedRoom.Id;
                DB.RoomTypeRepository.Delete(id);

                viewModel.Message = "Əməliyyat uğurla həyata keçdi";
                BusinessUtil.DoAnimation(viewModel.MessageDialog);

                // reload all branches
                List<Room> rooms = DB.RoomRepository.Get();
                List<RoomModel> models = new List<RoomModel>();
                foreach (var entity in rooms)
                {
                    var model = RoomMapper.Map(entity);
                    models.Add(model);
                }

                viewModel.Rooms = new List<RoomModel>(models);
                viewModel.InitializeViewModel();

                Logger.LogInformation($"Room: {id}  has been deleted");
            }

        }
    }
}
