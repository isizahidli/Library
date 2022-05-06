using Library.Mappers;
using Library.Models;
using Library.ViewModels;
using Library.ViewModels.UserControls;
using Library.Views.UserControls;
using LibraryCore.Domain.Entities;
using LibraryCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Library.Commands.MainPageCommands
{
    public class OpenReservationsCommand : MainPageBaseCommand
    {
        public OpenReservationsCommand(MainPageViewModel viewModel): base(viewModel) { }

        public override void Execute(object parameter)
        {
            ReservationControl reservationControl = new ReservationControl();
            ReservationViewModel reservationViewModel = new ReservationViewModel();
            reservationViewModel.MessageDialog = reservationControl.MessageDialog;

            List<Reservation> reservations = DB.ReservationRepository.Get();
            List<ReservationModel> models = new List<ReservationModel>();
            foreach (var reservation in reservations)
            {
                var model = ReservationMapper.Map(reservation);
                models.Add(model);
            }

            List<Customer> customers = DB.CustomerRepository.Get();
            List<CustomerModel> cusModels = new List<CustomerModel>();
            foreach (var customer in customers)
            {
                var model = CustomerMapper.Map(customer);
                cusModels.Add(model);
            }

            List<Room> rooms = DB.RoomRepository.Get().Where(x => x.Status == Status.Active).ToList();
            List<RoomModel> roomModels = new List<RoomModel>();
            foreach (var room in rooms)
            {
                var model = RoomMapper.Map(room);
                roomModels.Add(model);
            }

            reservationViewModel.Rooms = roomModels;
            reservationViewModel.Customers = cusModels;
            reservationViewModel.AllReservations = new List<ReservationModel>(models);
            reservationViewModel.InitializeViewModel();
            reservationControl.DataContext = reservationViewModel;

            viewModel.Grid.Children.Clear();
            viewModel.Grid.Children.Add(reservationControl);
        }
    }
}
