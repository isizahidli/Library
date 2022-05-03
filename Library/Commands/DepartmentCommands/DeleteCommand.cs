using Library.Commands.ServiceCommands;
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

namespace Library.Commands.DepartmentCommands
{
    public class DeleteCommand : DepartmentBaseCommand
    {
        public DeleteCommand(DepartmentViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            DialogViewModel dialogViewModel = new DialogViewModel();
            dialogViewModel.DialogText = "Silmək istədiyinizdən əminsinizmi?";

            Dialog dialog = new Dialog();
            dialog.DataContext = dialogViewModel;
            if (dialog.ShowDialog() == true)
            {
                int id = viewModel.SelectedDepartment.Id;
                DB.DepartmentRepository.Delete(id);

                viewModel.Message = "Əməliyyat uğurla həyata keçdi";
                BusinessUtil.DoAnimation(viewModel.MessageDialog);

                // reload all branches
                List<Department> departments = DB.DepartmentRepository.Get();
                List<DepartmentModel> models = new List<DepartmentModel>();
                foreach (var entity in departments)
                {
                    var model = DepartmentMapper.Map(entity);
                    models.Add(model);
                }

                viewModel.Departments = new List<DepartmentModel>(models);
                viewModel.InitializeViewModel();

                Logger.LogInformation($"Department: {id}  has been deleted");
            }
        }
    }
}
