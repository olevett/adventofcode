
namespace AdventOfCode.Day7Operations
{
    public class LeftShiftOperation : BinaryOperation
    {
        public LeftShiftOperation(IOperation left, IOperation right)
            :base(left, right)
        {
        }

        public override ushort Calculate()
        {
            return (ushort)(Left.Calculate() << Right.Calculate());
        }
    }
}
