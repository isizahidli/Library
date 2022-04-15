using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore.Domain.Entities
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte MaxAdults { get; set; }
        public byte MaxChildren { get; set; }
        public decimal PricePerNight { get; set; }
        public string Description { get; set; }
    }
}
