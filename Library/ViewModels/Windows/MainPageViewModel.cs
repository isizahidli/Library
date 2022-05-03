using Library.Commands.MainPageCommands;
using System;
using System.Windows.Controls;

namespace Library.ViewModels
{
    public class MainPageViewModel : WindowViewModel
    {

        public OpenRoomTypesCommand OpenRoomTypes => new OpenRoomTypesCommand(this);
        public OpenServicesCommand OpenServices => new OpenServicesCommand(this);
        public OpenDepartmentsCommand OpenDepartments => new OpenDepartmentsCommand(this);
        public OpenEmployeesCommand OpenEmployees => new OpenEmployeesCommand(this);
        public OpenReservationsCommand OpenReservations => new OpenReservationsCommand(this);
        public OpenRoomsCommand OpenRooms => new OpenRoomsCommand(this);
        public OpenCustomersCommand OpenCustomers => new OpenCustomersCommand(this);

        public Grid Grid { get; set; }

    }
}
