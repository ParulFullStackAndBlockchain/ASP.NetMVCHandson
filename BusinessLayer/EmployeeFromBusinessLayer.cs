using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    //Run the application and navigate to the following URL http://localhost/MVCDemo/EmployeeUsingBusinessLayer/Create
    //Submit the page without entering any data.Notice that a blank employee row is inserted into tblEmployee table.
    //Now let's make the following properties of "Employee" class required.Name,City,DateOfBirth.To achieve this we can use 
    //"Required" attribute that is present in System.ComponentModel.DataAnnotations namespace.To use this namespace, BusinessLayer 
    //project need a reference to "EntityFramework" assembly.The changes to the "Employee" class are shown below.
    public class EmployeeFromBusinessLayer
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        //Run the application and navigate to the following URL. http://localhost/MVCDemo/EmployeeUsingBusinessLayer/Create
        //Submit the page without entering any data. You will get an error stating - "The model of type 'BusinessLayer.
        //Employee' could not be updated". This is because "DateOfBirth" property of "Employee" class is a non-nullable 
        //DateTime data type. DateTime is a value type, and needs to have value when we post the form. 
        //To make "DateOfBirth" optional change the data type to nullable DateTime.
        [Required]
        public DateTime? DateOfBirth { get; set; }
    }
}
