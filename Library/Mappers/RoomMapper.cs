using Library.Models;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Mappers
{
    public class RoomMapper
    {
        public static RoomModel Map(Room room)
        {
            var model = new RoomModel();
            
            model.Id = room.Id;
            model.FloorNo = room.FloorNo;
            model.IsSmoking = room.IsSmoking;
            model.PetFriendly = room.PetFriendly;
            model.PricePerNight = room.PricePerNight;
            model.RoomNumber = room.RoomNumber;
            model.Status = room.Status;
            model.RoomType = RoomTypeMapper.Map(room.RoomType);

            return model;
        }

        public static Room Map(RoomModel model)
        {
            Room destination = new Room();

            destination.Id = model.Id;
            destination.FloorNo = model.FloorNo;
            destination.IsSmoking = model.IsSmoking;
            destination.PetFriendly = model.PetFriendly;
            destination.PricePerNight = model.PricePerNight;
            destination.RoomNumber = model.RoomNumber;
            destination.Status = model.Status;
            destination.RoomType = RoomTypeMapper.Map(model.RoomType);

            return destination;
        }
    }
}
