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

namespace Library.Commands.ServiceCommands
{
    public class SaveCommand : ServiceBaseCommand
    {
        public SaveCommand(ServiceViewModel viewModel) : base(viewModel) { }

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
                        var service = ServiceMapper.Map(viewModel.CurrentService);

                        DB.ServiceRepository.Add(service);
                    }
                    else if (situation == (int)Constants.SITUATIONS.EDIT)
                    {
                        int id = viewModel.CurrentService.Id;
                        var existingService = DB.ServiceRepository.FindById(id);
                        if (existingService != null)
                        {
                            existingService = ServiceMapper.Map(viewModel.CurrentService);
                            existingService.Id = id;

                            DB.ServiceRepository.Update(existingService);
                        }
                    }

                    viewModel.Message = "Əməliyyat uğurla həyata keçdi";
                    BusinessUtil.DoAnimation(viewModel.MessageDialog);

                    // reload all branches
                    List<Service> services = DB.ServiceRepository.Get();
                    List<ServiceModel> models = new List<ServiceModel>();
                    foreach (var entity in services)
                    {
                        var model = ServiceMapper.Map(entity);
                        models.Add(model);
                    }

                    viewModel.AllServices = new List<ServiceModel>(models);
                    viewModel.InitializeViewModel();
                }
            }
        }

        private bool IsValid()
        {
            var branch = viewModel.CurrentService;

            if (string.IsNullOrEmpty(branch.Name))
            {
                MessageBox.Show("Ad mütləq daxil edilməlidir!");
                return false;
            }

            if (branch.Name.Length > 50)
            {
                MessageBox.Show("Ad 50 simvoldan böyük ola bilməz!");
                return false;
            }

            return true;
        }

        private void CorrectData()
        {
            viewModel.CurrentService.Name = viewModel.CurrentService.Name.Trim();
        }
    }
}
