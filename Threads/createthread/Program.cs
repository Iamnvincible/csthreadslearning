using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace createthread
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = Thread.CurrentThread;
            thread.Name = "Main Thread";
            string threadMessage = string.Format("Thread ID:{0}\n    Current AppDomainId:{1}\n    " +
                "Current ContextId:{2}\n    Thread Name:{3}\n    " +
                "Thread State:{4}\n    Thread Priority:{5}\n",
                thread.ManagedThreadId, Thread.GetDomainID(), Thread.CurrentContext.ContextID,
                thread.Name, thread.ThreadState, thread.Priority);
            Console.WriteLine(threadMessage);
            Console.ReadKey();
        }
    }
}
