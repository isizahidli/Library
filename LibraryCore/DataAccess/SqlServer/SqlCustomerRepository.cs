using LibraryCore.Domain.Abstract;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore.DataAccess.SqlServer
{
    public class SqlCustomerRepository: SqlBaseRepository, ICustomerRepository
    {
        public SqlCustomerRepository(SqlContext context) : base(context)
        {
        }

        public int Add(Customer obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer obj)
        {
            throw new NotImplementedException();
        }
    }
}
