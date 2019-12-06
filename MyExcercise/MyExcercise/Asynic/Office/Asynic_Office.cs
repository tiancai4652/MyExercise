using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyExcercise.Asynic.Office
{
    /// <summary>
    /// https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/async/index
    /// </summary>
    public class Asynic_Office
    {
        /// <summary>
        /// 同步阻塞代码:你将面包放进烤面包机后盯着此烤面包机,什么也不能做，直到面包弹出。
        /// </summary>
        public void SyncBreakfast()
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
        }

        public void SyncBreakfast2()
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


    }
}
