using LibraryCore.DataAccess.SqlServer;
using LibraryCore.Domain.Abstract;
using System;
using System.Data.SqlClient;

namespace LibraryCore.DataAccess
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly SqlContext context;
        private readonly string connString;
        public SqlUnitOfWork(string connString)
        {
            context = new SqlContext(connString);
            this.connString = connString;
        }

        public IUserRepository UserRepository => new SqlUserRepository(context);
        public IRoomRepository RoomRepository => new SqlRoomRepository(context);
        public IRoomTypeRepository RoomTypeRepository => new SqlRoomTypeRepository(context);
        public IReservationRepository ReservationRepository => new SqlReservationRepository(context);
        public IDepartmentRepository DepartmentRepository =>  new SqlDepartmentRepository(context);
        public IServiceRepository ServiceRepository =>  new SqlServiceRepository(context);
        public IEmployeeRepository EmployeeRepository =>  new SqlEmployeeRepository(context);
        public ICustomerRepository CustomerRepository =>  new SqlCustomerRepository(context);

        public bool CheckServer()
        {
            using(SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
