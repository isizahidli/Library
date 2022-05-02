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

namespace Library.Commands.RoomTypeCommands
{
    public class DeleteCommand : RoomTypeBaseCommand
    {
        public DeleteCommand(RoomTypeViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            DialogViewModel dialogViewModel = new DialogViewModel();
            dialogViewModel.DialogText = "Silmək istədiyinizdən əminsinizmi?";

            Dialog dialog = new Dialog();
            dialog.DataContext = dialogViewModel;
            if (dialog.ShowDialog() == true)
            {
                int id = viewModel.SelectedRoomType.Id;
                DB.RoomTypeRepository.Delete(id);

                viewModel.Message = "Əməliyyat uğurla həyata keçdi";
                BusinessUtil.DoAnimation(viewModel.MessageDialog);

                // reload all branches
                List<RoomType> services = DB.RoomTypeRepository.Get();
                List<RoomTypeModel> models = new List<RoomTypeModel>();
                foreach (var entity in services)
                {
                    var model = RoomTypeMapper.Map(entity);
                    models.Add(model);
                }

                viewModel.RoomTypes = new List<RoomTypeModel>(models);
                viewModel.InitializeViewModel();

                Logger.LogInformation($"Branch: {id}  has been deleted");
            }
        }
    }
}
