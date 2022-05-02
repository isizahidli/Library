using Library.Commands.RoomTypeCommands;
using Library.Models;
using Library.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels.UserControls
{
    public class RoomTypeViewModel : UCViewModel
    {
        public RoomTypeViewModel()
        {
            Header = "Room types";
        }

        public void InitializeViewModel()
        {
            CurrentRoomType = new RoomTypeModel();
            CurrentSituation = (int)Constants.SITUATIONS.NORMAL;
            selectedRoomType = null;
            roomTypes = new List<RoomTypeModel>(AllRoomTypes);
            Enumerate.Execute(null);
        }

        private RoomTypeModel currentRoomType;
        public RoomTypeModel CurrentRoomType
        {
            get => currentRoomType;
            set
            {
                currentRoomType = value;
                OnPropertyChanged(nameof(CurrentRoomType));
            }
        }

        private RoomTypeModel selectedRoomType;
        public RoomTypeModel SelectedRoomType
        {
            get => selectedRoomType;
            set
            {
                selectedRoomType = value;
                if (value != null)
                {
                    CurrentRoomType = SelectedRoomType;
                    CurrentSituation = (int)Constants.SITUATIONS.SELECTED;
                }
                OnPropertyChanged(nameof(SelectedRoomType));
            }
        }

        public List<RoomTypeModel> AllRoomTypes;

        private List<RoomTypeModel> roomTypes;
        public List<RoomTypeModel> RoomTypes
        {
            get => roomTypes ?? (roomTypes = new List<RoomTypeModel>());
            set
            {
                roomTypes = value;
                OnPropertyChanged(nameof(RoomTypes));
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
                    RoomTypes = new List<RoomTypeModel>(AllRoomTypes);
                }
                else
                {
                    // lambda
                    RoomTypes = AllRoomTypes.Where(x => x.Contains(searchText)).ToList();
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
