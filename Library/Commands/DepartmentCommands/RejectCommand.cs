using Library.Commands.ServiceCommands;
using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.DepartmentCommands
{
    public class RejectCommand : DepartmentBaseCommand
    {
        public RejectCommand(DepartmentViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            viewModel.InitializeViewModel();
        }
    }
}
