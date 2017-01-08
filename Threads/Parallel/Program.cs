using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallels
{
    class Program
    {
        static void Main(string[] args)
        {

            ParallelLoopResult result = Parallel.For(0, 10, i =>
            {
                Console.WriteLine("{0},task:{1},thread:{2}", i, Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            });
            Console.WriteLine("is completed:{0}", result.IsCompleted);

            var sw = new Stopwatch();
            sw.Start();
            Task.Delay(3000);
            Console.WriteLine("async:running for {0} seconds", sw.Elapsed.TotalSeconds);
            Thread.Sleep(1000);//这段时间阻塞线程，不能处理事情。。
            Console.WriteLine("async:running for {0} seconds", sw.Elapsed.TotalSeconds);



            ParallelLoopResult result2 = Parallel.For(10, 700, async (i, pls) =>
                {
                    Console.WriteLine("i:{0} task {1}", i, Task.CurrentId);
                    await Task.Delay(10);
                    if (i > 15) pls.Break();
                });

            Console.WriteLine("is completed:{0}", result2.IsCompleted);
            Console.WriteLine("lowest break iteration:{0}", result2.LowestBreakIteration);
            Console.ReadLine();

        }
    }
}
