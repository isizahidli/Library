using LibraryCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore.Domain.Entities
{
    public class Reservation
    {
        public Reservation()
        {
            Customer = new Customer();
            Room = new Room();
        }

        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Room Room { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public decimal Amount { get; set; }
        public Enum Status { get; set; }
    }
}
