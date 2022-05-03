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

namespace Library.Commands.CustomerCommands
{
    public class DeleteCommand : CustomerBaseCommand
    {
        public DeleteCommand(CustomerViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            DialogViewModel dialogViewModel = new DialogViewModel();
            dialogViewModel.DialogText = "Silmək istədiyinizdən əminsinizmi?";

            Dialog dialog = new Dialog();
            dialog.DataContext = dialogViewModel;
            if (dialog.ShowDialog() == true)
            {
                int id = viewModel.SelectedCustomer.Id;
                DB.CustomerRepository.Delete(id);

                viewModel.Message = "Əməliyyat uğurla həyata keçdi";
                BusinessUtil.DoAnimation(viewModel.MessageDialog);

                // reload all branches
                List<Customer> customers = DB.CustomerRepository.Get();
                List<CustomerModel> models = new List<CustomerModel>();
                foreach (var entity in customers)
                {
                    var model = CustomerMapper.Map(entity);
                    models.Add(model);
                }

                viewModel.Customers = new List<CustomerModel>(models);
                viewModel.InitializeViewModel();

                Logger.LogInformation($"Customer: {id}  has been deleted");
            }
        }
    }
}
