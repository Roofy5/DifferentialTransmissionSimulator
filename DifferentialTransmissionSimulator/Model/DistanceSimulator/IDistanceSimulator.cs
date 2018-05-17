using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.DistanceSimulator
{
    public interface IDistanceSimulator
    {
        IEnumerable<double> Simulate(Cable cable, IEnumerable<double> values);
    }

    public enum Cable
    {
        FIRST,
        SECOND
    }
}
