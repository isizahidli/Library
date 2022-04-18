using LibraryCore.Domain.Abstract;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore.DataAccess.SqlServer
{
    public class SqlRoomTypeRepository: SqlBaseRepository ,IRoomTypeRepository
    {
        public SqlRoomTypeRepository(SqlContext context) : base(context)
        {
        }

        public int Add(RoomType obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RoomType FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<RoomType> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(RoomType obj)
        {
            throw new NotImplementedException();
        }
    }
}
