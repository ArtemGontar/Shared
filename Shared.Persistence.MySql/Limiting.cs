using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Persistence.MySql
{
    public class Limiting
    {
        public int CountOfRecords { get; }

        public Limiting(int countOfRecords)
        {
            CountOfRecords = countOfRecords;
        }
    }
}
