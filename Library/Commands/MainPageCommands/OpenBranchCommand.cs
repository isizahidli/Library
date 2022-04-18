using Library.Mappers;
using Library.Models;
using Library.ViewModels;
using Library.ViewModels.UserControls;
using Library.Views.UserControls;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.MainPageCommands
{
    public class OpenBranchCommand : MainPageBaseCommand
    {
        public OpenBranchCommand(MainPageViewModel viewModel) : base(viewModel)
        {
        }

        public override void Execute(object parameter)
        {
            BranchControl branchControl = new BranchControl();
            BranchViewModel branchViewModel = new BranchViewModel();
            branchViewModel.MessageDialog = branchControl.MessageDialog;

            List<Branch1> branches = DB.BranchRepository.Get();
            List<BranchModel> models = new List<BranchModel>();
            foreach(var branch in branches)
            {
                var model = BranchMapper.Map(branch);
                models.Add(model);
            }

            branchViewModel.AllBranches = new List<BranchModel>(models);
            branchViewModel.InitializeViewModel();
            branchControl.DataContext = branchViewModel;

            viewModel.Grid.Children.Clear();
            viewModel.Grid.Children.Add(branchControl);
        }
    }
}
