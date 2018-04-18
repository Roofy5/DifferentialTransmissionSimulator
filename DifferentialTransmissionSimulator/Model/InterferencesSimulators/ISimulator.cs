using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.InterferencesSimulators
{
    interface ISimulator
    {
        IEnumerable<double> Interrupt(IEnumerable<double> cableBits);
    }
}
