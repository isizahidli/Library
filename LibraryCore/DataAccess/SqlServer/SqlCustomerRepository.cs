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
    public class SqlCustomerRepository: SqlBaseRepository, ICustomerRepository
    {
        public SqlCustomerRepository(SqlContext context) : base(context)
        {
        }

        public int Add(Customer obj)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Insert into Customers output inserted.Id 
                        values(@Name, @Surname, @Address, @PhoneNumber,@Email,@Country,@City
                          ,@ZipCode,@PassportNo,@Gender)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Surname", obj.Surname);
                    cmd.Parameters.AddWithValue("@Address", obj.Address);
                    cmd.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    cmd.Parameters.AddWithValue("@Country", obj.Country);
                    cmd.Parameters.AddWithValue("@City", obj.City);
                    cmd.Parameters.AddWithValue("@ZipCode", obj.ZipCode);
                    cmd.Parameters.AddWithValue("@PassportNo", obj.PassportNo);
                    cmd.Parameters.AddWithValue("@Gender", obj.Gender);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "delete from Customers where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        public Customer FindById(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select * from Customers where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var reader = cmd.ExecuteReader();

                    Customer customer = null;

                    if (reader.Read())
                    {
                        customer = GetDataFromReader(reader);
                    }

                    return customer;
                }
            }
        }

        private Customer GetDataFromReader(SqlDataReader reader)
        {
            Customer customer = new Customer();

            customer.Id = Convert.ToInt32(reader["Id"]);
            customer.Name = reader["Name"].ToString();
            customer.Surname = reader["Name"].ToString();
            customer.Address = reader["Name"].ToString();
            customer.PhoneNumber = reader["Name"].ToString();
            customer.Email = reader["Name"].ToString();
            customer.Country = reader["Name"].ToString();
            customer.City = reader["Name"].ToString();
            customer.ZipCode = reader["Name"].ToString();
            customer.PassportNo = reader["Name"].ToString();
            customer.Gender = Convert.ToBoolean(reader["Gender"]);

            return customer;
        }

        public List<Customer> Get()
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select * from Customers where";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();

                    List<Customer> customers = new List<Customer>();

                    while (reader.Read())
                    {
                        Customer customer = GetDataFromReader(reader);
                        customers.Add(customer);
                    }

                    return customers;
                }
            }
        }

        public bool Update(Customer obj)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Update Customers 
                    set Name = @Name, Surname = @Surname,  Address = @Address,
                    PhoneNumber = @PhoneNumber, Email = @Email,Country=@Country,City=@City   
            ZipCode=@ZipCode,PassportNo=@PassportNo,Gender=@Gender where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", obj.Id);
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Surname", obj.Surname);
                    cmd.Parameters.AddWithValue("@Address", obj.Address);
                    cmd.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    cmd.Parameters.AddWithValue("@Country", obj.Country);
                    cmd.Parameters.AddWithValue("@City", obj.City);
                    cmd.Parameters.AddWithValue("@ZipCode", obj.ZipCode);
                    cmd.Parameters.AddWithValue("@PassportNo", obj.PassportNo);
                    cmd.Parameters.AddWithValue("@Gender", obj.Gender);

                    int count = cmd.ExecuteNonQuery();
                    return count == 1;
                }
            }
        }
    }
}
