using Library.Mappers;
using Library.Models;
using Library.Utils;
using Library.ViewModels;
using Library.ViewModels.UserControls;
using Library.Views.Components;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.BranchCommands
{
    public class DeleteCommand : BranchBaseCommand
    {
        public DeleteCommand(BranchViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            DialogViewModel dialogViewModel = new DialogViewModel();
            dialogViewModel.DialogText = "Silmək istədiyinizdən əminsinizmi?";

            Dialog dialog = new Dialog();
            dialog.DataContext = dialogViewModel;
            if (dialog.ShowDialog() == true)
            {
                int id = viewModel.SelectedBranch.Id;
                var branch = DB.BranchRepository.FindById(id);
                if(branch != null)
                {
                    branch.IsDeleted = true;
                    DB.BranchRepository.Update(branch);
                }

                viewModel.Message = "Əməliyyat uğurla həyata keçdi";
                BusinessUtil.DoAnimation(viewModel.MessageDialog);

                // reload all branches
                List<Branch1> branches = DB.BranchRepository.Get();
                List<BranchModel> models = new List<BranchModel>();
                foreach (var entity in branches)
                {
                    var model = BranchMapper.Map(entity);
                    models.Add(model);
                }

                viewModel.Branches = new List<BranchModel>(models);
                viewModel.InitializeViewModel();

                Logger.LogInformation($"Branch: {id}  has been deleted");
            }
        }
    }
}
