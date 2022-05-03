using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.CustomerCommands
{
    public class EnumerateCommand : CustomerBaseCommand
    {
        public EnumerateCommand(CustomerViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            int no = 1;
            foreach (var item in viewModel.Customers)
            {
                item.No = no;
                no++;
            }
        }
    }
}
