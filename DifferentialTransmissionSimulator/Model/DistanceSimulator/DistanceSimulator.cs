using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.Model.DistanceSimulator
{
    public class DistanceSimulator : IDistanceSimulator
    {
        private double _fromInterference;
        private double _betweenCables;
        private double _interferencePower;
        private double _factor;

        public DistanceSimulator(double fromInterference, double betweenCables, double interferencePower)
        {
            _fromInterference = Math.Abs(fromInterference);
            if (_fromInterference < 0.00001)
                _fromInterference = 0.001;
            _betweenCables = Math.Abs(betweenCables);
            _interferencePower = Math.Abs(interferencePower);
        }

        public IEnumerable<double> Simulate(Cable cable, IEnumerable<double> values)
        {
            if (cable == Cable.FIRST)
                _factor = _interferencePower / (_fromInterference);
            else
                _factor = _interferencePower / (_fromInterference + _betweenCables);

            List<double> result = new List<double>(values.Count());
            foreach (double value in values)
            {
                result.Add(value + value * _factor);
            }
            return result;
        }
    }
}
