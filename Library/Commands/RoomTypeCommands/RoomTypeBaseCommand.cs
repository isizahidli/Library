using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.RoomTypeCommands
{
    public abstract class RoomTypeBaseCommand : BaseCommand
    {
        protected readonly RoomTypeViewModel viewModel;
        public RoomTypeBaseCommand(RoomTypeViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
