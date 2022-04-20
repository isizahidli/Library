using Library.Models;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Mappers
{
    public class EmployeeMapper
    {
        public static EmployeeModel Map(Employee employee)
        {
            var model = new EmployeeModel();

            model.Id = employee.Id;
            model.Name = employee.Name;
            model.PhoneNumber = employee.PhoneNumber;
            model.Surname = employee.Surname;
            model.Address = employee.Address;
            model.BeginWorkTime = employee.BeginWorkTime;
            model.BirthDate = employee.BirthDate;
            model.EndWorkTime = employee.EndWorkTime;
            model.Gender = employee.Gender;
            model.Salary = employee.Salary;
            model.JoiningDate = employee.JoiningDate;
            model.Department = DepartmentMapper.Map(employee.Department);

            return model;
        }

        public static Employee Map(EmployeeModel model)
        {
            Employee destination = new Employee();

            destination.Id = model.Id;
            destination.Name = model.Name;
            destination.PhoneNumber = model.PhoneNumber;
            destination.Surname = model.Surname;
            destination.Address = model.Address;
            destination.BeginWorkTime = model.BeginWorkTime;
            destination.BirthDate = model.BirthDate;
            destination.EndWorkTime = model.EndWorkTime;
            destination.Gender = model.Gender;
            destination.Salary = model.Salary;
            destination.JoiningDate = model.JoiningDate;
            destination.Department = DepartmentMapper.Map(model.Department);

            return destination;
        }
    }
}
