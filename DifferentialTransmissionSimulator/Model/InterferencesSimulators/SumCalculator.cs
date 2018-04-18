using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.InterferencesSimulators
{
    class SumCalculator : ICalculator
    {
        private double _lowerMargin;
        private double _upperMargin;
        public SumCalculator(double lowerMargin, double upperMargin)
        {
            _lowerMargin = lowerMargin;
            _upperMargin = upperMargin;
        }

        public IEnumerable<double> Calculate(IEnumerable<double> cableBits, IEnumerable<IEnumerable<double>> interferencedData)
        {
            List<double> result = new List<double>();
            for (int bit = 0; bit < cableBits.Count(); bit++)
            {
                double sumOfValues = 0.0;
                foreach (double value in interferencedData.ElementAt(bit))
                {
                    sumOfValues += value;
                }
                if (sumOfValues >= _upperMargin)
                    result.Add(1.0);
                else if (sumOfValues <= _lowerMargin)
                    result.Add(0.0);
                else
                    result.Add(cableBits.ElementAt(bit));
            }
            return result;
        }
    }
}
