using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.Library.Mvc.Models
{
    public class PaperCreateFormVM
    {
        [RegularExpression(@"(^ISSN (?:[0-9]{4}-[0-9]{4}$)")]
        public string Issn { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }
    }
}