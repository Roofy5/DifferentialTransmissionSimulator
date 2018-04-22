using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.BitsTranslator
{
    public class Utf8Translator : ITranslator
    {
        public string FromBits(int[] value)
        {
            if (value == null || value.Length < 8)
                throw new ArgumentException("Value is not allowed");

            BitArray array = new BitArray(value.Length);
            int j = 0;
            for (int i = value.Length - 1; i >= 0; i--)
                array[i] = value[j++] == 1 ? true : false;

            byte[] bytes = new byte[array.Length];
            array.CopyTo(bytes, 0);

            return System.Text.Encoding.UTF8.GetString(bytes, 0, 2);
        }

        public int[] ToBits(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length != 1)
                throw new ArgumentException("Value should contains one character");

            BitArray array = new BitArray(System.Text.Encoding.UTF8.GetBytes(value));
            int[] result = new int[array.Length];
            int j = 0;
            for (int i = result.Length - 1; i >= 0; i--)
                result[i] = array[j++] ? 1 : 0;

            return result;
        }
    }
}
