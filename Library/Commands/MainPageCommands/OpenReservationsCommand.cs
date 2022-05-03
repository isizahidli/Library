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
    public class OpenReservationsCommand : MainPageBaseCommand
    {
        public override void Execute(object parameter)
        {
            ReservationControl reservationControl = new ReservationControl();
            ReservationModel reservationViewModel = new ReservationViewModel();
            reservationViewModel.MessageDialog = reservationControl.MessageDialog;

            List<Reservation> reservations = DB.ReservationRepository.Get();
            List<Reservation> models = new List<ReservationModel>();
            foreach (var reservation in reservations)
            {
                var model = ReservationMapper.Map(reservation);
                models.Add(model);
            }

            reservationViewModel.AllReservations = new List<ReservationModel>(models);
            reservationViewModel.InitializeViewModel();
            reservationControl.DataContext = reservationViewModel;

            viewModel.Grid.Children.Clear();
            viewModel.Grid.Children.Add(reservationControl);
        }
    }
}
