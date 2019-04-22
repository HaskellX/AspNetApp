using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.Library.Mvc.Models
{
    public class UserCreateVM
    {
        public string Login { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string PassConfirm { get; set; }

    }
}