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
    public class OpenServicesCommand : MainPageBaseCommand
    {
        public OpenServicesCommand(MainPageViewModel viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            ServiceControl serviceControl = new ServiceControl();
            ServiceViewModel serviceViewModel = new ServiceViewModel();
            serviceViewModel.MessageDialog = serviceControl.MessageDialog;

            List<Service> services = DB.ServiceRepository.Get();
            List<ServiceModel> models = new List<ServiceModel>();
            foreach (var service in services)
            {
                var model = ServiceMapper.Map(service);
                models.Add(model);
            }

            serviceViewModel.AllServices = new List<ServiceModel>(models);
            serviceViewModel.InitializeViewModel();
            serviceControl.DataContext = serviceViewModel;

            viewModel.Grid.Children.Clear();
            viewModel.Grid.Children.Add(serviceControl);
        }
    }
}
