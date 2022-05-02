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

namespace Library.Commands.ServiceCommands
{
    public class DeleteCommand : ServiceBaseCommand
    {
        public DeleteCommand(ServiceViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            DialogViewModel dialogViewModel = new DialogViewModel();
            dialogViewModel.DialogText = "Silmək istədiyinizdən əminsinizmi?";

            Dialog dialog = new Dialog();
            dialog.DataContext = dialogViewModel;
            if (dialog.ShowDialog() == true)
            {
                int id = viewModel.SelectedService.Id;
                var branch = DB.ServiceRepository.Delete(id);

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

                viewModel.Services = new List<ServiceModel>(models);
                viewModel.InitializeViewModel();

                Logger.LogInformation($"Branch: {id}  has been deleted");
            }
        }
    }
}
