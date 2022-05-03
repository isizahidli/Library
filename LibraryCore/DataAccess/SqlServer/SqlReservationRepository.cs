using LibraryCore.Domain.Abstract;
using LibraryCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Insert into Reservations output inserted.Id 
                        values(@ReservationDate, @CheckInDate, @CheckOutDate, @Adults,@Children,@Amount,@Status)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReservationDate", obj.ReservationDate);
                    cmd.Parameters.AddWithValue("@CheckInDate", obj.CheckInDate);
                    cmd.Parameters.AddWithValue("@CheckOutDate", obj.CheckOutDate);
                    cmd.Parameters.AddWithValue("@Adults", obj.Adults);
                    cmd.Parameters.AddWithValue("@Children", obj.Children);
                    cmd.Parameters.AddWithValue("@Amount", obj.Amount);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "delete from Reservations where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id",  id);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        public Reservation FindById(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select r.*, c.name as CustomerName,c.surname as CustomerSurname,room.RoomNumber from Reservations as r inner join Customers as c on r.CustomerId = c.Id inner join Rooms as room on r.RoomId = room.Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var reader = cmd.ExecuteReader();

                    Reservation reservation = null;

                    if (reader.Read())
                    {
                        reservation = GetDataFromReader(reader);
                    }

                    return reservation;
                }
            }
        }

        private Reservation GetDataFromReader(SqlDataReader reader)
        {
            Reservation reservation = new Reservation();

            reservation.Id = Convert.ToInt32(reader["Id"]);
            reservation.ReservationDate = Convert.ToDateTime(reader["ReservationDate"]);
            reservation.CheckInDate = Convert.ToDateTime(reader["CheckInDate"]);
            reservation.CheckOutDate =Convert.ToDateTime(reader["CheckOutDate"]);
            reservation.Adults = Convert.ToInt32(reader["Adults"]);
            reservation.Children = Convert.ToInt32(reader["Children"]);
            reservation.Amount = Convert.ToDecimal(reader["Amount"]);
            //reservation.Status = 


            return reservation;
        }

        public List<Reservation> Get()
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select r.*, c.name as CustomerName,c.surname as CustomerSurname,room.RoomNumber from Reservations as r inner join Customers as c on r.CustomerId = c.Id inner join Rooms as room on r.RoomId = room.Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();

                    List<Reservation> reservations = new List<Reservation>();

                    while (reader.Read())
                    {
                        Reservation reservation = GetDataFromReader(reader);
                        reservations.Add(reservation);
                    }

                    return reservations;
                }
            }
        }

        public bool Update(Reservation obj)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Update Reservations 
                    set ReservationDate = @ReservationDate, CheckInDate = @CheckOutDate,  Adults = @Adults,
                    Children = @Children, Amount = @Amount,Status=@Status
                    where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", obj.Id);
                    cmd.Parameters.AddWithValue("@ReservationDate", obj.ReservationDate);
                    cmd.Parameters.AddWithValue("@CheckInDate", obj.CheckInDate);
                    cmd.Parameters.AddWithValue("@CheckOutDate", obj.CheckOutDate);
                    cmd.Parameters.AddWithValue("@Adults", obj.Adults);
                    cmd.Parameters.AddWithValue("@Children", obj.Children);
                    cmd.Parameters.AddWithValue("@Amount", obj.Amount);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);

                    int count = cmd.ExecuteNonQuery();
                    return count == 1;
                }
            }
        }
    }
}
