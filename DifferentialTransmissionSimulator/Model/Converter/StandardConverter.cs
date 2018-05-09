using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.Converter
{
    class StandardConverter : IConverter
    {
        public IEnumerable<double> FromAnalog(int numberOfResulBits, IEnumerable<double> signal)
        {
            if (signal.Count() < numberOfResulBits)
                throw new ArgumentException("Metoda FromAnalog w StandardConverter - niezgodna ilość danych");

            int chunk = signal.Count() / numberOfResulBits;

            List<double> result = new List<double>();

            for (int i = 0; i < numberOfResulBits; i++)
            {
                result.Add(signal.ElementAt(i * chunk));
            }

            return result;
        }
    }
}
