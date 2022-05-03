using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.CustomerCommands
{
    public abstract class CustomerBaseCommand : BaseCommand
    {
        protected readonly CustomerViewModel viewModel;
        public CustomerBaseCommand(CustomerViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
