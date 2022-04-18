using LibraryCore.DataAccess.SqlServer;
using LibraryCore.Domain.Abstract;
using LibraryCore.Domain.Entities;
using LibraryCore.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LibraryCore.DataAccess
{
    public class SqlUserRepository : SqlBaseRepository, IUserRepository
    {
        public SqlUserRepository(SqlContext context) : base(context)
        {
        }

        public int Add(User obj)
        {
            using(SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Insert into Users output inserted.Id 
                                values(@Username, @PasswordHash, @IsDeleted, @CreationDate, @CreatorId)";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", obj.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", obj.PasswordHash);
                    cmd.Parameters.AddWithValue("@IsDeleted", obj.IsDeleted);
                    cmd.Parameters.AddWithValue("@CreationDate", obj.CreationDate);
                    if(obj.Creator == null)
                    {
                        // C# null and Database Null is different from each other
                        // null == DBNull.Value     ==> False
                        cmd.Parameters.AddWithValue("@CreatorId", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CreatorId", obj.Creator.Id);
                    }

                    int id  = (int) cmd.ExecuteScalar();
                    return id;
                }
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User FindById(int id)
        {
            throw new NotImplementedException();
        }

        public User FindByUsername(string username)
        {
            using(SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select * from Users where Username = @username";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = cmd.ExecuteReader();
                    User user = null;
                    if(reader.Read())
                    {
                        user = new User();
                        user.Id = reader.GetInt32("Id");
                        user.Username = reader.GetString("Username");
                        user.PasswordHash = reader.GetString("PasswordHash");
                        user.CreationDate = reader.GetDateTime("CreationDate");
                        user.IsDeleted = reader.GetBoolean("IsDeleted");
                        int index =  reader.GetOrdinal("CreatorId");
                        if(!reader.IsDBNull(index))
                        {
                            user.Creator = new User();
                            user.Creator.Id = Convert.ToInt32(reader["CreatorId"]);
                        }
                    }
                    return user;
                }
            }
        }

        public List<User> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
