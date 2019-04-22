using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Contracts
{
    public interface ILogger
    {
        void Error(string description, string source);

        void Info(string description, string source);

        void Warning(string description, string source);

        void Error(string layer, Exception e);

        void Info(string layer, Exception e);

        void Warning(string layer, Exception e);

    }
}
