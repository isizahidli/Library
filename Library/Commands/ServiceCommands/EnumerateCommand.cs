using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.ServiceCommands
{
    public class EnumerateCommand : ServiceBaseCommand
    {
        public EnumerateCommand(ServiceViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            int no = 1;
            foreach (var item in viewModel.Services)
            {
                item.No = no;
                no++;
            }
        }
    }
}
