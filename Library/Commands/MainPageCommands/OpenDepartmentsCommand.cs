using Library.Mappers;
using Library.Models;
using Library.ViewModels;
using Library.ViewModels.UserControls;
using Library.Views.UserControls;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands.MainPageCommands
{
    public class OpenDepartmentsCommand : MainPageBaseCommand
    {
        public OpenDepartmentsCommand(MainPageViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            DepartmentControl departmentControl = new DepartmentControl();
            DepartmentViewModel departmentViewModel = new DepartmentViewModel();
            departmentViewModel.MessageDialog = departmentControl.MessageDialog;

            List<Department> departments = DB.DepartmentRepository.Get();
            List<DepartmentModel> models = new List<DepartmentModel>();
            foreach (var department in departments)
            {
                var model = DepartmentMapper.Map(department);
                models.Add(model);
            }

            departmentViewModel.AllDepartments = new List<DepartmentModel>(models);
            departmentViewModel.InitializeViewModel();
            departmentControl.DataContext = departmentViewModel;

            viewModel.Grid.Children.Clear();
            viewModel.Grid.Children.Add(departmentControl);
        }
    }
}
