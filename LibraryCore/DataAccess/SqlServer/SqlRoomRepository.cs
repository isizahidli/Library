using LibraryCore.Domain.Abstract;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore.DataAccess.SqlServer
{
    public class SqlRoomRepository : SqlBaseRepository, IRoomRepository
    {
        public SqlRoomRepository(SqlContext context) : base(context)
        {
        }

        public int Add(Room obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Room FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Room> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(Room obj)
        {
            throw new NotImplementedException();
        }
    }
}
