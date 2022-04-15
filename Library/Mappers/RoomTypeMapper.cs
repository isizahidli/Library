using Library.Models;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Mappers
{
    public static class RoomTypeMapper
    {
        public static RoomTypeModel Map(RoomType roomType)
        {
            var model = new RoomTypeModel();
            model.Id = roomType.Id;
            model.Name = roomType.Name;
            model.MaxAdults = roomType.MaxAdults;
            model.MaxChildren = roomType.MaxChildren;
            model.Description = roomType.Description;
            model.PricePerNight = roomType.PricePerNight;

            return model;
        }

        public static RoomType Map(RoomTypeModel model)
        {
            RoomType destination = new RoomType();

            destination.Id = model.Id;
            destination.Name = model.Name;
            destination.MaxChildren = model.MaxChildren;
            destination.MaxAdults = model.MaxAdults;
            destination.PricePerNight = model.PricePerNight;
            destination.Description = model.Description;

            return destination;
        }
    }
}
