using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    // Note that this interface, has got only the properties that we want to include in model binding. 
    // "Name" property is not present. 
    public interface IEmployeeFromBusinessLayer
    {
        int ID { get; set; }
        string Gender { get; set; }
        string City { get; set; }
        DateTime? DateOfBirth { get; set; }
    }

    public class EmployeeFromBusinessLayer : IEmployeeFromBusinessLayer
    {
        public int ID { get; set; }      
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }       
        [Required]
        public DateTime? DateOfBirth { get; set; }
    }
}
