using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.ReservationCommands
{
    public abstract class ReservationBaseCommand : BaseCommand
    {
        protected readonly ReservationViewModel viewModel;
        public ReservationBaseCommand(ReservationViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
