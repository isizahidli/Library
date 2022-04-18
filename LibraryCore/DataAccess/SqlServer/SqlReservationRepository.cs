using LibraryCore.Domain.Abstract;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCore.DataAccess.SqlServer
{
    public class SqlReservationRepository: SqlBaseRepository, IReservationRepository
    {
        public SqlReservationRepository(SqlContext context) : base(context)
        {
        }

        public int Add(Reservation obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Reservation FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(Reservation obj)
        {
            throw new NotImplementedException();
        }
    }
}
