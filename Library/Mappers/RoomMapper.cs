using Library.Models;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Mappers
{
    public static class RoomMapper
    {
        public static RoomModel Map(Room room)
        {
            var model = new RoomModel();
            model.Id = room.Id;
            model.RoomNumber = room.RoomNumber;
            model.FloorNo = room.FloorNo;
            model.PricePerNight = room.PricePerNight;
            model.PetFriendly = room.PetFriendly;
            model.IsSmoking = room.IsSmoking;
            model.Status = room.Status;

            return model;
        }

        public static Room Map(RoomModel model)
        {
            Room destination = new Room();

            destination.Id = model.Id;
            destination.RoomNumber= model.RoomNumber;
            destination.FloorNo = model.FloorNo;
            destination.PricePerNight = model.PricePerNight;
            destination.PetFriendly = model.PetFriendly;
            destination.IsSmoking = model.IsSmoking;
            destination.Status = model.Status;
           

            return destination;
        }
    }
}

