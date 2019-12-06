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
        public static void SyncBreakfast()
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
        public static async System.Threading.Tasks.Task SyncBreakfast2Async()
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

        #region Private

        static void PourCoffee()
        {
            Thread.Sleep(1000 * 2);
        }

        static int FryEggs()
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
