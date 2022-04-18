using Library.Mappers;
using Library.Models;
using Library.Utils;
using Library.ViewModels.UserControls;
using LibraryCore.Domain.Entities;
using LibraryCore.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library.Commands.BranchCommands
{
    public class SaveCommand : BranchBaseCommand
    {
        public SaveCommand(BranchViewModel viewModel) : base(viewModel)
        {

        }


        public override void Execute(object parameter)
        {
            int situation = viewModel.CurrentSituation;
            if(situation == (int) Constants.SITUATIONS.NORMAL)
            {
                viewModel.CurrentSituation = (int)Constants.SITUATIONS.ADD;
            }
            else if(situation == (int) Constants.SITUATIONS.SELECTED)
            {
                viewModel.CurrentSituation = (int)Constants.SITUATIONS.EDIT;
            }
            else
            {
                if(IsValid())
                {
                    CorrectData();

                    if (situation == (int)Constants.SITUATIONS.ADD)
                    {
                        var branch = BranchMapper.Map(viewModel.CurrentBranch, new Branch1());
                        branch.IsDeleted = false;
                        branch.CreationDate = DateTime.Now;
                        branch.Creator = Kernel.AuthenticatedUser;

                        DB.BranchRepository.Add(branch);
                    }
                    else if (situation == (int)Constants.SITUATIONS.EDIT)
                    {
                        int id = viewModel.CurrentBranch.Id;
                        var existingBranch = DB.BranchRepository.FindById(id);
                        if(existingBranch != null)
                        {
                            existingBranch = BranchMapper.Map(viewModel.CurrentBranch, existingBranch);
                            existingBranch.CreationDate = DateTime.Now;
                            existingBranch.Creator = Kernel.AuthenticatedUser;
                            DB.BranchRepository.Update(existingBranch);
                        }
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
                }
            }
        }


        private bool IsValid()
        {
            var branch = viewModel.CurrentBranch;

            if(string.IsNullOrEmpty(branch.Name))
            {
                MessageBox.Show("Ad mütləq daxil edilməlidir!");
                return false;
            }

            if(branch.Name.Length > 50)
            {
                MessageBox.Show("Ad 50 simvoldan böyük ola bilməz!");
                return false;
            }

            if(branch.Address != null && branch.Address.Length > 50)
            {
                MessageBox.Show("Ünvan 50 simvoldan böyük ola bilməz!");
                return false;
            }

            if (branch.PhoneNumber != null && !BusinessUtil.PhoneMatches(branch.PhoneNumber))
            {
                MessageBox.Show("Telefon nömrəsi düzgün formatda deyil! (Düzgün format: +99450XXXXXXX)");
                return false;
            }

            return true;
        }
    
        private void CorrectData()
        {
            viewModel.CurrentBranch.Name = viewModel.CurrentBranch.Name.Trim(); 
            
            if(viewModel.CurrentBranch.Address != null)
            {
                viewModel.CurrentBranch.Address = viewModel.CurrentBranch.Address.Trim();
            }
            
            if(viewModel.CurrentBranch.PhoneNumber != null)
            {
                viewModel.CurrentBranch.PhoneNumber = viewModel.CurrentBranch.PhoneNumber.Trim();
            }
        }

    
    }
}
