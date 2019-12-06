using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Result
{
    public class AsyncInAsync
    {
     
        public static void Test()
        {
            DelayReturnVoidAsync(1000);
        }

        public async static void Test2Async()
        {
           await DelayReturnTaskAsync();
        }



        /// <summary>
        /// 异步代码里有返回值为Void的异步,由于没有Await没法等待，所以就是同步代码
        /// 因为返回值为Void的异步不能等待，所以整体函数不能等待，视为同步函数
        //DelayReturnVoidAsync Before ReturnVoidAsync Thread ID:1
        //ReturnVoidAsync Before Task Thread ID:1
        //DelayReturnVoidAsync After ReturnVoidAsync Thread ID:1
        //ReturnVoidAsync In Task Thread ID:3
        //ReturnVoidAsync After Task Thread ID:3
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        static void DelayReturnVoidAsync(int ms)
        {
            Console.WriteLine("DelayReturnVoidAsync Before ReturnVoidAsync Thread ID:" + Thread.CurrentThread.ManagedThreadId);
            AsyncReturnValue.ReturnVoidAsync();
            Console.WriteLine("DelayReturnVoidAsync After ReturnVoidAsync Thread ID:" + Thread.CurrentThread.ManagedThreadId);
        }

        //DelayReturnTaskAsync Before ReturnTaskAsync Thread ID:1
        //ReturnTaskAsync Before Task Thread ID:1
        //ReturnTaskAsync In Task Thread ID:3
        //ReturnTaskAsync After Task Thread ID:3
        //DelayReturnTaskAsync After ReturnTaskAsync Thread ID:3
        static async Task DelayReturnTaskAsync()
        {
            Console.WriteLine("DelayReturnTaskAsync Before ReturnTaskAsync Thread ID:" + Thread.CurrentThread.ManagedThreadId);
            await AsyncReturnValue.ReturnTaskAsync();
            Console.WriteLine("DelayReturnTaskAsync After ReturnTaskAsync Thread ID:" + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
