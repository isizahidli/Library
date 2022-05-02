using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.RoomTypeCommands
{
    public class RejectCommand : RoomTypeBaseCommand
    {
        public RejectCommand(RoomTypeViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            viewModel.InitializeViewModel();
        }
    }
}
