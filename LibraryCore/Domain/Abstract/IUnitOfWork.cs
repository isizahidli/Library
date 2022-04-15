using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore.Domain.Abstract
{
    public interface IUnitOfWork
    {
        bool CheckServer();

        IUserRepository UserRepository { get; }
        IBookRepository BookRepository { get; }
        IBranchRepository BranchRepository { get; }
        IRoomTypeRepository RoomTypeRepository { get; }

    }
}
