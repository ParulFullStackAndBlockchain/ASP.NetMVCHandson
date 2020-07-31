using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        public IEnumerable<EmployeeFromBusinessLayer> EmployeesFromBusinessLayer
        {
            get
            {
                string connectionString =
                    ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

                List<EmployeeFromBusinessLayer> employees = new List<EmployeeFromBusinessLayer>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EmployeeFromBusinessLayer employee = new EmployeeFromBusinessLayer();
                        employee.ID = Convert.ToInt32(rdr["Id"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.City = rdr["City"].ToString();
                        //Run the application and navigate to the following URL. http://localhost/MVCDemo/EmployeeUsingBusinessLayer/Create
                        //Submit the page without entering any data.You will now get a different error stating -Object cannot be cast from DBNull to other types.
                        //To fix this error, make changes to "Employees" property in "EmployeeBusinessLayer.cs" file as shown below.
                        //Notice that we are populating "DateOfBirth" property of "Employee" object only if "DateOfBirth" column value is not "DBNull".
                        if (!(rdr["DateOfBirth"] is DBNull))
                        {
                            employee.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                        }

                        employees.Add(employee);
                    }
                }

                return employees;
            }
        }

        public void AddEmmployee(EmployeeFromBusinessLayer employee)
        {
            string connectionString =
                    ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.City;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
