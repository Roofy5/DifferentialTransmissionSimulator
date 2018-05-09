using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.InterferencesSimulators
{
    class AnalogSumCalculator : ICalculator
    {
        public AnalogSumCalculator()
        {
        }

        public IEnumerable<double> Calculate(IEnumerable<double> cableBits, IEnumerable<IEnumerable<double>> interferencedData)
        {
            List<double> result = new List<double>();
            List<double> interference = new List<double>();

            foreach (var item in interferencedData)
                foreach (var subItem in item)
                    interference.Add(subItem);

            int chunkSize = interferencedData.ElementAt(0).Count() / cableBits.Count();

            for (int i = 0; i < interferencedData.Count() && i < cableBits.Count(); i++)
            {
                for (int j = 0; j < interferencedData.ElementAt(i).Count(); j++)
                {
                    result.Add(cableBits.ElementAt(i) + interferencedData.ElementAt(i).ElementAt(j));
                }
            }

            return result;
        }
    }
}
