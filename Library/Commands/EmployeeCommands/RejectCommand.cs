using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.EmployeeCommands
{
    public class RejectCommand : EmployeeBaseCommand
    {
        public RejectCommand(EmployeeViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            viewModel.InitializeViewModel();
        }
    }
}
