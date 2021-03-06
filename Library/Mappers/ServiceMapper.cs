using Library.Models;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Mappers
{
    public class ServiceMapper
    {
        public static ServiceModel Map(Service service)
        {
            var model = new ServiceModel();

            model.Id = service.Id;
            model.Name = service.Name;
            model.Description = service.Description;
            model.Status = service.Status;
            model.Price = service.Price;
            model.Department.Id = service.Department.Id;
            model.Department.Name = service.Department.Name;

            return model;
        }

        public static Service Map(ServiceModel model)
        {
            Service destination = new Service();

            destination.Id = model.Id;
            destination.Name = model.Name;
            destination.Description = model.Description;
            destination.Status = model.Status;
            destination.Price = model.Price;
            destination.Department.Id = model.Department.Id;
            destination.Department.Name = model.Department.Name;

            return destination;
        }
    }
}
