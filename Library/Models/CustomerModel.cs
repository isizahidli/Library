using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class CustomerModel : BaseModel
    {
        public override object this[string propName]
        {
            get
            {
                if (propName == null) return null;

                var type = typeof(CustomerModel);
                var props = type.GetProperties();
                var prop = props.FirstOrDefault(x => x.Name == propName);

                if (prop == null) return null;

                return prop.GetValue(this);
            }
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PassportNo { get; set; }
        public bool Gender { get; set; }

        public bool Contains(string searchText)
        {
            var lowerText = searchText.ToLower(); // or ToUpper()

            return (Name != null && Name.ToLower().Contains(lowerText)) ||
                    (Surname != null && Surname.ToLower().Contains(lowerText)) ||
                    (Address != null && Address.ToLower().Contains(lowerText)) ||
                    (PhoneNumber != null && PhoneNumber.ToLower().Contains(lowerText)) ||
                    (Email != null && Email.ToLower().Contains(lowerText)) ||
                    (Country != null && Country.ToLower().Contains(lowerText)) ||
                    (City != null && City.ToLower().Contains(lowerText)) ||
                    (ZipCode != null && ZipCode.ToLower().Contains(lowerText)) ||
                    (PassportNo != null && PassportNo.ToLower().Contains(lowerText));
        }
    }
}
