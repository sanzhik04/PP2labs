using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Food : GameObject
    {
         
        
        public Food(Point firstPoint, ConsoleColor color, char sign) : base(firstPoint, color, sign)
        {
            


        }
        public Food()
        {

        }

        public Point CreateFood(List<Point> body, List<Point> body1)
        {
            bool exit = false;
            int x=5, y=5;
            while (!exit)
            {
                exit = true;
                x = new Random().Next(1, 34);
                y = new Random().Next(1, 21);
                foreach(Point p in body)
                {
                    if(p.X == x && p.Y == y)
                    {
                        exit = false;
                    }
                }
                foreach (Point p in body1)
                {
                    if (p.X == x && p.Y == y)
                    {
                        exit = false;
                    }
                }

            }
            Point p1 = new Point { X = x, Y = y };
            return p1;


        }

    }  
}