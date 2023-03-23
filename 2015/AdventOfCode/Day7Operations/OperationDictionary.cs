using System;
using System.Collections.Generic;

namespace AdventOfCode.Day7Operations
{
    public class OperationDictionary : Dictionary<string, Operation>
    {
        public new Operation this[string key]
        {
            get
            {
                if (ContainsKey(key)) return base[key];

                UInt16 input;
                this[key] = UInt16.TryParse(key, out input) ? new Operation(input) : new Operation(0);
                
                return base[key];
            }
            set
            {
                base[key] = value;
            }
        }
    }
}