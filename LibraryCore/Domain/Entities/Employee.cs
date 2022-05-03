using LibraryCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public Department Department { get; set; }
        public DateTime JoiningDate { get; set; }
        public decimal Salary { get; set; }
        public TimeSpan BeginWorkTime { get; set; }
        public TimeSpan EndWorkTime { get; set; }
        public Enum Status { get; set; }
    }
}
