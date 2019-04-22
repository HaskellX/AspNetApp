using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PageRequest
    {
        public IEnumerable<LibraryItem> items;

        public int TotalPages { get; set; }
    }
}
