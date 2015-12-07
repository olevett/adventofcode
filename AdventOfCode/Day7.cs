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

        public IDictionary<string, string> GetInstructionDictionary(IEnumerable<string> operations)
        {
            return operations.ToDictionary(op => op.Split(new[] { FunctionSymbol }, StringSplitOptions.None).Last().Trim(), op => op.Split(new[] { FunctionSymbol }, StringSplitOptions.None).First().Trim());
        }

        public UInt16 Calculate(string name, string input)
        {
            var opCodes = GetInstructionDictionary(input.SplitOnNewLines());
            var finalOperation = BuildOperation(name, opCodes);
            return finalOperation.Calculate();
        }

        private IOperation BuildOperation(string name, IDictionary<string, string> operations)
        {
            var opString = operations.Single(x => x.Key == name);
            var operationInputs = opString.Value.Split(' ');
            switch (operationInputs.Count())
            {
                case 1:
                    return ParseConstantOrBuild(operationInputs.Single(), operations);
                case 2:
                    if(operationInputs[0] == "NOT") return new NotOperation(ParseConstantOrBuild(operationInputs[1], operations));
                    throw new InvalidOperationException();
                case 3:
                    switch(operationInputs[1])
                    {
                        case "LSHIFT": return new LeftShiftOperation(ParseConstantOrBuild(operationInputs[0], operations), ParseConstantOrBuild(operationInputs[2], operations));
                        case "RSHIFT": return new RightShiftOperation(ParseConstantOrBuild(operationInputs[0], operations), ParseConstantOrBuild(operationInputs[2], operations));
                        case "AND": return new AndOperation(ParseConstantOrBuild(operationInputs[0], operations), ParseConstantOrBuild(operationInputs[2], operations));
                        case "OR": return new OrOperation(ParseConstantOrBuild(operationInputs[0], operations), ParseConstantOrBuild(operationInputs[2], operations));
                        default:
                            throw new InvalidOperationException();
                    }

                default:
                    throw new InvalidOperationException();
            }
        }

        private IOperation ParseConstantOrBuild(string operationInput, IDictionary<string,string> operations)
        {
            UInt16 parsedInput;
            if (UInt16.TryParse(operationInput, out parsedInput))
            {
                return new Constant(parsedInput);
            }
            else
            {
                return BuildOperation(operationInput, operations);
            }            
        }
    }
}
