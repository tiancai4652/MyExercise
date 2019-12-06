using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSleepInTask
{
    class Program
    {
        /// <summary>
        /// 运行路线:
        /// 1 进入DemoAsync2的方法构造
        /// 2 进入DemoAsync的方法构造
        /// 3 执行DemoAsync,执行Swait,在asyncTask类型的方法DemoAsync里遇见await，主线程返回DemoAsync的调用者，进入一个子线程:等待await的方法完成后执行其以后的方法
        /// 4 返回DemoAsync2方法，执行Swait,在asyncTask类型的方法DemoAsync2里遇见await，主线程返回DemoAsync2的调用者，进入一个子线程:等待await的方法完成后执行其以后的方法
        /// 5 返回Main,MainMain线程ID
        /// 6 DemoAsync.Task执行完毕，输入Task3.Sync线程ID
        /// 7 DemoAsync继续执行，输入Task2.Sync线程ID
        /// 8 DemoAsync执行完毕，执行DemoAsync2剩余部分，输入Task1.Sync线程ID
        /// 
        /// 
        /// 结果:
        /// Main
        /// Task3.Sync
        /// Task2.Sync
        /// Task1.Sync
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DemoAsync2();
            //Thread.Sleep(3000);
            Console.WriteLine("Main:" + Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }

        static async Task DemoAsync()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("Task3.Sync" + Thread.CurrentThread.ManagedThreadId);
            });
            Thread.Sleep(3000);
            Console.WriteLine("Task2.Sync" + Thread.CurrentThread.ManagedThreadId);
        }

        static async void DemoAsync2()
        {
            await DemoAsync();
            Thread.Sleep(3000);
            Console.WriteLine("Task1.Sync" + Thread.CurrentThread.ManagedThreadId);
        }

       
    }
}
