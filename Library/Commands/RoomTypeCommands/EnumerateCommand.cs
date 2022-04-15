using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.RoomTypeCommands
{
    public class EnumerateCommand : RoomTypeBaseCommand
    {
        public EnumerateCommand(RoomTypeViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            int no = 1;
            foreach (var item in viewModel.RoomTypes)
            {
                item.No = no;
                no++;
            }
        }
    }
}
