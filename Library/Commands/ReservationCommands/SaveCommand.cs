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

namespace Library.Commands.ReservationCommands
{
    public class SaveCommand : ReservationBaseCommand
    {
        public SaveCommand(ReservationViewModel viewModel) : base(viewModel) { }

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
                        var reservation = ReservationMapper.Map(viewModel.CurrentReservation);

                        DB.ReservationRepository.Add(reservation);
                    }
                    else if (situation == (int)Constants.SITUATIONS.EDIT)
                    {
                        int id = viewModel.CurrentReservation.Id;
                        var existingRoom = DB.ReservationRepository.FindById(id);
                        if (existingRoom != null)
                        {
                            existingRoom = ReservationMapper.Map(viewModel.CurrentReservation);
                            existingRoom.Id = id;

                            DB.ReservationRepository.Update(existingRoom);
                        }
                    }

                    viewModel.Message = "Əməliyyat uğurla həyata keçdi";
                    BusinessUtil.DoAnimation(viewModel.MessageDialog);

                    List<Reservation> reservations = DB.ReservationRepository.Get();
                    List<ReservationModel> models = new List<ReservationModel>();
                    foreach (var entity in reservations)
                    {
                        var model = ReservationMapper.Map(entity);
                        models.Add(model);
                    }

                    viewModel.AllReservations = new List<ReservationModel>(models);
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
