using System;
using Entities;

namespace BlContracts
{
    public interface IPaperValidator
    {
        bool IsValidISSN(string inputString);

        bool IsValidName(string name);
    }
}