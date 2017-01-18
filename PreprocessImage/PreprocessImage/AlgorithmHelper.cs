using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PreprocessImage
{
    public class AlgorithmHelper
    {
        [DllImport("ImgAlgorithm.dll", EntryPoint = "CalcImageDiff")]
        public extern static double CalcImageDiff(string firstImagePath, string secondImagePath,
            short width, short height, string resultImagePath);
    }
}
