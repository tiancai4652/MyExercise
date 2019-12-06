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
        
        
        }


        /// <summary>
        /// 异步代码里有返回值为Void的异步
        /// 因为返回值为Void的异步不能等待，所以整体函数不能等待，视为同步函数
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        static void DelayReturnVoidAsync(int ms)
        {
            Thread.Sleep(1000);
            Console.WriteLine("DelayReturnVoidAsync Before ReturnVoidAsync Thread ID:" + Thread.CurrentThread.ManagedThreadId);
            AsyncReturnValue.ReturnVoidAsync();
            Console.WriteLine("DelayReturnVoidAsync After ReturnVoidAsync Thread ID:" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
        }
    }
}
