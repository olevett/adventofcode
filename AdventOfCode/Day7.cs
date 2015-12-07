using AdventOfCode.Day7Operations;
using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day7
    {
        private const string FunctionSymbol = "->";
        private readonly OperationDictionary Operations;

        public Day7()
        {
            this.Operations = new OperationDictionary();
        }

        public IDictionary<string, string> GetInstructionDictionary(IEnumerable<string> operations)
        {
            return operations.ToDictionary(op => op.Split(new[] { FunctionSymbol }, StringSplitOptions.None).Last().Trim(), op => op.Split(new[] { FunctionSymbol }, StringSplitOptions.None).First().Trim());
        }

        public UInt16 Calculate(string name, string input)
        {
            var opCodes = GetInstructionDictionary(input.SplitOnNewLines());
            var operations = BuildOperations(opCodes);
            return operations[name].Calculate();
        }

        private OperationDictionary BuildOperations(IDictionary<string, string> operations)
        {
            var ops = new OperationDictionary();
            foreach(var operation in operations)
            {
                var operationInputs = operation.Value.Split(' ');
                switch (operationInputs.Count())
                {
                    case 1:
                         UInt16 parsedInput;
                         if (UInt16.TryParse(operationInputs[0], out parsedInput))
                         {
                             ops[operation.Key] = new Operation(parsedInput);
                         }
                         else
                         {
                             ops[operation.Key] = new Operation(() => ops[operationInputs[0]], Operation.Load);
                         }
                        break;
                    case 2:
                        if (operationInputs[0] == "NOT") ops[operation.Key] = new Operation(() => ops[operationInputs[1]], Operation.Not);
                        break;
                    case 3:
                        switch (operationInputs[1])
                        {
                            case "LSHIFT":
                                ops[operation.Key] = new Operation(() => ops[operationInputs[0]], () => ops[operationInputs[2]], Operation.LeftShift);
                                break;
                            case "RSHIFT":
                                ops[operation.Key] = new Operation(() => ops[operationInputs[0]], () => ops[operationInputs[2]], Operation.RightShift);
                                break;
                            case "AND":
                                ops[operation.Key] = new Operation(() => ops[operationInputs[0]], () => ops[operationInputs[2]], Operation.And);
                                break;
                            case "OR":
                                ops[operation.Key] = new Operation(() => ops[operationInputs[0]], () => ops[operationInputs[2]], Operation.Or);
                                break;
                            default:
                                throw new InvalidOperationException();
                        }
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            return ops;
        }
    }
}
