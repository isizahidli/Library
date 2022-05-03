using LibraryCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class RoomModel : BaseModel
    {
        public RoomModel()
        {
            RoomType = new RoomTypeModel();
        }

        public override object this[string propName]
        {
            get
            {
                if (this == null) return null;

                var type = typeof(RoomModel);
                var props = type.GetProperties();
                var prop = props.FirstOrDefault(x => x.Name == propName);

                if (prop == null)
                    return null;

                return prop.GetValue(this);
            }
        }

        public int RoomNumber { get; set; }
        public byte FloorNo { get; set; }
        public RoomTypeModel RoomType { get; set; }
        public Status Status { get; set; }
        public decimal PricePerNight { get; set; }
        public bool PetFriendly { get; set; }
        public bool IsSmoking { get; set; }

        public bool Contains(string searchText)
        {
            var lowerText = searchText.ToLower(); // or ToUpper()

            return (RoomType.Name != null && RoomType.Name.ToLower().Contains(lowerText)) ||
                    (RoomNumber.ToString().ToLower().Contains(lowerText));
        }
    }
}
