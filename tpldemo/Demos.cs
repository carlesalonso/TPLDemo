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
            if ((n & 1) == 0)
            {
                if (n == 2) return true;
                else return false;
            }
            for (int i = 3; (i * i) <= n; i += 2)
            {
                if ((n % i) == 0) return false;
            }
            return n != 1;
        }
    }



    public class Demos
    {
        private const long N = 1000000;
        private Stopwatch clock = new Stopwatch();
        private int[] numbers = new int[N];
       

        public Demos()
        {
            // 
            var rnd = new Random();
            for (long i = 0; i < N; i++)
               numbers[i] = rnd.Next(1, int.MaxValue);

        }


         public string SequentialFor(out double nPrimes)
        {
            nPrimes = 0;
            clock.Restart();
            for (long i = 0; i < N; i++)
            {
                if (numbers[i].IsPrime())
                    nPrimes++;
            }
            clock.Stop();
            return clock.ElapsedMilliseconds.ToString();
        }


         public string ParallelFor(out double nPrimes)
        {
            int temp = 0;
            clock.Restart();
            Parallel.For(0, N, (i) =>
            {
                if (numbers[i].IsPrime())
                    temp++;
            });
            clock.Stop();
            nPrimes = temp;
            return clock.ElapsedMilliseconds.ToString();
        }


         public string Linq(out double nPrimes)
        {

            clock.Restart();
            var query =
                from n in numbers
                where n.IsPrime()
                select n;
            nPrimes = query.Count();
            clock.Stop();
            return clock.ElapsedMilliseconds.ToString();
        }


         public string PLinq(out double nPrimes)
        {

            clock.Restart();
            var query =
                from n in numbers.AsParallel()
                where n.IsPrime()
                select n;
            nPrimes = query.Count();
            clock.Stop();
            return clock.ElapsedMilliseconds.ToString();
        }

    }
}
