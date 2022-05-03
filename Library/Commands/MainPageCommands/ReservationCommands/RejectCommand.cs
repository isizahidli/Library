﻿using Library.Commands.RoomCommands;
using Library.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.ReservationCommands
{
    public class RejectCommand : ReservationBaseCommand
    {
        public RejectCommand(ReservationViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            viewModel.InitializeViewModel();
        }
    }
}
