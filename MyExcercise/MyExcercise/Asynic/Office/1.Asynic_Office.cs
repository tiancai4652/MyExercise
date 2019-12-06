using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyExcercise.Asynic.Office
{
    /// <summary>
    /// https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/async/index
    /// </summary>
    public class Asynic
    {
        /// <summary>
        /// 同步阻塞代码:你将按顺序执行，面包放进烤面包机后盯着此烤面包机,什么也不能做，直到面包弹出。
        /// </summary>
        public static void Breakfast()
        {
            //Coffee cup = PourCoffee();
            //Console.WriteLine("coffee is ready");
            //Egg eggs = FryEggs(2);
            //Console.WriteLine("eggs are ready");
            //Bacon bacon = FryBacon(3);
            //Console.WriteLine("bacon is ready");
            //Toast toast = ToastBread(2);
            //ApplyButter(toast);
            //ApplyJam(toast);
            //Console.WriteLine("toast is ready");
            //Juice oj = PourOJ();
            //Console.WriteLine("oj is ready");
            //Console.WriteLine("Breakfast is ready!");

            PourCoffee();
            Console.WriteLine("coffee is ready");
            FryEggs();
            Console.WriteLine("eggs are ready");
            FryBacon();
            Console.WriteLine("bacon is ready");
            ToastBread();
            ToastBreadApplyButter();
            ToastBreadApplyJam();
            Console.WriteLine("toast is ready");
            PourJuice();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");

        }

        /// <summary>
        /// 当鸡蛋或培根在烹饪时，这个代码不会阻塞。
        /// 不过，这段代码不会启动任何其他任务。
        /// 你还是会把吐司放进烤面包机，盯着它直到它爆开。但至少，你会回应任何想引起你注意的人
        /// 
        /// 我的理解是一个厨师变成了三个厨师，第一个厨师煎蛋，第二个煎培根，第三个烤面包，第三个厨师还是会一直盯着烤面包机.....？？？？
        /// </summary>
        /// <returns></returns>
        public static void Breakfast2()
        {
            //Coffee cup = PourCoffee();
            //Console.WriteLine("coffee is ready");
            //Egg eggs = await FryEggs(2);
            //Console.WriteLine("eggs are ready");
            //Bacon bacon = await FryBacon(3);
            //Console.WriteLine("bacon is ready");
            //Toast toast = await ToastBread(2);
            //ApplyButter(toast);
            //ApplyJam(toast);
            //Console.WriteLine("toast is ready");
            //Juice oj = PourOJ();
            //Console.WriteLine("oj is ready");

            //Console.WriteLine("Breakfast is ready!");
        }

        /// <summary>
        /// 你可以一次启动所有的异步任务。 你仅在需要结果时才会等待每项任务。
        /// 使用 Task 或 Task<TResult> 对象来保存运行中的任务。 你首先需要 await 每项任务，然后再使用它的结果
        /// </summary>
        public static void Breakfast3()
        {
            //Coffee cup = PourCoffee();
            //Console.WriteLine("coffee is ready");
            //Task<Egg> eggsTask = FryEggs(2);
            //Task<Bacon> baconTask = FryBacon(3);
            //Task<Toast> toastTask = ToastBread(2);
            //Toast toast = await toastTask;
            //ApplyButter(toast);
            //ApplyJam(toast);
            //Console.WriteLine("toast is ready");
            //Juice oj = PourOJ();
            //Console.WriteLine("oj is ready");

            //Egg eggs = await eggsTask;
            //Console.WriteLine("eggs are ready");
            //Bacon bacon = await baconTask;
            //Console.WriteLine("bacon is ready");

            //Console.WriteLine("Breakfast is ready!");



        }


        /// <summary>
        /// 将异步任务和等待异步任务结果的同步任务合并成一个异步任务
        /// 异步任务结果+同步任务=新的异步任务
        /// </summary>
        //async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        //{
        //    var toast = await ToastBreadAsync(number);
        //    ApplyButter(toast);
        //    ApplyJam(toast);
        //    return toast;
        //}

        /// <summary>
        /// 最终代码
        /// 尽可能启动任务，不要在等待任务完成时造成阻塞。
        /// </summary>
        void Breakfast4()
        {
            //Coffee cup = PourCoffee();
            //Console.WriteLine("coffee is ready");
            //var eggsTask = FryEggsAsync(2);
            //var baconTask = FryBaconAsync(3);
            //var toastTask = MakeToastWithButterAndJamAsync(2);

            //var allTasks = new List<Task> { eggsTask, baconTask, toastTask };
            //while (allTasks.Any())
            //{
            //    Task finished = await Task.WhenAny(allTasks);
            //    if (finished == eggsTask)
            //    {
            //        Console.WriteLine("eggs are ready");
            //    }
            //    else if (finished == baconTask)
            //    {
            //        Console.WriteLine("bacon is ready");
            //    }
            //    else if (finished == toastTask)
            //    {
            //        Console.WriteLine("toast is ready");
            //    }
            //    allTasks.Remove(finished);
            //}
            //Juice oj = PourOJ();
            //Console.WriteLine("oj is ready");
            //Console.WriteLine("Breakfast is ready!");

            //async Task<Toast> MakeToastWithButterAndJamAsync(int number)
            //{
            //    var toast = await ToastBreadAsync(number);
            //    ApplyButter(toast);
            //    ApplyJam(toast);
            //    return toast;
            //}

        }




        #region Private

        static void PourCoffee()
        {
            Thread.Sleep(1000 * 2);
        }

        static void FryEggs()
        {
            Thread.Sleep(1000 * 2);
        }

        static void FryBacon()
        {
            Thread.Sleep(1000 * 2);
        }

        static void ToastBread()
        {
            Thread.Sleep(1000 * 2);
        }

        static void ToastBreadApplyButter()
        {
            Thread.Sleep(1000 * 2);
        }

        static void ToastBreadApplyJam()
        {
            Thread.Sleep(1000 * 2);
        }

        static void PourJuice()
        {
            Thread.Sleep(1000 * 2);
        }




        #endregion

    }
}
