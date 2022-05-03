using Library.Commands.EmployeeCommands;
using Library.Models;
using Library.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels.UserControls
{
    public class EmployeeViewModel:UCViewModel
    {
        public EmployeeViewModel()
        {
            Header = "Employees";
        }

        public void InitializeViewModel()
        {
            CurrentEmployee = new EmployeeModel();
            CurrentSituation = (int)Constants.SITUATIONS.NORMAL;
            selectedEmployee = null;
            employees = new List<EmployeeModel>(AllEmployees);
            Enumerate.Execute(null);
        }

        private EmployeeModel currentEmployee;
        public EmployeeModel CurrentEmployee
        {
            get => currentEmployee;
            set
            {
                currentEmployee = value;
                OnPropertyChanged(nameof(CurrentEmployee));
            }
        }

        private EmployeeModel selectedEmployee;
        public EmployeeModel SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;
                if (value != null)
                {
                    CurrentEmployee = SelectedEmployee;
                    CurrentSituation = (int)Constants.SITUATIONS.SELECTED;
                }
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }

        public List<EmployeeModel> AllEmployees;

        private List<EmployeeModel> employees;
        public List<EmployeeModel> Employees
        {
            get => employees ?? (employees = new List<EmployeeModel>());
            set
            {
                employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }


        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                // search here
                searchText = value;

                if (string.IsNullOrEmpty(value))
                {
                    Employees = new List<EmployeeModel>(AllEmployees);
                }
                else
                {
                    Employees = AllEmployees.Where(x => x.Contains(searchText)).ToList();
                }

                Enumerate.Execute(null);
            }
        }

        #region Commands

        public SaveCommand Save => new SaveCommand(this);
        public RejectCommand Reject => new RejectCommand(this);
        public DeleteCommand Delete => new DeleteCommand(this);
        public EnumerateCommand Enumerate => new EnumerateCommand(this);

        #endregion
    }
}
