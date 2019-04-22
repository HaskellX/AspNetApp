using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.Library.Mvc.Models
{
    public class PaginationVM
    {
        public IEnumerable<LibraryItem> Items;
        public int CurrentPage { get; set; }
        public int TotalNumberOfPages { get; set; }
    }
}