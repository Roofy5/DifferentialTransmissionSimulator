using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.Interferences.Decorators
{
    class PercentageDecorator : IInterferenceDecorator
    {
        private IInterference _decoratedInterference;
        private int _percentageChange;
        private Random rand;

        public string Name => "Procentowe";

        public IInterference DecoratedInterference
        {
            get => _decoratedInterference;
            set => _decoratedInterference = value;
        }
        public object Data
        {
            get => _percentageChange;
            set => _percentageChange = (int)value;
        }

        public PercentageDecorator()
        {
            rand = new Random();
        }

        public double[] GetInterference(double frequency, double time)
        {
            var value = _decoratedInterference.GetInterference(frequency, time);
            for (int i = 0; i < value.Length; i++)
            {
                value[i] = rand.Next(0, 2) == 0 ?
                    value[i] + (value[i] * _percentageChange / 100):
                    value[i] - (value[i] * _percentageChange / 100);
            }
            return value;
        }
    }
}
