using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.EmployeeCommands
{
    public class EnumerateCommand : EmployeeBaseCommand
    {
        public EnumerateCommand(EmployeeViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            int no = 1;
            foreach (var item in viewModel.Employees)
            {
                item.No = no;
                no++;
            }
        }
    }
}
