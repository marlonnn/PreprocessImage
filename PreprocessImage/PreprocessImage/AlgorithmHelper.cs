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
        public static Random random = new Random();

        [DllImport("ImgAlgorithm.dll", EntryPoint = "CalcImageDiff")]
        public extern static double CalcImageDiff(string firstImagePath, string secondImagePath,
            short width, short height, string resultImagePath);

        //simulate
        public static double CalcDiff(string firstImagePath, string secondImagePath)
        {
            double diff = 0.2f;

            return diff * random.Next(0,3);
        }
    }
}
