using Library.Models;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Mappers
{
    public static class ReservationMapper
    {
        public static ReservationModel Map(Reservation reservation)
        {
            var model = new ReservationModel();

            model.Id = reservation.Id;
            model.Customer = CustomerMapper.Map(reservation.Customer);
            model.Room = RoomMapper.Map(reservation.Room);
            model.ReservationDate = reservation.ReservationDate;
            model.CheckInDate = reservation.CheckInDate;
            model.CheckOutDate = reservation.CheckOutDate;
            model.Adults = reservation.Adults;
            model.Children = reservation.Children;
            model.Amount = reservation.Amount;
            model.Status = reservation.Status;
           
            return model;
        }

        public static Reservation Map(ReservationModel model)
        {
            Reservation destination = new Reservation();

            destination.Id = model.Id;
            destination.Customer = CustomerMapper.Map(model.Customer);
            destination.Room = RoomMapper.Map(model.Room);
            destination.ReservationDate = model.ReservationDate;
            destination.CheckInDate = model.CheckInDate;
            destination.CheckOutDate = model.CheckOutDate;
            destination.Adults = model.Adults;
            destination.Children = model.Children;
            destination.Amount = model.Amount;
            destination.Status = model.Status;

            return destination;
        }
    }
}
