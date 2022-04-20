using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class EmployeeModel : BaseModel
    {
        public override object this[string propName]
        {
            get
            {
                if (this == null) return null;

                var type = typeof(EmployeeModel);
                var props = type.GetProperties();
                var prop = props.FirstOrDefault(x => x.Name == propName);

                if (prop == null)
                    return null;

                return prop.GetValue(this);
            }
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public DepartmentModel Department { get; set; }
        public DateTime JoiningDate { get; set; }
        public decimal Salary { get; set; }
        public TimeSpan BeginWorkTime { get; set; }
        public TimeSpan EndWorkTime { get; set; }

        public bool Contains(string searchText)
        {
            var lowerText = searchText.ToLower(); // or ToUpper()

            return (Name != null && Name.ToLower().Contains(lowerText)) ||
                    (Surname != null && Surname.ToLower().Contains(lowerText)) ||
                    (PhoneNumber != null && PhoneNumber.ToLower().Contains(lowerText)) ||
                    (Address != null && Address.ToLower().Contains(lowerText)) ||
                    Department.Contains(lowerText);
        }
    }
}
