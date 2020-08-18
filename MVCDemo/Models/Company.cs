using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Company
    {
        private string _name;
        
        public Company(string name)
        {
            this._name = name;
        }

        public List<Department> Departments
        {
            get
            {
                EmployeeContext db = new EmployeeContext();
                return db.Departments.ToList();
            }
        }

        [Key]
        public string CompanyName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
}