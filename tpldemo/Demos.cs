using System;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace tpldemo
{

    // Extension Class for int type that adds IsPrime method
    public static class BaseTypesExtensions
    {
        public static bool IsPrime(this int n) //1 = false, 2 = true, 3 = true...
        {
            if (n <= 1) return false;
            if ((n & 1) == 0) // n is even
            {
                if (n == 2) return true;
                else return false;
            }
            for (int i = 3; (i * i) <= n; i += 2) 
            {
                if ((n % i) == 0) return false;
            }
            return true;
        }
    }



    public class Demos
    {
        // Private attributes
        private const long N = 1000000;
        private Stopwatch clock = new Stopwatch();
        private int[] numbers = new int[N];

        //Public Properties
        public string EllapsedTime { get; protected set; }
        public long TotalPrimesNumbers { get; protected set; }

        public Demos()
        {
            // 
            var rnd = new Random();
            for (long i = 0; i < N; i++)
               numbers[i] = rnd.Next(1, int.MaxValue);

        }


         public void SequentialFor()
        {
            TotalPrimesNumbers = 0;
            clock.Restart();
            for (long i = 0; i < N; i++)
            {
                if (numbers[i].IsPrime())
                    TotalPrimesNumbers += 1;
            }
            clock.Stop();
            EllapsedTime = clock.ElapsedMilliseconds.ToString();

        }


         public void ParallelFor()
        {
            int temp = 0;
            clock.Restart();
            Parallel.For(0, N, (i) =>
            {
                if (numbers[i].IsPrime())
                    temp++;
            });
            clock.Stop();
            TotalPrimesNumbers = temp;
            EllapsedTime = clock.ElapsedMilliseconds.ToString();
        }


         public void Linq()
        {

            clock.Restart();
            var query =
                from n in numbers
                where n.IsPrime()
                select n;
            TotalPrimesNumbers = query.Count();
            clock.Stop();
            EllapsedTime = clock.ElapsedMilliseconds.ToString();
        }


         public void PLinq()
        {

            clock.Restart();
            var query =
                from n in numbers.AsParallel()
                where n.IsPrime()
                select n;
            TotalPrimesNumbers = query.Count();
            clock.Stop();
            EllapsedTime = clock.ElapsedMilliseconds.ToString();
        }

    }
}
