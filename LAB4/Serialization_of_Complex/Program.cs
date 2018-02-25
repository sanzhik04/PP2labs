using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization_of_Complex
{
    class Program
    {
         static void Save()
         {
            FileStream fs = new FileStream("complex.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
                         Complex s = new Complex(4, 3);

            bf.Serialize(fs, s);

            fs.Close();
         }

        static void Load()
        {
           
                FileStream fs = new FileStream("complex.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                Complex s = bf.Deserialize(fs) as Complex;
                Console.WriteLine(s);
                fs.Close();
            

        }


        static void Main(string[] args)
        {
            
            
            ConsoleKeyInfo pressedButton = Console.ReadKey();
            switch (pressedButton.Key)
            {
                case ConsoleKey.Spacebar:
                    Save();
                    break;
                case ConsoleKey.Enter:
                    Load();
                    break;

            }

           


        }    
    }
}
