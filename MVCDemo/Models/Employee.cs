using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCDemo.Models

{
    [Table("tblEmployee")]//Maps "Employee" model class to the database table, tblEmployee.
    //Note: "Table" attribute is present in "System.ComponentModel.DataAnnotations.Schema" namespace.
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }
}