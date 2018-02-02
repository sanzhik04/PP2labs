using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
    class Complex
    {
        public int a, b;



        public Complex(int a, int b)
        {
            this.a = a;
            this.b = b;

        }



        

        public static Complex operator +(Complex x,Complex y)
        {
            int k = x.a + y.a;
            int l = x.b + y.b;

            return new Complex(k, l);
        }

        


        
        



        public override string ToString()
        {
            return (String.Format("{0}+{1}i", a, b));
        }
    }
}
