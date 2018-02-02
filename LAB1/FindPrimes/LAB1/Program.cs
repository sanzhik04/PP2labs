using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string s in args) //пробегаемся по массиву слов из консоли
            {
                int n = int.Parse(s); //каждый элемент массива превращаем в интеджер
                bool t = false;
                for (int i = 2; i <= Math.Sqrt(n); i++) // сущетсвуют ли делители числа?
                {
                    if (n % i == 0)
                        t = true;
                }
                if (n != 1 && t == false) // если их нет, то выводим
            }
            Console.ReadKey();
        }
    }
}
