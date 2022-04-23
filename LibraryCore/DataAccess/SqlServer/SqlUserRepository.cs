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
    public class SqlUserRepository: SqlBaseRepository ,IUserRepository
    {
        public SqlUserRepository(SqlContext context) : base(context)
        {
        }

        public int Add(User obj)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Insert into Users output inserted.Id 
                        values(@Username, @Password, @Status)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", obj.Username);
                    cmd.Parameters.AddWithValue("@Password", obj.PasswordHash);
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
                string query = "delete from Users where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        public User FindById(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select * from Users where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var reader = cmd.ExecuteReader();

                    User user = null;

                    if (reader.Read())
                    {
                        user = GetDataFromReader(reader);
                    }

                    return user;
                }
            }
        }

        private User GetDataFromReader(SqlDataReader reader)
        {
            User user = new User();

            user.Id = Convert.ToInt32(reader["Id"]);
           // user.Status = 
            user.PasswordHash = reader["PasswordHash"].ToString();
            user.Username = reader["Username"].ToString();


            return user;
        }

      

        public List<User> Get()
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select * from Users where";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();

                    List<User> users = new List<User>();

                    while (reader.Read())
                    {
                        User user = GetDataFromReader(reader);
                        users.Add(user);
                    }

                    return users;
                }
            }
        }

        public bool Update(User obj)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Update Users 
                    set PasswordHash = @PasswordHash, Username = @Username,  Status = @Status";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", obj.Id);
                    cmd.Parameters.AddWithValue("@PasswordHash", obj.PasswordHash);
                    cmd.Parameters.AddWithValue("@Username", obj.Username);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);
                  

                    int count = cmd.ExecuteNonQuery();
                    return count == 1;
                }
            }
        }
    }
}
