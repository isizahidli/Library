using Library.Commands.ServiceCommands;
using Library.Models;
using Library.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels.UserControls
{
    public class ServiceViewModel : UCViewModel
    {
        public ServiceViewModel()
        {
            Header = "Services";
        }

        public void InitializeViewModel()
        {
            CurrentService = new ServiceModel();
            CurrentSituation = (int)Constants.SITUATIONS.NORMAL;
            selectedService = null;
            services = new List<ServiceModel>(AllServices);
            Enumerate.Execute(null);
        }

        private ServiceModel currentService;
        public ServiceModel CurrentService
        {
            get => currentService;
            set
            {
                currentService = value;
                OnPropertyChanged(nameof(CurrentService));
            }
        }

        private ServiceModel selectedService;
        public ServiceModel SelectedService
        {
            get => selectedService;
            set
            {
                selectedService = value;
                if (value != null)
                {
                    CurrentService = SelectedService;
                    CurrentSituation = (int)Constants.SITUATIONS.SELECTED;
                }
                OnPropertyChanged(nameof(SelectedService));
            }
        }

        public List<ServiceModel> AllServices;

        private List<ServiceModel> services;
        public List<ServiceModel> Services
        {
            get => services ?? (services = new List<ServiceModel>());
            set
            {
                services = value;
                OnPropertyChanged(nameof(Services));
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
                    Services = new List<ServiceModel>(AllServices);
                }
                else
                {
                    Services = AllServices.Where(x => x.Contains(searchText)).ToList();
                }

                Enumerate.Execute(null);
            }
        }

        #region Commands

        public SaveCommand Save => new SaveCommand(this);
        public RejectCommand Reject => new RejectCommand(this);
        public DeleteCommand Delete => new DeleteCommand(this);
        public EnumerateCommand Enumerate => new EnumerateCommand(this);
        //public ExportExcelCommand ExportExcel => new ExportExcelCommand(this);
        //public ExportPdfCommand ExportPdf => new ExportPdfCommand(this);

        #endregion
    }
}
