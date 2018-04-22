using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.Interferences.Decorators
{
    class NonDecorator : IInterferenceDecorator
    {
        private object _data;
        public object Data
        {
            get => _data;
            set => _data = value;
        }

        private IInterference _decoratedInterference;
        public IInterference DecoratedInterference
        {
            get => _decoratedInterference;
            set => _decoratedInterference = value;
        }

        public string Name => "Brak";

        public double[] GetInterference(double frequency, double time)
        {
            return _decoratedInterference.GetInterference(frequency, time);
        }
    }
}
