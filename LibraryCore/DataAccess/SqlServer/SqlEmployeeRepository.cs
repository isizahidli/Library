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
    public class SqlEmployeeRepository: SqlBaseRepository, IEmployeeRepository
    {
        public SqlEmployeeRepository(SqlContext context) : base(context)
        {
        }

        public int Add(Employee obj)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Insert into Employees output inserted.Id 
                        values(@Name, @Surname, @Address, @PhoneNumber,@JoiningDate,@BirthDate,
                            @Gender,@Salary,@BeginWorkTime,@EndWorkTime,@Status)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Surname", obj.Surname);
                    cmd.Parameters.AddWithValue("@Address", obj.Address);
                    cmd.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
                    cmd.Parameters.AddWithValue("JoiningDate", obj.JoiningDate);
                    cmd.Parameters.AddWithValue("@Gender", obj.Gender);
                    cmd.Parameters.AddWithValue("@BirthDate", obj.BirthDate);
                    cmd.Parameters.AddWithValue("@Salary", obj.Salary);
                    cmd.Parameters.AddWithValue("@BeginWorkTime", obj.BeginWorkTime);
                    cmd.Parameters.AddWithValue("@EndWorkTime", obj.EndWorkTime);
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
                string query = "delete from Employees where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        public Employee FindById(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select * from Employees where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var reader = cmd.ExecuteReader();

                    Employee employee = null;

                    if (reader.Read())
                    {
                        employee = GetDataFromReader(reader);
                    }

                    return employee;
                }
            }
        }

        private Employee GetDataFromReader(SqlDataReader reader)
        {
            Employee employee = new Employee();

            employee.Id = Convert.ToInt32(reader["Id"]);
            employee.Name = reader["Name"].ToString();
            employee.Surname = reader["Surname"].ToString();
            employee.PhoneNumber = reader["PhoneNumber"].ToString();
            employee.Address = reader["Address"].ToString();
            employee.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
            employee.Gender = Convert.ToBoolean(reader["Gender"]);
            employee.JoiningDate = Convert.ToDateTime(reader["JoiningDate"]);
            employee.Salary = Convert.ToDecimal(reader["Salarty"]);
            //employee.BeginWorkTime
            //employee.EndWorkTime
            //employee.Status

            return employee;
        }

        public List<Employee> Get()
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = "select * from Employees where";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();

                    List<Employee> employees = new List<Employee>();

                    while (reader.Read())
                    {
                        Employee employee = GetDataFromReader(reader);
                        employees.Add(employee);
                    }

                    return employees;
                }
            }
        }

        public bool Update(Employee obj)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnString))
            {
                conn.Open();
                string query = @"Update Employees 
                    set Name = @Name,Surname=@Surname,PhoneNumber=@PhoneNumber,Address=@Address,
                 BirthDate=@BirthDate,Gender=@Gender,JoiningDate=@JoiningDate,Salary=@Salary,
                 BeginWorkTime=@BeginWorkTime,EndWorkTime=@EndWorkTime,Status=@Status where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", obj.Id);
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", obj.Address);
                    cmd.Parameters.AddWithValue("@BirthDate", obj.BirthDate);
                    cmd.Parameters.AddWithValue("@Gender", obj.Gender);
                    cmd.Parameters.AddWithValue("@JoiningDate", obj.JoiningDate);
                    cmd.Parameters.AddWithValue("@Salary", obj.Salary);
                    cmd.Parameters.AddWithValue("@BeginWorkTime", obj.BeginWorkTime);
                    cmd.Parameters.AddWithValue("@EndWorkTime", obj.EndWorkTime);
                    cmd.Parameters.AddWithValue("@Status", obj.Status);

                    int count = cmd.ExecuteNonQuery();
                    return count == 1;
                }
            }
        }
    }
}
