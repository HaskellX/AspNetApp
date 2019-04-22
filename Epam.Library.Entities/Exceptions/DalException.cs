using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class DalException : Exception
    {
        public Exception ex;

        public DalException (Exception ex)
        {
            this.ex = ex;
        }

    }
}
