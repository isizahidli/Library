using Library.Models;
using Library.Utils;
using Library.Commands.ReservationCommands;
using Library.Models;
using Library.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels.UserControls
{
    public class ReservationViewModel:UCViewModel
    {
        public ReservationViewModel()
        {
            Header = "Reservations";
        }

        public void InitializeViewModel()
        {
            CurrentReservation = new ReservationModel();
            CurrentSituation = (int)Constants.SITUATIONS.NORMAL;
            selectedReservation = null;
            reservations = new List<ReservationModel> (AllReservations);
            Enumerate.Execute(null);
        }

        public List<RoomModel> Rooms { get; set; }
        public List<CustomerModel> Customers { get; set; }

        private ReservationModel currentReservation;
        public ReservationModel CurrentReservation
        {
            get => currentReservation;
            set
            {
                currentReservation = value;
                OnPropertyChanged(nameof(CurrentReservation));
            }
        }

        private ReservationModel selectedReservation;
        public ReservationModel SelectedReservation
        {
            get => selectedReservation;
            set
            {
                selectedReservation = value;
                if (value != null)
                {
                    CurrentReservation = SelectedReservation;
                    CurrentSituation = (int)Constants.SITUATIONS.SELECTED;
                }
                OnPropertyChanged(nameof(SelectedReservation));
            }
        }

        public List<ReservationModel> AllReservations;

        private List<ReservationModel> reservations;
        public List<ReservationModel> Reservations
        {
            get => reservations ?? (reservations = new List<ReservationModel>());
            set
            {
                reservations = value;
                OnPropertyChanged(nameof(Reservations));
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
                    Reservations = new List<ReservationModel>(AllReservations);
                }
                else
                {
                    Reservations = AllReservations.Where(x => x.Contains(searchText)).ToList();
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
