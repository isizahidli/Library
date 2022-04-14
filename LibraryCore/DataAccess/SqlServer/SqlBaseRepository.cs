namespace LibraryCore.DataAccess.SqlServer
{
    public  abstract class SqlBaseRepository 
    {

        protected readonly SqlContext context;
        public SqlBaseRepository(SqlContext context)
        {
            this.context = context;
        }
    }
}
