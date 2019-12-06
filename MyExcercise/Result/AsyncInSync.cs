using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Result
{
    /// <summary>
    /// 同步函数里有异步代码(只有一种情况:同步+返回值为Void的异步)
    /// 
    /// 结论:异步方法中,Await之前还是当前线程的同步方法
    /// </summary>
    public class AsyncInSync
    {
        /// <summary>
        /// 同步代码里有异步代码
        /// 
        /// 
        /// 结果
        /// Main Thread Before DelayAsync:1
        /// DelayAsync Before Await Thread ID:1
        /// DelayReturnTaskAsync Before Await Thread ID:1
        /// Main Thread After DelayAsync:1
        /// DelayReturnTaskAsync After Await Thread ID:4
        /// DelayAsync After Await Thread ID:4
        /// </summary>
        static public void Test()
        {
            Console.WriteLine("Main Thread Before DelayAsync:" + Thread.CurrentThread.ManagedThreadId);

            DelayAsync(1000);

            Console.WriteLine("Main Thread After DelayAsync:" + Thread.CurrentThread.ManagedThreadId);
        }

        /// <summary>
        /// 异步代码里有异步代码
        /// 
        /// 
        /// 异步方法里有同步代码执行顺序：
        /// 1 当前线程:进入DelayAsync方法
        /// 2 当前线程:同步执行Thread.Sleep(1000);
        /// 3 当前线程:(发现async里有await）当前线程返回DelayAsync的调用方。
        /// 4 其他线程:执行await后的函数和Thread.Sleep(2000);)
        ///  
        /// 在异步方法中：Await之前的执行还是调用的线程，Await之后的执行就是另一个线程了
        /// 即:异步方法中,Await之前还是当前线程的同步方法
        /// 
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        static async void DelayAsync(int ms)
        {
            Thread.Sleep(1000);
            Console.WriteLine("DelayAsync Before Await Thread ID:" + Thread.CurrentThread.ManagedThreadId);
            await DelayReturnTaskAsync(ms);
            Console.WriteLine("DelayAsync After Await Thread ID:" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
        }

        /// <summary>
        /// 异步代码里有异步代码
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        static async Task DelayReturnTaskAsync(int ms)
        {
            Thread.Sleep(1000);
            Console.WriteLine("DelayReturnTaskAsync Before Await Thread ID:" + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(ms);
            Console.WriteLine("DelayReturnTaskAsync After Await Thread ID:" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
        }


    }
}
