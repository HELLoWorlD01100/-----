namespace KA1.Domain
{
    public class Edge
    {
        public int Weight { get; }
        public int SourceNodeNumber { get; }
        public int TargetNodeNumber { get; }

        public Edge(int weight, int source, int target)
        {
            Weight = weight;
            if (source > target)
            {
                SourceNodeNumber = target;
                TargetNodeNumber = source;
            }
            else
            {
                SourceNodeNumber = source;
                TargetNodeNumber = target;
            }
        }

        public override int GetHashCode()
        {
            return Weight.GetHashCode() + SourceNodeNumber.GetHashCode() + TargetNodeNumber.GetHashCode();
        }
    }
}