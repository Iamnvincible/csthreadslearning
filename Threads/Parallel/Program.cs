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


            //Parallel.For() 并行运行迭代
            ParallelLoopResult result = Parallel.For(0, 10, i =>
            {
                Console.WriteLine("{0},task:{1},thread:{2}", i, Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            });
            Console.WriteLine("is completed:{0},lowest break iteration:{1}", result.IsCompleted,result.LowestBreakIteration);


            //提前停止Parallel.For()
            ParallelLoopResult result2 = Parallel.For(10, 70, async (i, pls) =>
                {
                    Console.WriteLine("i:{0} task {1}", i, Task.CurrentId);
                    await Task.Delay(10);
                    if (i > 15) pls.Break();
                });

            Console.WriteLine("is completed:{0}", result2.IsCompleted);
            Console.WriteLine("lowest break iteration:{0}", result2.LowestBreakIteration);

            //这个简直太难了
            Parallel.For<string>(0, 20, () =>
            {
                Console.WriteLine("init thread {0},task {1} ", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                return String.Format("t{0}", Thread.CurrentThread.ManagedThreadId);
            }, (i, pls, str1) =>
            {
                Console.WriteLine("Body i {0} str1 {1} thread {2} task {3}", i, str1, Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                Thread.Sleep(10);
                return String.Format("i {0}", i);
            }, (str1) =>
            {
                Console.WriteLine("finally {0}", str1);
            });

            //ForEach()  并行版的foreach
            string[] data = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" ,"ten","eleven","twelve"};
            ParallelLoopResult result3 = Parallel.ForEach<string>(data, s =>
            {
                Console.WriteLine(s);
            });

            //多个任务并行运行
            Parallel.Invoke(Foo, Bar,Bar1);



            Console.ReadLine();

        }
        static void Foo()
        {
            Console.WriteLine("foo");
            for (int i = 0; i < 1000; i++)
            {

            }
        }
        static void Bar()
        {
            Console.WriteLine("bar");
        }
        static void Bar1()
        {
            Console.WriteLine("ba1r");
            for (int i = 0; i < 200000; i++)
            {

            }
        }
    }
}
