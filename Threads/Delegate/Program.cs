using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        delegate int intresult(int x, int y);
        static void Main(string[] args)
        {
            intresult a = hahaha;
            int c = a(3, 4);
            Action<int, int> baction = (x, y) =>
              {
                  Console.WriteLine(x + y);
              };
            baction(4, 5);
            //baction.BeginInvoke(3, 4);


            Console.WriteLine(c);
            int xx = myfunc(x =>
              {
                  return x * x;
              }, 3);
            Console.WriteLine(xx);

            Console.ReadKey();
        }
        static int hahaha(int x, int y)
        {
            return x + y;
        }
        static int myfunc(Func<int, int> f1, int x)
        {
            return f1(x);
        }
    }
}
