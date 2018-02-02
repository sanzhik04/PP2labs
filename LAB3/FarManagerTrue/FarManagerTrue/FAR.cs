using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManagerTrue

{

    enum FarMode
    {
        Explorer,
        FileReader
    }

    class FAR
    {
        Stack<Layer> layerHistory = new Stack<Layer>();
        Layer activeLayer;
        FarMode mode = FarMode.Explorer;

        public FAR(string path)
        {
            this.activeLayer = new Layer(path, 0);
        }

        public void Draw()
        {
            switch (mode)
            {
                case FarMode.Explorer:

                    DrawExplorer();

                    break;
                case FarMode.FileReader:

                    DrawFileReader();

                    break;
                default:
                    break;
            }

            DrawStatusBar();
            DrawStaticSize();
            // DrawPath();
            //DrawElementSize();
            //DrawLAT();
            DrawStaticLAT();
            
            
            
        }

        public static long DirSize(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            long size = 0;
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di.FullName);
            }
            return size;
        }


        

        private void DrawStatusBar()
        {
            Console.SetCursorPosition(90, 55);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(mode);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Blue;
            //Console.SetCursorPosition(33,activeLayer.index);
            //Console.WriteLine("Last Access Time:");
            

        }

        private void DrawLAT()
        {
            if (activeLayer.elements.Count != 0)
            {
                Console.SetCursorPosition(50, activeLayer.index);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(activeLayer.GetSelectedItem().LastAccessTime);
            }
        }



        private void DrawPath()
        {
            Console.SetCursorPosition(35, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(OtrezPath(activeLayer.GetSelectedItemInfo()));
        }


        private void DrawElementSize()
        {

            if (activeLayer.elements.Count != 0)
            {


                if (activeLayer.GetSelectedItem().GetType() == typeof(FileInfo))
                {
                    FileInfo File = new FileInfo(activeLayer.GetSelectedItemInfo());
                    Console.SetCursorPosition(24, activeLayer.index);
                    Console.WriteLine("{0} KB", File.Length / 1024);
                }
                if (activeLayer.GetSelectedItem().GetType() == typeof(DirectoryInfo))
                {
                    Console.SetCursorPosition(24, activeLayer.index);
                    Console.WriteLine("{0} KB", DirSize(activeLayer.GetSelectedItemInfo()) / 1024);



                }
            }

            
                

            
        }

        private void DrawFileReader()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream(activeLayer.GetSelectedItemInfo(), FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);

                Console.WriteLine(sr.ReadToEnd());

            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry, cannot open this file!");

            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }

                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        private void DrawExplorer()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            for (int i = 0; i < activeLayer.elements.Count; ++i)
            {

                if (i == activeLayer.index)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }

                if (activeLayer.elements[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
               
                Console.WriteLine(Otrez(activeLayer.elements[i].Name));
                
                
                
            }

        }

        private void DrawStaticLAT()
        {
            for(int i  = 0; i < activeLayer.elements.Count; i++)
            {
                Console.SetCursorPosition(44, i);
                Console.WriteLine(activeLayer.elements[i].LastAccessTime);
            }
        }
        





        private  void DrawStaticSize()
        {


            Console.SetCursorPosition(24, 0);
            for (int i = 0; i < activeLayer.dirs.Count; i++)
            {
                Console.SetCursorPosition(24, i);
                Console.WriteLine("{0} KB",DirSize(activeLayer.dirs[i].FullName)/1024);
                
            }
            
            for (int i = 0; i < activeLayer.files.Count; i++)
            {
                Console.SetCursorPosition(24,i+activeLayer.dirs.Count);
                Console.WriteLine("{0} KB",activeLayer.files[i].Length / 1024);

            }
        }

        public string Otrez(string s)
        {
            bool ok = false;
            string ss = null;
            if (s.Length >= 17)
            {
                ok = true;
                for (int i = 0; i < 17; i++)
                {
                    ss += s[i];
                }
                ss += "..";
            }
            if (ok) s = null;
            return s + ss;
        }

        public string OtrezPath(string s)
        {
            bool ok = false;
            string ss = null;
            if (s.Length >=60)
            {
                ok = true;
                for (int i = 0; i < 61; i++)
                {
                    ss += s[i];
                }
                ss += "..";
            }
            if (ok) s = null;
            return s + ss;
        }


        public void Process(ConsoleKeyInfo pressedKey)
        {
            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    activeLayer.Process(-1);
                    break;
                case ConsoleKey.DownArrow:
                    activeLayer.Process(1);
                    break;
                case ConsoleKey.Enter:
                    try
                    {
                        if (activeLayer.elements[activeLayer.index].GetType() == typeof(DirectoryInfo))
                        {
                            mode = FarMode.Explorer;
                            layerHistory.Push(activeLayer);
                            activeLayer = new Layer(activeLayer.GetSelectedItemInfo(), 0);
                        }
                        else if (activeLayer.elements[activeLayer.index].GetType() == typeof(FileInfo))
                        {
                            mode = FarMode.FileReader;


                        }
                    }
                    catch (Exception e)
                    {
                        activeLayer = layerHistory.Pop();
                    }
                    break;
                case ConsoleKey.Backspace:
                    if (mode == FarMode.Explorer)
                    {
                        activeLayer = layerHistory.Pop();
                    }
                    else if (mode == FarMode.FileReader)
                    {
                        mode = FarMode.Explorer;
                    }

                    break;
                default:
                    break;
            }

        }
    }
}