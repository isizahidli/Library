using Library.Models;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Mappers
{
    public class BranchMapper
    {
        public static BranchModel Map(Branch1 branch)
        {
            var model = new BranchModel();
            model.Id = branch.Id;
            model.Name = branch.Name;
            model.Address = branch.Address;
            model.PhoneNumber = branch.Phone;
            model.Note = branch.Note;

            return model;
        }

        public static Branch1 Map(BranchModel model, Branch1 destination)
        {
            destination.Id = model.Id;
            destination.Name = model.Name;
            destination.Address = model.Address;
            destination.Phone = model.PhoneNumber;
            destination.Note = model.Note;

            return destination;
        }

    }
}
