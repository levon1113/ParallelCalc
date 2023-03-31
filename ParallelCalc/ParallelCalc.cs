using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadState = System.Threading.ThreadState;

namespace ParallelCalc
{
    internal class ParallelCalc
    {
        private long Result;
        public long Min { get; set; }
        public long Max { get; set; }
        public int N { get; set; }

        public ParallelCalc()
        {

        }

        public ParallelCalc(long min, long max, int n)
        {
            Min = min;
            Max = max;
            N = n;
            Result = 0;
        }

        public long Run(out long elapsed)
        {
            
            Thread[] threads = new Thread[N];
            long m = Max - Min;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            
            for (int i = 0; i < N; i++)
            {
                long min=0, max=0;
                min = Min + i * (m / N) + 1;

                if (m % N != 0 && i == N - 1)
                {
                    max = Min + (i + 1) * (m / N) + m%N;
                }
                else
                {
                    max = Min + (i + 1) * (m / N);
                }
                threads[i] = new Thread(()=>Calc(min,max));
                threads[i].Start();
            }
            
            while (CheckThreads(threads)) ;

            stopwatch.Stop();
            
            elapsed = stopwatch.ElapsedMilliseconds;
            
            return Result + Min;
        }

        private bool CheckThreads(Thread[] threads)
        {
            for (int i = 0; i < threads.Length; i++)
            {
                if (threads[i].ThreadState == ThreadState.Running)
                {
                    return true;
                }
            }
            return false;
        }
        public void Calc(long min, long max)
        {
            long s = 0;
            for (long i = min; i <= max; i++)
            {
                s += i;
            }
            Result += s;
        }

    }
}
