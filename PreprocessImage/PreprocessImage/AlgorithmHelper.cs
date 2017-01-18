using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreprocessImage
{
    public class AlgorithmHelper
    {
        public static Random random = new Random();
        public static double CalcDiff(string preImage, string currentImage)
        {
            double diff = 0.0f;
            diff = random.Next(60, 100);
            return diff;
        }
    }
}
