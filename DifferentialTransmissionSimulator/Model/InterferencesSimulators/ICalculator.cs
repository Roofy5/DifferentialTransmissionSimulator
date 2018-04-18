using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.InterferencesSimulators
{
    interface ICalculator
    {
        IEnumerable<double> Calculate(IEnumerable<double> cableBits, IEnumerable<IEnumerable<double>> interferencedData);
    }
}
