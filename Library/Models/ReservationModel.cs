using LibraryCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class ReservationModel : BaseModel
    {
        public override object this[string propName]
        {
            get
            {
                if (this == null) return null;

                var type = typeof(ReservationModel);
                var props = type.GetProperties();
                var prop = props.FirstOrDefault(x => x.Name == propName);

                if (prop == null)
                    return null;

                return prop.GetValue(this);
            }
        }

        public CustomerModel Customer { get; set; }
        public RoomModel Room { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public decimal Amount { get; set; }
        public Status Status { get; set; }

        public bool Contains(string searchText)
        {
            var lowerText = searchText.ToLower(); // or ToUpper()

            return (Customer.Name != null && Customer.Name.ToLower().Contains(lowerText));
        }
    }
}
