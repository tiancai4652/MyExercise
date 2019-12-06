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
          
        }
        
        /// <summary>
        /// 同步函数里有异步代码
        /// </summary>
        void Test1()
        {
             Task.Delay(1000);


        }
    }
}
