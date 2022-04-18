using LibraryCore.Domain.Abstract;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore.DataAccess.SqlServer
{
    public class SqlDepartmentRepository :SqlBaseRepository, IDepartmentRepository
    {
        public SqlDepartmentRepository(SqlContext context) : base(context)
        {
        }

        public int Add(Department obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Department FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Department> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(Department obj)
        {
            throw new NotImplementedException();
        }
    }
}
