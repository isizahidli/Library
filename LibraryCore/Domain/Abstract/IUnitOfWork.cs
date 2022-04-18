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
        IBookRepository1 BookRepository { get; }
        IBranchRepository1 BranchRepository { get; }
        IRoomTypeRepository RoomTypeRepository { get; }

    }
}
