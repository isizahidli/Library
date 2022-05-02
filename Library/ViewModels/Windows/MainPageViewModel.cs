using Library.Commands.MainPageCommands;
using System;
using System.Windows.Controls;

namespace Library.ViewModels
{
    public class MainPageViewModel : WindowViewModel
    {

        public OpenRoomTypesCommand OpenRoomTypes => new OpenRoomTypesCommand(this);
        public OpenServicesCommand OpenServices => new OpenServicesCommand(this);
        public OpenBookCommand OpenBook => new OpenBookCommand(this);
        public OpenAddSalaryCommand OpenAddSalary => new OpenAddSalaryCommand(this);

        public Grid Grid { get; set; }

    }
}
