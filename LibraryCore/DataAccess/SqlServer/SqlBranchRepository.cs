using LibraryCore.Domain.Abstract;
using LibraryCore.Domain.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using LibraryCore.Utils;
using System;

namespace LibraryCore.DataAccess.SqlServer
{
    public class SqlBranchRepository : SqlBaseRepository,  IBranchRepository1
    {
        public SqlBranchRepository(SqlContext context) : base(context)
        {
        }

        public int Add(Branch1 branch)
        {
            using(SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Insert into Branches output inserted.Id 
                        values(@Name, @Address, @Phone, @IsDeleted, @CreationDate, @Note, @CreatorId)";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", branch.Name);
                    cmd.Parameters.AddWithValue("@Address", branch.Address ?? (object) DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", branch.Phone ?? (object) DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsDeleted", branch.IsDeleted);
                    cmd.Parameters.AddWithValue("@CreationDate", branch.CreationDate);
                    cmd.Parameters.AddWithValue("@Note", branch.Note ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatorId", branch.Creator.Id);

                    return (int) cmd.ExecuteScalar();
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "delete from Branches where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        public Branch1 FindById(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select * from Branches where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var reader = cmd.ExecuteReader();

                    Branch1 branch = null;

                    if (reader.Read())
                    {
                        branch = GetDataFromReader(reader);
                    }

                    return branch;
                }
            }
        }

        public List<Branch1> Get()
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select * from Branches where IsDeleted = 0";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();

                    List<Branch1> branches = new List<Branch1>();

                    while(reader.Read())
                    {
                        Branch1 branch = GetDataFromReader(reader);
                        branches.Add(branch);
                    }

                    return branches;
                }
            }
        }

        public bool Update(Branch1 branch)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Update Branches 
                    set Name = @Name, Address = @Address,  Phone = @Phone,
                    IsDeleted = @IsDeleted, Note = @Note,
                    CreationDate = @CreationDate, CreatorId = @CreatorId
                    where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", branch.Id);
                    cmd.Parameters.AddWithValue("@Name", branch.Name);
                    cmd.Parameters.AddWithValue("@Address", branch.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", branch.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsDeleted", branch.IsDeleted);
                    cmd.Parameters.AddWithValue("@CreationDate", branch.CreationDate);
                    cmd.Parameters.AddWithValue("@Note", branch.Note ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatorId", branch.Creator.Id);

                    int count = cmd.ExecuteNonQuery();
                    return count == 1;
                }
            }
        }

        private Branch1 GetDataFromReader(SqlDataReader reader)
        {
            Branch1 branch = new Branch1();
            branch.Id = reader.GetInt32("Id");
            branch.Name = reader.GetString("Name");
            branch.Address = reader.GetString("Address");
            branch.Phone = reader.GetString("Phone");
            branch.IsDeleted = reader.GetBoolean("IsDeleted");
            branch.CreationDate = reader.GetDateTime("CreationDate");
            branch.Creator = new User() { Id = reader.GetInt32("CreatorId") };
            branch.Note = reader.GetString("Note");

            return branch;
        }
    }
}
