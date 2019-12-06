using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Result
{
    public class AsyncReturnValue
    {
        /// <summary>
        /// 无法等待具有 void 返回类型的异步方法，并且无效返回方法的调用方捕获不到异步方法引发的任何异常。
        /// </summary>
        public static async void ReturnVoidAsync()
        {
            Console.WriteLine("ReturnVoidAsync Before Task Thread ID:" + Thread.CurrentThread.ManagedThreadId);
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("ReturnVoidAsync In Task Thread ID:" + Thread.CurrentThread.ManagedThreadId);
            });
            Console.WriteLine("ReturnVoidAsync After Task Thread ID:" + Thread.CurrentThread.ManagedThreadId);
        }

        /// <summary>
        /// 每个返回的任务表示正在进行的工作。 任务可封装有关异步进程状态的信息，如果未成功，则最后会封装来自进程的最终结果或进程引发的异常。
        /// </summary>
        /// <returns></returns>
        public static async Task ReturnTaskAsync()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });
        }

        /// <summary>
        /// 每个返回的任务表示正在进行的工作。 任务可封装有关异步进程状态的信息，如果未成功，则最后会封装来自进程的最终结果或进程引发的异常。
        /// </summary>
        /// <returns></returns>
        public static async Task<int> ReturnTaskIntAsync()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });
            return 0;
        }


    }
}
