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
    public class SqlServiceRepository: SqlBaseRepository, IServiceRepository
    {
        public SqlServiceRepository(SqlContext context) : base(context)
        {
        }

        public int Add(Service obj)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Insert into Services output inserted.Id 
                        values(@Name, @Description, @Price, @Status, @DepartmentId)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Price", obj.Price);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);
                    cmd.Parameters.AddWithValue("@DepartmentId", obj.Department.Id);
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
                string query = "delete from Services where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        public Service FindById(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select s.*,d.name as DepName from Services as s inner join Departments as d on s.departmentId=d.Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var reader = cmd.ExecuteReader();

                    Service service = null;

                    if (reader.Read())
                    {
                        service = GetDataFromReader(reader);
                    }

                    return service;
                }
            }
        }

        private Service GetDataFromReader(SqlDataReader reader)
        {
            Service service = new Service();

            service.Id = Convert.ToInt32(reader["Id"]);
          //  service.Status = 
            service.Name = reader["Name"].ToString();
            service.Price = Convert.ToDecimal(reader["Price"]);
            service.Department.Id = Convert.ToInt32(reader["DepartmentId"]);
            service.Department.Name = reader["DepName"].ToString();

            if (!reader.IsDBNull(reader.GetOrdinal("Description")))
                service.Description = reader["Description"].ToString();

            return service;
        }

        public List<Service> Get()
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select s.*,d.name as DepName from Services as s inner join Departments as d on s.departmentId=d.Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();

                    List<Service> services = new List<Service>();

                    while (reader.Read())
                    {
                        Service service = GetDataFromReader(reader);
                        services.Add(service);
                    }

                    return services;
                }
            }
        }

        public bool Update(Service obj)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Update Services 
                    set Name = @Name,   Status = @Status,
                    Description = @Description, Price = @Price where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", obj.Id);
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);
                    cmd.Parameters.AddWithValue("@Description", obj.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Price", obj.Price);

                    int count = cmd.ExecuteNonQuery();
                    return count == 1;
                }
            }
        }
    }
}
