using Library.Mappers;
using Library.Models;
using Library.Utils;
using Library.ViewModels.UserControls;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library.Commands.EmployeeCommands
{
    public class SaveCommand : EmployeeBaseCommand
    {
        public SaveCommand(EmployeeViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            int situation = viewModel.CurrentSituation;
            if (situation == (int)Constants.SITUATIONS.NORMAL)
            {
                viewModel.CurrentSituation = (int)Constants.SITUATIONS.ADD;
            }
            else if (situation == (int)Constants.SITUATIONS.SELECTED)
            {
                viewModel.CurrentSituation = (int)Constants.SITUATIONS.EDIT;
            }
            else
            {
                if (IsValid())
                {
                    CorrectData();

                    if (situation == (int)Constants.SITUATIONS.ADD)
                    {
                        var employee = EmployeeMapper.Map(viewModel.CurrentEmployee);

                        DB.EmployeeRepository.Add(employee);
                    }
                    else if (situation == (int)Constants.SITUATIONS.EDIT)
                    {
                        int id = viewModel.CurrentEmployee.Id;
                        var existingEmployee = DB.EmployeeRepository.FindById(id);
                        if (existingEmployee != null)
                        {
                            existingEmployee = EmployeeMapper.Map(viewModel.CurrentEmployee);
                            existingEmployee.Id = id;

                            DB.EmployeeRepository.Update(existingEmployee);
                        }
                    }

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

                    viewModel.AllEmployees = new List<EmployeeModel>(models);
                    viewModel.InitializeViewModel();
                }
            }
        }

        private bool IsValid()
        {
            //Data is valid

            return true;
        }

        private void CorrectData()
        {
            //Data is correct
        }
    }
}
