using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.RoomCommands
{
    public abstract class RoomBaseCommand : BaseCommand
    {
        protected readonly RoomViewModel viewModel;
        public RoomBaseCommand(RoomViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
