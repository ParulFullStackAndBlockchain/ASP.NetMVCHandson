using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Company
    {
        public Employee CompanyDirector
        {
            get
            {
                sampleDBContext db = new sampleDBContext();
                return db.Employees.Single(x => x.Id == 1);
            }
        }
    }
}