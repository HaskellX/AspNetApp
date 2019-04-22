using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.Library.Mvc.Models
{
    public class UserEditVM
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Role { get; set; }
    }
}