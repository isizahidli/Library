using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.EmployeeCommands
{
    public abstract class EmployeeBaseCommand : BaseCommand
    {
        protected readonly EmployeeViewModel viewModel;
        public EmployeeBaseCommand(EmployeeViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
