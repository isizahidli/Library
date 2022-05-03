using Library.Commands.ServiceCommands;
using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.DepartmentCommands
{
    public class EnumerateCommand : DepartmentBaseCommand
    {
        public EnumerateCommand(DepartmentViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            int no = 1;
            foreach (var item in viewModel.Departments)
            {
                item.No = no;
                no++;
            }
        }
    }
}
