
namespace AdventOfCode.Day7Operations
{
    public class OrOperation : BinaryOperation
    {
        public OrOperation(IOperation left, IOperation right)
            :base(left, right)
        {
        }

        public override ushort Calculate()
        {
            return (ushort)(Left.Calculate() | Right.Calculate());
        }
    }
}
