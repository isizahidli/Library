using Library.Commands.CustomerCommands;
using Library.Models;
using Library.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels.UserControls
{
    public class CustomerViewModel:UCViewModel
    {
        public CustomerViewModel()
        {
            Header = "Customers";
        }

        public void InitializeViewModel()
        {
            CurrentCustomer = new CustomerModel();
            CurrentSituation = (int)Constants.SITUATIONS.NORMAL;
            selectedCustomer = null;
            customers = new List<CustomerModel>(AllCustomers);
            Enumerate.Execute(null);
        }

        private CustomerModel currentCustomer;
        public CustomerModel CurrentCustomer
        {
            get => currentCustomer;
            set
            {
                currentCustomer = value;
                OnPropertyChanged(nameof(CurrentCustomer));
            }
        }

        private CustomerModel selectedCustomer;
        public CustomerModel SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                if (value != null)
                {
                    CurrentCustomer = SelectedCustomer;
                    CurrentSituation = (int)Constants.SITUATIONS.SELECTED;
                }
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }

        public List<CustomerModel> AllCustomers;

        private List<CustomerModel> customers;
        public List<CustomerModel> Customers
        {
            get => customers ?? (customers = new List <CustomerModel>());
            set
            {
                customers = value;
                OnPropertyChanged(nameof(Customers));
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
                    Customers = new List<CustomerModel>(AllCustomers);
                }
                else
                {
                    Customers = AllCustomers.Where(x => x.Contains(searchText)).ToList();
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
