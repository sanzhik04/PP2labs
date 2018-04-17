using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LAB8
{
    class Program
    {
        public delegate int MyDelegate();
        static void Main(string[] args)
        {
            Sum numbers = new Sum(5, 4);
            MyDelegate Invoker = numbers.Find;
            Thread.Sleep(10000);
            Console.WriteLine(Invoker.Invoke());
             
           

        }
    }
}
