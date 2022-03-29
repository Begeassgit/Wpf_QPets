using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wpf_QPets
{
    public class ImageRead
    {
        public Dictionary<string,string> GetImageNames(string role)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"Image/"+role);
            int imageCount = directoryInfo.GetFiles().Length;
            Dictionary<string,string> fileNames = new();
            for (int i = 0; i < imageCount; i++)
            {
               fileNames.Add(directoryInfo.GetFiles()[i].Name, directoryInfo.GetFiles()[i].Name);
            }

            return fileNames;
        }
    }
}
