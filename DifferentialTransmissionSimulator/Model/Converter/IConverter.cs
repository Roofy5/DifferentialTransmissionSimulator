using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.Converter
{
    interface IConverter
    {
        IEnumerable<double> FromAnalog(int numberOfResulBits,IEnumerable<double> signal);
    }
}
