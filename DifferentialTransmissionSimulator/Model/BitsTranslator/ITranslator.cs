using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.BitsTranslator
{
    public interface ITranslator
    {
        int[] ToBits(string value);
        string FromBits(int[] value);
    }
}
