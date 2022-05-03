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

namespace Library.Commands.CustomerCommands
{
    public class SaveCommand : CustomerBaseCommand
    {
        public SaveCommand(CustomerViewModel viewModel) : base(viewModel) { }

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
                        var customer = CustomerMapper.Map(viewModel.CurrentCustomer);

                        DB.CustomerRepository.Add(customer);
                    }
                    else if (situation == (int)Constants.SITUATIONS.EDIT)
                    {
                        int id = viewModel.CurrentCustomer.Id;
                        var existingCustomer = DB.CustomerRepository.FindById(id);
                        if (existingCustomer != null)
                        {
                            existingCustomer = CustomerMapper.Map(viewModel.CurrentCustomer);
                            existingCustomer.Id = id;

                            DB.CustomerRepository.Update(existingCustomer);
                        }
                    }

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

                    viewModel.AllCustomers = new List<CustomerModel>(models);
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
