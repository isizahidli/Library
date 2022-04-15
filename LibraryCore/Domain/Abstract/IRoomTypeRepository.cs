using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore.Domain.Abstract
{
    public interface IRoomTypeRepository
    {
        int Add(RoomType obj);
        bool Update(RoomType obj);
        bool Delete(int id);
        RoomType FindById(int id);
        List<RoomType> Get();
    }
}
