using DifferentialTransmissionSimulator.Model.Interferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.InterferencesSimulators
{
    class InterferenceSimulator : ISimulator
    {
        private IInterference _interference;
        private ICalculator _calculator;
        private double _frequency;
        private double _time;


        public InterferenceSimulator(IInterference interference, ICalculator calculator, double frequency, double time)
        {
            _interference = interference;
            _calculator = calculator;
            _frequency = frequency;
            _time = time;
        }

        public IEnumerable<double> Interrupt(IEnumerable<double> cableBits)
        {
            int chunks = cableBits.Count();

            var interferencedData = _interference.GetInterference(_frequency, _time);
            int valuesPerChunk = interferencedData.Length / chunks;

            var splittedData = new List<List<double>>();

            for (int chunk = 0; chunk < chunks; chunk++)
            {
                var singleChunk = new List<double>();
                for (int i = 0; i < valuesPerChunk; i++)
                {
                    singleChunk.Add(interferencedData[chunk * valuesPerChunk + i]);
                }
                splittedData.Add(singleChunk);
            }

            var lastChunk = new List<double>();
            for (int j = (chunks) * valuesPerChunk; j < interferencedData.Length; j++)
            {
                lastChunk.Add(interferencedData[j]);
            }
            if (lastChunk.Count > 0)
                splittedData.Add(lastChunk);

            return _calculator.Calculate(cableBits, splittedData);
            // TODO Check last bit?
        }
    }
}
