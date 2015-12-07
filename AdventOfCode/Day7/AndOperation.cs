
namespace AdventOfCode.Day7Operations
{
    public class AndOperation : BinaryOperation
    {
        public AndOperation(IOperation left, IOperation right)
            :base(left, right)
        {
        }

        public override ushort Calculate()
        {
            return (ushort)(Left.Calculate() & Right.Calculate());
        }
    }
}
