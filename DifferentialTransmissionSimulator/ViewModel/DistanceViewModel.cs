using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.ViewModel
{
    public class DistanceViewModel : ViewModelBase
    {
        private double _interferencePower;
        public double InterferencePower
        {
            get { return _interferencePower; }
            set
            {
                _interferencePower = Math.Abs(value);
                RaisePropertyChanged(nameof(InterferencePower));
                RaisePropertyChanged(nameof(Factor));
            }

        }
        private double _distanceFromInterference;
        public double DistanceFromInterference
        {
            get { return _distanceFromInterference; }
            set
            {
                _distanceFromInterference = Math.Abs(value);
                RaisePropertyChanged(nameof(DistanceFromInterference));
                RaisePropertyChanged(nameof(Factor));
            }
        }
        private double _distancBetweenCables;
        public double DistancBetweenCables
        {
            get { return _distancBetweenCables; }
            set
            {
                _distancBetweenCables = Math.Abs(value);
                RaisePropertyChanged(nameof(DistancBetweenCables));
                RaisePropertyChanged(nameof(Factor));
            }
        }
        public double Factor
        {
            get { return _interferencePower / (_distanceFromInterference + _distancBetweenCables); }
        }

        public DistanceViewModel()
        {
            DistanceFromInterference = 1.0;
            DistancBetweenCables = 0.5;
            InterferencePower = 10.0;
        }
    }
}
