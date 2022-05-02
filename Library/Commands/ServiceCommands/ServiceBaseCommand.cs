using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.ServiceCommands
{
    public abstract class ServiceBaseCommand : BaseCommand
    {
        protected readonly ServiceViewModel viewModel;
        public ServiceBaseCommand(ServiceViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
