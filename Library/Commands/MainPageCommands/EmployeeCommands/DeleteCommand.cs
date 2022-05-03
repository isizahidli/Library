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

namespace Library.Commands.EmployeeCommands
{
    public class DeleteCommand : EmployeeBaseCommand
    {
        public DeleteCommand(EmployeeViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            DialogViewModel dialogViewModel = new DialogViewModel();
            dialogViewModel.DialogText = "Silmək istədiyinizdən əminsinizmi?";

            Dialog dialog = new Dialog();
            dialog.DataContext = dialogViewModel;
            if (dialog.ShowDialog() == true)
            {
                int id = viewModel.SelectedEmployee.Id;
                DB.EmployeeRepository.Delete(id);

                viewModel.Message = "Əməliyyat uğurla həyata keçdi";
                BusinessUtil.DoAnimation(viewModel.MessageDialog);

                // reload all branches
                List<Employee> employees = DB.EmployeeRepository.Get();
                List<EmployeeModel> models = new List<EmployeeModel>();
                foreach (var entity in employees)
                {
                    var model = EmployeeMapper.Map(entity);
                    models.Add(model);
                }

                viewModel.Employees = new List<EmployeeModel>(models);
                viewModel.InitializeViewModel();

                Logger.LogInformation($"Employee: {id}  has been deleted");
            }
        }
    }
}
