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

namespace Library.Commands.RoomTypeCommands
{
    public class SaveCommand : RoomTypeBaseCommand
    {
        public SaveCommand(RoomTypeViewModel viewModel) : base(viewModel) { }

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
                        var service = RoomTypeMapper.Map(viewModel.CurrentRoomType);

                        DB.RoomTypeRepository.Add(service);
                    }
                    else if (situation == (int)Constants.SITUATIONS.EDIT)
                    {
                        int id = viewModel.CurrentRoomType.Id;
                        var existingRoomType = DB.RoomTypeRepository.FindById(id);
                        if (existingRoomType != null)
                        {
                            existingRoomType = RoomTypeMapper.Map(viewModel.CurrentRoomType);
                            existingRoomType.Id = id;

                            DB.RoomTypeRepository.Update(existingRoomType);
                        }
                    }

                    viewModel.Message = "Əməliyyat uğurla həyata keçdi";
                    BusinessUtil.DoAnimation(viewModel.MessageDialog);

                    List<RoomType> services = DB.RoomTypeRepository.Get();
                    List<RoomTypeModel> models = new List<RoomTypeModel>();
                    foreach (var entity in services)
                    {
                        var model = RoomTypeMapper.Map(entity);
                        models.Add(model);
                    }

                    viewModel.AllRoomTypes = new List<RoomTypeModel>(models);
                    viewModel.InitializeViewModel();
                }
            }
        }

        private bool IsValid()
        {
            var branch = viewModel.CurrentRoomType;

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
            viewModel.CurrentRoomType.Name = viewModel.CurrentRoomType.Name.Trim();
        }
    }
}
