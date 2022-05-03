using LibraryCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class ServiceModel : BaseModel
    {
        public ServiceModel()
        {
            Department = new DepartmentModel();
        }

        public override object this[string propName]
        {
            get
            {
                if (this == null) return null;

                var type = typeof(ServiceModel);
                var props = type.GetProperties();
                var prop = props.FirstOrDefault(x => x.Name == propName);

                if (prop == null)
                    return null;

                return prop.GetValue(this);
            }
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DepartmentModel Department { get; set; }
        public Status Status { get; set; }
        public decimal Price { get; set; }

        public bool Contains(string searchText)
        {
            var lowerText = searchText.ToLower(); // or ToUpper()

            return (Name != null && Name.ToLower().Contains(lowerText)) ||
                    (Description != null && Description.ToLower().Contains(lowerText));
        }

    }
}
