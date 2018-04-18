using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model
{
    interface ISignalOperator
    {
        IEnumerable<double> Subtract(IEnumerable<double> signal, IEnumerable<double> invertedSignal);
        IEnumerable<double> Add(IEnumerable<double> signal, IEnumerable<double> invertedSignal);
    }
}
