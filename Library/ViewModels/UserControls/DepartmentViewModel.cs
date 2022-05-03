using Library.Commands.DepartmentCommands;
using Library.Models;
using Library.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels.UserControls
{
    public class DepartmentViewModel:UCViewModel
    {
        public DepartmentViewModel()
        {
            Header = "Departments";
        }

        public void InitializeViewModel()
        {
            CurrentDepartment = new DepartmentModel();
            CurrentSituation = (int)Constants.SITUATIONS.NORMAL;
            selectedDepartment = null;
            departments = new List<DepartmentModel>(AllDepartments);
            Enumerate.Execute(null);
        }

        private DepartmentModel currentDepartment;
        public DepartmentModel CurrentDepartment
        {
            get => currentDepartment;
            set
            {
                currentDepartment = value;
                OnPropertyChanged(nameof(CurrentDepartment));
            }
        }

        private DepartmentModel selectedDepartment;
        public DepartmentModel SelectedDepartment
        {
            get => selectedDepartment;
            set
            {
                selectedDepartment = value;
                if (value != null)
                {
                    CurrentDepartment = SelectedDepartment;
                    CurrentSituation = (int)Constants.SITUATIONS.SELECTED;
                }
                OnPropertyChanged(nameof(SelectedDepartment));
            }
        }

        public List<DepartmentModel> AllDepartments;

        private List<DepartmentModel> departments;
        public List<DepartmentModel> Departments
        {
            get => departments ?? (departments = new List<DepartmentModel>());
            set
            {
                departments = value;
                OnPropertyChanged(nameof(Departments));
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
                    // return all list;
                    Departments = new List<DepartmentModel>(AllDepartments);
                }
                else
                {
                    // lambda
                    Departments = AllDepartments.Where(x => x.Contains(searchText)).ToList();
                    #region commented lines

                    //var filteredList = new List<BranchModel>();
                    //foreach(var x in branches)
                    //{
                    //    if(x.Contains(searchText))
                    //    {
                    //        filteredList.Add(x);
                    //    }
                    //}

                    //branches = filteredList;

                    #endregion
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
