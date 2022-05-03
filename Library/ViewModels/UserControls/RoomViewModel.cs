using Library.Commands.RoomCommands;
using Library.Models;
using Library.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels.UserControls
{
    public class RoomViewModel : UCViewModel
    {
        public RoomViewModel()
        {
            Header = "Rooms";
        }

        public void InitializeViewModel()
        {
            CurrentRoom = new RoomModel();
            CurrentSituation = (int)Constants.SITUATIONS.NORMAL;
            selectedRoom = null;
            rooms = new List<RoomModel>(AllRooms);
            Enumerate.Execute(null);
        }

        private RoomModel currentRoom;
        public RoomModel CurrentRoom
        {
            get => currentRoom;
            set
            {
                currentRoom = value;
                OnPropertyChanged(nameof(CurrentRoom));
            }
        }

        private RoomModel selectedRoom;
        public RoomModel SelectedRoom
        {
            get => selectedRoom;
            set
            {
                selectedRoom = value;
                if (value != null)
                {
                    CurrentRoom = SelectedRoom;
                    CurrentSituation = (int)Constants.SITUATIONS.SELECTED;
                }
                OnPropertyChanged(nameof(SelectedRoom));
            }
        }

        public List<RoomModel> AllRooms;

        private List<RoomModel> rooms;
        public List<RoomModel> Rooms
        {
            get => rooms ?? (rooms = new List<RoomModel>());
            set
            {
                rooms = value;
                OnPropertyChanged(nameof(Rooms));
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
                    Rooms = new List<RoomModel>(AllRooms);
                }
                else
                {
                    Rooms = AllRooms.Where(x => x.Contains(searchText)).ToList();
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
