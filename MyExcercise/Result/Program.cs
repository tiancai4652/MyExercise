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
        /// <summary>
        /// 复习时:
        /// 看这个AsyncInSync.Test();就行了，知道方法执行顺序
        /// 还有论坛例子
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //AsyncInAsync.Test2Async();
            //AsyncInAsync.Test();
            AsyncInSync.Test();
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
