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
    public class SqlRoomRepository : SqlBaseRepository, IRoomRepository
    {
        public SqlRoomRepository(SqlContext context) : base(context)
        {
        }

        public int Add(Room obj)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Insert into Rooms output inserted.Id 
                        values(@RoomNumber, @FloorNo, @PricePerNight, @PetFriendly,@IsSmoking,@Status)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomNumber", obj.RoomNumber);
                    cmd.Parameters.AddWithValue("@FloorNo", obj.FloorNo);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);
                    cmd.Parameters.AddWithValue("@PricePerNight", obj.PricePerNight);
                    cmd.Parameters.AddWithValue("@PetFriendly", obj.PetFriendly);
                    cmd.Parameters.AddWithValue("@IsSmoking", obj.IsSmoking);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "delete from Rooms where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        public Room FindById(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select r.*,roomType.name as RoomTypeName from Rooms as r inner join RoomTypes as roomType on r.RoomTypeId=roomType.Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var reader = cmd.ExecuteReader();

                    Room room = null;

                    if (reader.Read())
                    {
                        room = GetDataFromReader(reader);
                    }

                    return room;
                }
            }
        }

        private Room GetDataFromReader(SqlDataReader reader)
        {
            Room room = new Room();

            room.Id = Convert.ToInt32(reader["Id"]);
            room.RoomNumber = Convert.ToByte(reader["RoomNumber"]);
            room.FloorNo = Convert.ToByte(reader["FloorNo"]);
           // room.Status = 
            room.PricePerNight = Convert.ToDecimal(reader["PricePerNight"]);
            room.PetFriendly = Convert.ToBoolean(reader["Petfriendly"]);
            room.IsSmoking = Convert.ToBoolean(reader["IsSmoking"]);



            return room;
        }

        public List<Room> Get()
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select r.*,roomType.name as RoomTypeName from Rooms as r inner join RoomTypes as roomType on r.RoomTypeId=roomType.Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();

                    List<Room> rooms = new List<Room>();

                    while (reader.Read())
                    {
                        Room room = GetDataFromReader(reader);
                        rooms.Add(room);
                    }

                    return rooms;
                }
            }
        }

        public bool Update(Room obj)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Update Rooms 
                    set RoomNumber = @RoomNumber, FloorNo = @FloorNo,  PricePerNight = @PricePerNight,
                    Status = @Status, Petfriendly = @Petfriendly,IsSmoking=@IsSmoking
                    where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", obj.Id);
                    cmd.Parameters.AddWithValue("@RoomNumber", obj.RoomNumber);
                    cmd.Parameters.AddWithValue("@FloorNo", obj.FloorNo);
                    cmd.Parameters.AddWithValue("@PricePerNight", obj.PricePerNight);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);
                    cmd.Parameters.AddWithValue("@PetFriendly", obj.PetFriendly);
                    cmd.Parameters.AddWithValue("@IsSmoking", obj.IsSmoking);

                    int count = cmd.ExecuteNonQuery();
                    return count == 1;
                }
            }
        }
    }
}
