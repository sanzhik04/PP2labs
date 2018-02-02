using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationOfClass
{
    class Program
    {
      static void Main()
        {
            Student d = new Student("sakon", "hacker", 3.63);
            Console.WriteLine(d);
            
            Rectangle a = new Rectangle(3, 5);
            Console.WriteLine(a);
            Circle b = new Circle(2);
            Console.WriteLine(b);








            Console.ReadKey();

            
        }  
    }
}
