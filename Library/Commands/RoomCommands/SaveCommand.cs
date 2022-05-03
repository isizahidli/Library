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

namespace Library.Commands.RoomCommands
{
    public class SaveCommand : RoomBaseCommand
    {
        public SaveCommand(RoomViewModel viewModel) : base(viewModel) { }

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
                        var room = RoomMapper.Map(viewModel.CurrentRoom);

                        DB.RoomRepository.Add(room);
                    }
                    else if (situation == (int)Constants.SITUATIONS.EDIT)
                    {
                        int id = viewModel.CurrentRoom.Id;
                        var existingRoomType = DB.RoomRepository.FindById(id);
                        if (existingRoomType != null)
                        {
                            existingRoomType = RoomMapper.Map(viewModel.CurrentRoom);
                            existingRoomType.Id = id;

                            DB.RoomRepository.Update(existingRoomType);
                        }
                    }

                    viewModel.Message = "Əməliyyat uğurla həyata keçdi";
                    BusinessUtil.DoAnimation(viewModel.MessageDialog);

                    List<Room> services = DB.RoomRepository.Get();
                    List<RoomModel> models = new List<RoomModel>();
                    foreach (var entity in services)
                    {
                        var model = RoomMapper.Map(entity);
                        models.Add(model);
                    }

                    viewModel.AllRooms = new List<RoomModel>(models);
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
