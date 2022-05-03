using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.ServiceCommands
{
    public abstract class DepartmentBaseCommand : BaseCommand
    {
        protected readonly DepartmentViewModel viewModel;
        public DepartmentBaseCommand(DepartmentViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
