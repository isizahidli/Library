using LibraryCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore.Domain.Entities
{
    public class Room
    {
        public Room()
        {
            RoomType = new RoomType();
        }

        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public byte FloorNo { get; set; }
        public RoomType RoomType { get; set; }
        public Status Status { get; set; }
        public decimal PricePerNight { get; set; }
        public bool PetFriendly { get; set; }
        public bool IsSmoking { get; set; }
    }
}
