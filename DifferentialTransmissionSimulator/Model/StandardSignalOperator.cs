using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model
{
    class StandardSignalOperator : ISignalOperator
    {
        public IEnumerable<double> Subtract(IEnumerable<double> signal, IEnumerable<double> invertedSignal)
        {
            var result = new List<double>();

            for (int i = 0; i < signal.Count(); i++)
            {
                result.Add(
                    signal.ElementAt(i) - invertedSignal.ElementAt(i) <= 0 ? 0 : 1);
            }

            return result;
        }
        public IEnumerable<double> Add(IEnumerable<double> signal, IEnumerable<double> invertedSignal)
        {
            var result = new List<double>();

            for (int i = 0; i < signal.Count(); i++)
            {
                result.Add(
                    signal.ElementAt(i) + invertedSignal.ElementAt(i) > 1 ? 1 : 0);
            }

            return result;
        }
    }
}
