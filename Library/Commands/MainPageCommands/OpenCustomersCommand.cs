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
    public class OpenCustomersCommand : MainPageBaseCommand
    {
        public OpenCustomersCommand(MainPageViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            CustomerControl customerControl = new CustomerControl();
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.MessageDialog = customerControl.MessageDialog;

            List<Customer> customers = DB.CustomerRepository.Get();
            List<CustomerModel> models = new List<CustomerModel>();
            foreach (var department in customers)
            {
                var model = CustomerMapper.Map(department);
                models.Add(model);
            }

            customerViewModel.AllCustomers = new List<CustomerModel>(models);
            customerViewModel.InitializeViewModel();
            customerControl.DataContext = customerViewModel;

            viewModel.Grid.Children.Clear();
            viewModel.Grid.Children.Add(customerControl);
        }
    }
}
