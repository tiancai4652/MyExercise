using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhatAwaitWait
{
    class Program
    {
        /// <summary>
        /// 之前一直理解的是,await 等待的是后面紧跟着的方法,实际等待的是  这个方法返回的 Task 执行完毕,而这个方法里面的非 task 代码依然是同步执行.
        /// 
        /// 
        /// 我的理解:
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Print();
            Console.WriteLine("5 :::" + Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }
        public static async void Print()
        {
            Console.WriteLine("1 :::" + Thread.CurrentThread.ManagedThreadId);
            await PrintAsync();//主线程走到这里的时候并没有返回.所谓返回,是指从当前 async 方法内部返回到调用该方法的位置继续往下执行
            Console.WriteLine("8 :::" + Thread.CurrentThread.ManagedThreadId);//由于 PrintAsync() 方法返回的是 tk2,所以这里要等 tk2 执行完毕才会执行.
        }

        public static Task PrintAsync()
        {
            Thread.Sleep(10000);
            Console.WriteLine("2 :::" + Thread.CurrentThread.ManagedThreadId);
            Task tk1 = Task.Run(() =>
            {
                Thread.Sleep(10000);
                Console.WriteLine("6 :::" + Thread.CurrentThread.ManagedThreadId);
            });
            Console.WriteLine("3 :::" + Thread.CurrentThread.ManagedThreadId);
            Task tk2 = Task.Run(() =>
            {
                Thread.Sleep(10000);
                Console.WriteLine("7 :::" + Thread.CurrentThread.ManagedThreadId);
            });
            Console.WriteLine("4 :::" + Thread.CurrentThread.ManagedThreadId);//主线程走到这里才返回.当然,tk1,tk2 已经开始执行了.
            return tk2;
        }

    }
}
