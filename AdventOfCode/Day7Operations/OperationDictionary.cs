using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day7Operations
{
    public class OperationDictionary : Dictionary<string, Operation>
    {
        public new Operation this[string key]
        {
            get
            {
                if (!ContainsKey(key))
                {
                    UInt16 input;
                    if (UInt16.TryParse(key, out input))
                    {
                        this[key] = new Operation(input);
                    }
                    else
                    {
                        this[key] = new Operation(0);
                    }

                }
                return base[key];
            }
            set
            {
                base[key] = value;
            }
        }
    }
}