using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManagerTrue
{
    class Layer
    {
        public DirectoryInfo DirectoryInfo;
        public string path;
        public int index;
        public List<FileSystemInfo> elements;
        public List<DirectoryInfo> dirs;
        public List<FileInfo> files;
        

        public Layer(string path, int index)
        {
            this.path = path;
            this.index = index;
            this.DirectoryInfo = new DirectoryInfo(path);

            elements = new List<FileSystemInfo>();
            dirs = new List<DirectoryInfo>();
            files = new List<FileInfo>();
            elements.AddRange(DirectoryInfo.GetDirectories());
            elements.AddRange(DirectoryInfo.GetFiles());
            dirs.AddRange(DirectoryInfo.GetDirectories());
            files.AddRange(DirectoryInfo.GetFiles());

        }


        public void Process(int v)
        {
            this.index += v;
            if (this.index < 0)
            {
                this.index = elements.Count - 1;
            }
            if (this.index >= elements.Count)
            {
                this.index = 0;
            }
        }

        public string GetSelectedItemInfo()
        {
            return this.elements[index].FullName;
        }


        public FileSystemInfo GetSelectedItem()
        {


            return this.elements[index];

        }

        public int GetItemsNumber()
        {
            return this.elements[index].Name.Length;
        }

        public static long DirSize(DirectoryInfo dir)
        {
            long size = 0;
            FileInfo[] fis = dir.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            DirectoryInfo[] dis = dir.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }






    }
}
