using Library.Commands.RoomCommands;
using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.ReservationCommands
{
    internal class EnumerateCommand : ReservationBaseCommand
    {
        public EnumerateCommand(ReservationViewModel viewModel): base(viewModel) { }

        public override void Execute(object parameter)
        {
            int no = 1;
            foreach (var item in viewModel.Reservations)
            {
                item.No = no;
                no++;
            }
        }
    }
}
