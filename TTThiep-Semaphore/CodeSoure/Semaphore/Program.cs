using System;
using System.Threading;

namespace Program
{
    class Demo
    {
        static Thread[] t = new Thread[5];
        static Semaphore semaphore = new Semaphore(2, 2);
        static void DoSomething()
        {
            Console.WriteLine("{0} = waiting", Thread.CurrentThread.Name);
            semaphore.WaitOne();
            Console.WriteLine("{0} begins!", Thread.CurrentThread.Name);
            Thread.Sleep(1000);
            Console.WriteLine("{0} releasing...", Thread.CurrentThread.Name);
            semaphore.Release();
        }
        static void Main(string[] args)
        {
            for (int j = 0; j < 5; j++)
            {
                t[j] = new Thread(DoSomething);
                t[j].Name = "thread number " + j;
                t[j].Start();
            }
            Console.Read();
        }
    }
}