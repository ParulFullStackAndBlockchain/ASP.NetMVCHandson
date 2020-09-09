using MVCDemo.Common;
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
        [RemoteClientServer("IsUserNameAvailable", "Home", ErrorMessage = "UserName already in use ...")]
        //[Remote("IsUserNameAvailable", "Home", ErrorMessage = "UserName already in use.")]
        public string UserName { get; set; }
    }
}