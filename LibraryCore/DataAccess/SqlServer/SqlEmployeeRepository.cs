using LibraryCore.Domain.Abstract;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore.DataAccess.SqlServer
{
    public class SqlEmployeeRepository: SqlBaseRepository, IEmployeeRepository
    {
        public SqlEmployeeRepository(SqlContext context) : base(context)
        {
        }

        public int Add(Employee obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Employee FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee obj)
        {
            throw new NotImplementedException();
        }
    }
}
