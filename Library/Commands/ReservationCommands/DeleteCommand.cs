using Library.Commands.RoomCommands;
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

namespace Library.Commands.ReservationCommands
{
    public class DeleteCommand : ReservationBaseCommand
    {
        public DeleteCommand(ReservationViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            DialogViewModel dialogViewModel = new DialogViewModel();
            dialogViewModel.DialogText = "Silmək istədiyinizdən əminsinizmi?";

            Dialog dialog = new Dialog();
            dialog.DataContext = dialogViewModel;
            if (dialog.ShowDialog() == true)
            {
                int id = viewModel.SelectedReservation.Id;
                DB.ReservationRepository.Delete(id);

                viewModel.Message = "Əməliyyat uğurla həyata keçdi";
                BusinessUtil.DoAnimation(viewModel.MessageDialog);

                // reload all branches
                List<Reservation> reservations = DB.ReservationRepository.Get();
                List<ReservationModel> models = new List<ReservationModel>();
                foreach (var entity in reservations)
                {
                    var model = ReservationMapper.Map(entity);
                    models.Add(model);
                }

                viewModel.Reservations = new List<ReservationModel>(models);
                viewModel.InitializeViewModel();

                Logger.LogInformation($"Reservation: {id}  has been deleted");
            }

        }
    }
}
