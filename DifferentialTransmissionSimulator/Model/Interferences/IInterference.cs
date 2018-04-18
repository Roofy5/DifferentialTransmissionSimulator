using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.Interferences
{
    public interface IInterference
    {
        string Name { get; }
        double[] GetInterference(double frequency, double time);
    }
}
