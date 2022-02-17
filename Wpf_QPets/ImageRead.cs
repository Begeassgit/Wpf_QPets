using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wpf_QPets
{
    public class ReadImageName
    {
        public string[] GetImageNames()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"Image");
            int imageCount = directoryInfo.GetFiles().Length;
            string[] imageName = new string[imageCount];
            for (int i = 0; i < imageCount; i++)
            {
                imageName[i]=directoryInfo.GetFiles()[i].Name;
            }

            return imageName;
        }
    }
}
