using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.Interferences
{
    class SinusInterference : IInterference
    {
        public string Name => "Sinusoidalne";

        public double[] GetInterference(double frequency, double time)
        {
            var values = new List<double>();
            for (double i = 0; i < time; i+=frequency)
            {
                values.Add(Math.Sin(i));
            }
            return values.ToArray();
        }
    }
}
