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
        public IBookRepository BookRepository => new SqlBookRepository(context);
        public IBranchRepository BranchRepository => new SqlBranchRepository(context);
        public IRoomTypeRepository RoomTypeRepository => new SqlRoomTypeRepository(context);

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
