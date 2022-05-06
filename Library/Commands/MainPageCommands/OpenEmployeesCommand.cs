using Library.Mappers;
using Library.Models;
using Library.ViewModels;
using Library.ViewModels.UserControls;
using Library.Views.UserControls;
using LibraryCore.Domain.Entities;
using LibraryCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.MainPageCommands
{
    public class OpenEmployeesCommand : MainPageBaseCommand
    {
        public OpenEmployeesCommand(MainPageViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            EmployeeControl employeeControl = new EmployeeControl();
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.MessageDialog = employeeControl.MessageDialog;

            List<Employee> employees = DB.EmployeeRepository.Get();
            List<EmployeeModel> models = new List<EmployeeModel>();
            foreach (var roomType in employees)
            {
                var model = EmployeeMapper.Map(roomType);
                models.Add(model);
            }

            List<Department> departments= DB.DepartmentRepository.Get().Where(x => x.Status == Status.Active).ToList();
            List<DepartmentModel> depModels = new List<DepartmentModel>();
            foreach (var department in departments)
            {
                var model = DepartmentMapper.Map(department);
                depModels.Add(model);
            }

            employeeViewModel.Departments = depModels;
            employeeViewModel.AllEmployees = new List<EmployeeModel>(models);
            employeeViewModel.InitializeViewModel();
            employeeControl.DataContext = employeeViewModel;

            viewModel.Grid.Children.Clear();
            viewModel.Grid.Children.Add(employeeControl);
        }
    }
}
