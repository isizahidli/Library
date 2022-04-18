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
    public class SqlRoomTypeRepository1 : SqlBaseRepository, IRoomTypeRepository
    {
        public SqlRoomTypeRepository1(SqlContext context) : base(context) { }

        public int Add(RoomType obj)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Insert into RoomTypes output inserted.Id 
                        values(@Name, @MaxAdults, @MaxChildren, @PricePerNight, @Description)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@MaxAdults", obj.MaxAdults);
                    cmd.Parameters.AddWithValue("@MaxChildren", obj.MaxChildren);
                    cmd.Parameters.AddWithValue("@PricePerNight", obj.PricePerNight);
                    cmd.Parameters.AddWithValue("@Description", obj.Description ?? (object)DBNull.Value);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "delete from RoomTypes where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        public RoomType FindById(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select * from RoomTypes where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var reader = cmd.ExecuteReader();

                    RoomType roomType = null;

                    if (reader.Read())
                    {
                        roomType = GetDataFromReader(reader);
                    }

                    return roomType;
                }
            }
        }

        public List<RoomType> Get()
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select * from RoomTypes where";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();

                    List<RoomType> roomTypes = new List<RoomType>();

                    while (reader.Read())
                    {
                        RoomType roomType = GetDataFromReader(reader);
                        roomTypes.Add(roomType);
                    }

                    return roomTypes;
                }
            }
        }

        public bool Update(RoomType obj)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Update RoomTypes 
                    set Name = @Name, MaxChildren = @MaxChildren,  PricePerNight = @PricePerNight,
                    Description = @Description, MaxAdults = @MaxAdults
                    where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", obj.Id);
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@MaxChildren", obj.MaxChildren);
                    cmd.Parameters.AddWithValue("@PricePerNight", obj.PricePerNight);
                    cmd.Parameters.AddWithValue("@Description", obj.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaxAdults", obj.MaxAdults);

                    int count = cmd.ExecuteNonQuery();
                    return count == 1;
                }
            }
        }

        private RoomType GetDataFromReader(SqlDataReader reader)
        {
            RoomType roomType = new RoomType();

            roomType.Id = Convert.ToInt32(reader["Id"]);
            roomType.MaxAdults = Convert.ToByte(reader["MaxAdults"]);
            roomType.MaxChildren = Convert.ToByte(reader["MaxChildren"]);
            roomType.Name = reader["Name"].ToString();
            roomType.PricePerNight = Convert.ToDecimal(reader["PricePerNight"]);

            if (!reader.IsDBNull(reader.GetOrdinal("Description")))
                roomType.Description = reader["Description"].ToString();

            return roomType;
        }
    }
}
