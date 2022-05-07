using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class DepartmentModel : BaseModel
    {
        public override object this[string propName]
        {
            get
            {
                if (this == null) return null;

                var type = typeof(DepartmentModel);
                var props = type.GetProperties();
                var prop = props.FirstOrDefault(x => x.Name == propName);

                if (prop == null)
                    return null;

                return prop.GetValue(this);
            }
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Gender Gender { get; set; }

        public bool Contains(string searchText)
        {
            var lowerText = searchText.ToLower(); // or ToUpper()

            return (Name != null && Name.ToLower().Contains(lowerText)) ||
                    (Description != null && Description.ToLower().Contains(lowerText));
        }
    }
    public enum Gender 
    {
        Male = 1,
        Female = 0
    }
}
