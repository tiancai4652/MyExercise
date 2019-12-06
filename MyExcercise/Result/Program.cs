using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Result
{
    class Program
    {

        static void Main(string[] args)
        {
            AsyncInAsync.Test2Async();
            Console.ReadKey();
        }

        /// <summary>
        /// 同步函数里有异步代码
        /// </summary>
        void Test1()
        {
            DoubleDelayAsync(1000);


        }

        async Task DoubleDelayCanWaitAsync(int ms)
        {
            await Task.Delay(ms);
            Thread.Sleep(ms);
        }

        async void DoubleDelayAsync(int ms)
        {
            await Task.Delay(ms);
            Thread.Sleep(ms);
        }
    }
}
