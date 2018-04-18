using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.BitsTranslator
{
    public class AsciiTranslator : ITranslator
    {
        public string FromBits(int[] value)
        {
            if (value == null || value.Length != 8)
                throw new ArgumentException("Value is not allowed");

            BitArray array = new BitArray(value.Length);
            int j = 0;
            for (int i = value.Length - 1; i >= 0; i--)
                array[i] = value[j++]==1 ? true : false;

            byte[] bytes = new byte[array.Length];
            array.CopyTo(bytes, 0);

            return System.Text.Encoding.ASCII.GetString(bytes,0,1);
        }

        public int[] ToBits(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length != 1)
                throw new ArgumentException("Value should contains one character");

            /*int[] result = new int[sizeof(char)*8];
            char letter = value[0];
            for (int i = sizeof(char) * 8 - 1; i >= 0 ; i--)
            {
                result[i] = letter & 1;
                letter >>= 1;
            }*/
            BitArray array = new BitArray(System.Text.Encoding.ASCII.GetBytes(value));
            int[] result = new int[array.Length];
            int j = 0;
            for (int i = result.Length-1; i >= 0; i--)
                result[i] = array[j++] ? 1 : 0;
            
            return result;
        }
    }
}
