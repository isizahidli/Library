using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.RoomCommands
{
    public class EnumerateCommand : RoomBaseCommand
    {
        public EnumerateCommand(RoomViewModel viewModel): base(viewModel) { }

        public override void Execute(object parameter)
        {
            int no = 1;
            foreach (var item in viewModel.Rooms)
            {
                item.No = no;
                no++;
            }
        }
    }
}
