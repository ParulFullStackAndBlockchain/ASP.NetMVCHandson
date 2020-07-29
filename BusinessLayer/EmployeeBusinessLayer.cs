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
                        employee.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);

                        employees.Add(employee);
                    }
                }

                return employees;
            }
        }
    }
}
