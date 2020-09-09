using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
    }

    public class UserMetaData
    {
        //Notice that the name of the method (IsUserNameAvailable) and the controller name (Home) and error message are 
        //passed as arguments to Remote Attribute
        [Remote("IsUserNameAvailable", "Home", ErrorMessage = "UserName already in use.")]
        public string UserName { get; set; }
    }
}