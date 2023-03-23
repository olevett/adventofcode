namespace AdventOfCode2018CS.Q4
{
    public class GuardId
    {
        public int Id { get; }

        public GuardId(int guardId)
        {
            Id = guardId;
        }

        public override bool Equals(object obj)
        {
            return obj is GuardId id &&
                   Id == id.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}