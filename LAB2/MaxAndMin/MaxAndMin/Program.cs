using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MaxAndMin
{
    class Program
    {
        static void Main(string[] args)
        {
            int Minimum = 9999;
            int Maximum = -9999;
            FileStream fs = new FileStream("input.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadToEnd();
            string[] numbers = s.Split(' ');
            foreach(string ss in numbers)
            {
                Minimum = Math.Min(Minimum, int.Parse(ss));
                Maximum = Math.Max(Maximum, int.Parse(ss));

            }

            Console.WriteLine(Minimum);
            Console.WriteLine(Maximum);
            Console.ReadKey();

            sr.Close();
            fs.Close();






        }
    }
}
