using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.Converter
{
    class AverageConverter : IConverter
    {
        private double _lowerMargin;
        private double _upperMargin;

        public AverageConverter(double lowerMargin, double upperMargin)
        {
            _lowerMargin = lowerMargin;
            _upperMargin = upperMargin;
        }

        public IEnumerable<double> FromAnalog(int numberOfResulBits, IEnumerable<double> signal)
        {
            if (signal.Count() < numberOfResulBits)
                throw new ArgumentException("Metoda FromAnalog w StandardConverter - niezgodna ilość danych");

            int chunk = signal.Count() / numberOfResulBits;

            List<double> result = new List<double>();

            for (int i = 0; i < numberOfResulBits; i++)
            {
                double sum = 0;
                for (int j = i * chunk; j < (i + 1) * chunk; j++)
                {
                    sum += signal.ElementAt(j);
                }

                double value = sum / chunk;
                double resValue = value < _lowerMargin ? 0 : 1;

                result.Add(resValue);
            }

            return result;
        }
    }
}
