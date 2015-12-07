
namespace AdventOfCode.Day7Operations
{
    public class RightShiftOperation : BinaryOperation
    {
        public RightShiftOperation(IOperation left, IOperation right)
            :base(left, right)
        {
        }

        public override ushort Calculate()
        {
            return (ushort)(Left.Calculate() >> Right.Calculate());
        }
    }
}
