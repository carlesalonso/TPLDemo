namespace tpldemo
{
    public interface IDemos
    {
        string EllapsedTime { get; }
        long TotalPrimesNumbers { get; }

        void Linq();
        void ParallelFor();
        void PLinq();
        void SequentialFor();
    }
}