using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationOfClass
{
    class Rectangle
    {
        public double width;
        public double height;
        public double Area;
        public double Perimeter;
        
        


        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
            Area = FindArea(this.width, this.height);
            Perimeter = FindPerimeter(this.width, this.height);

        }

         public static double FindArea(double width, double height)
        {
            return width * height;
        }


         public static double FindPerimeter(double width, double height)
        {
            return 2 * (width + height);
        }

        public override string ToString()
        {
            return width + " " + height + " " + Area + " " + Perimeter;
        }


    }
}
