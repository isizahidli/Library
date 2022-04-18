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
        IRoomRepository RoomRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IRoomTypeRepository RoomTypeRepository { get; }
        IServiceRepository ServiceRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IReservationRepository ReservationRepository { get; }

    }
}
