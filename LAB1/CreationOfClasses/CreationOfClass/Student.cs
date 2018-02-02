using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationOfClass
{
    class Student
    {
         public string name;
        public string sname;
        public double gpa;
        
        public Student(string name, string sname,double gpa)
        {
            this.name = name;
            this.sname = sname;
            this.gpa = gpa;


        }
        public  override string ToString()
        {
            return this.name + " " + sname + " " + gpa;

        }

        

    }
}
