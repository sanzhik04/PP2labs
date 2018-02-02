using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationOfClass
{
    class Circle
    {
        double radius;
        double Area;
        double Diameter;
        double Circumference;


        public Circle(double radius)
        {
            this.radius = radius;
            Diameter = FindDiameter(this.radius);
            Area = FindArea(this.radius);
            Circumference = FindCircumference(this.radius);




        }


        static double FindArea(double radius)
        {
            return Math.PI * radius * radius;
        }

        static double FindDiameter(double radius)
        {
            return 2 * radius; 
        }

        static double FindCircumference(double radius)
        {
            return 2 * Math.PI * radius;
        }


        public override string ToString()
        {
            return radius + " " + Area + " " + Diameter + " " + Circumference; 
        }
    }
}
