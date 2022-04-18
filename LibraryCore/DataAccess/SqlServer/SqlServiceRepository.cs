using LibraryCore.Domain.Abstract;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore.DataAccess.SqlServer
{
    public class SqlServiceRepository: SqlBaseRepository, IServiceRepository
    {
        public SqlServiceRepository(SqlContext context) : base(context)
        {
        }

        public int Add(Service obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Service FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Service> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(Service obj)
        {
            throw new NotImplementedException();
        }
    }
}
