using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Company
    {
        public string SelectedDepartment { get; set; }

        public List<Department> Departments
        {
            get
            {
                EmployeeContext db = new EmployeeContext();
                return db.Departments.ToList();
            }
        }
    }
}