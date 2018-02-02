using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] nums = s.Split(' ');
            Complex x = new Complex(int.Parse(nums[0]), int.Parse(nums[1]));
            Complex y = new Complex(int.Parse(nums[2]), int.Parse(nums[3]));


            Complex t = x + y;
            

            Console.WriteLine(t);
            Console.ReadKey();





            








        }


           
           
            
        
    }
}
