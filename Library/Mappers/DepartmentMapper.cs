using Library.Models;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Mappers
{
    public class DepartmentMapper
    {
        public static DepartmentModel Map(Department department)
        {
            var model = new DepartmentModel();
            model.Id = department.Id;
            model.Name = department.Name;
            model.Description = department.Description;

            return model;
        }

        public static Department Map(DepartmentModel model)
        {
            Department destination = new Department();

            destination.Id = model.Id;
            destination.Name = model.Name;
            destination.Description = model.Description;

            return destination;
        }
    }
}
