using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.CustomerCommands
{
    public class RejectCommand : CustomerBaseCommand
    {
        public RejectCommand(CustomerViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            viewModel.InitializeViewModel();
        }
    }
}
