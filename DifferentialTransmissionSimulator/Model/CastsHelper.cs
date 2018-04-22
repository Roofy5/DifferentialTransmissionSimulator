using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model
{
    public static class CastsHelper
    {
        public static int[] ToIntArray(this IEnumerable<double> array)
        {
            int[] result = new int[array.Count()];
            for (int i = 0; i < array.Count(); i++)
                result[i] = (int)array.ElementAt(i);
            return result;
        }

        public static int[] ToInt(this string text)
        {
            int[] result = new int[text.Length];
            for (int i = 0; i < text.Length; i++)
                result[i] = (int)text[i];
            return result;
        }

        public static string ToIntString(this string text)
        {
            if (text.Length == 1)
            {
                return ((int)text[0]).ToString("x4");// ("x2");
            }

            StringBuilder bld = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
                bld.Append(((int)text[i]).ToString("x4"));
            return bld.ToString();
        }
    }
}
