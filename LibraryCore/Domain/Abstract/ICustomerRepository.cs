using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore.Domain.Abstract
{
    interface ICustomerRepository: IRepository<Customer>
    {
    }
}
