using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MinPrime
{
    class Program
    {

        static bool IsPrime(int a)
        {
            bool res = true;
            if (a == 1)
            {
                res = false;
            }
            for(int i = 2; i <= Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                {
                    res = false;
                }


            }

            return res;
        }



        

        
        static void Main(string[] args)
        {
            int Minimum = 9999;
            FileStream fs = new FileStream("input.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string ss = sr.ReadToEnd();
            string[] arr = ss.Split(' ');
            foreach(string s in arr)
            {
                if(int.Parse(s)<Minimum && IsPrime(int.Parse(s)) == true)
                {
                    Minimum = int.Parse(s);
                }
            }



            
            
            sr.Close();
            fs.Close();

            FileStream sf = new FileStream("output.txt", FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(sf);
            sw.WriteLine(Minimum);
            sw.Close();
            sf.Close();


            
           
            
            

        }
    }
}
