using Library.Models;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Mappers
{
    public class CustomerMapper
    {
        public static CustomerModel Map(Customer customer)
        {
            var model = new CustomerModel();

            model.Id = customer.Id;
            model.Name = customer.Name;
            model.PassportNo = customer.PassportNo;
            model.PhoneNumber = customer.PhoneNumber;
            model.Surname = customer.Surname;
            model.ZipCode = customer.ZipCode;
            model.Email = customer.Email;
            model.Address = customer.Address;
            model.City = customer.City;
            model.Country = customer.Country;

            return model;
        }

        public static Customer Map(CustomerModel model)
        {
            Customer destination = new Customer();

            destination.Id = model.Id;
            destination.Name = model.Name;
            destination.PassportNo = model.PassportNo;
            destination.PhoneNumber = model.PhoneNumber;
            destination.Surname = model.Surname;
            destination.ZipCode = model.ZipCode;
            destination.Email = model.Email;
            destination.Address = model.Address;
            destination.City = model.City;
            destination.Country = model.Country;

            return destination;
        }
    }
}
