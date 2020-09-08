using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVCDemo.Common;

namespace MVCDemo.Models
{
    public class EmployeeMetaData
    {
        [StringLength(10, MinimumLength = 5)]
        [Required]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Please enter upper and lower case alphabets only")]
        public string Name { get; set; }

        [Range(1, 100)]
        public int Age { get; set; }

        [CurrentDate]
        //[DateRange("01/01/2000")]
        //[Range(typeof(DateTime), "01/01/2000", "01/01/2010")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

    }

    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
        [Compare("Email")]
        public string ConfirmEmail { get; set; }
    }

}