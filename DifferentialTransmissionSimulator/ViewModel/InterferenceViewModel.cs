using DifferentialTransmissionSimulator.Model.Interferences;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.ViewModel
{
    public class InterferenceViewModel : ViewModelBase
    {
        private IEnumerable<IInterference> _interferences;
        public IEnumerable<IInterference> Interferences
        {
            get { return _interferences; }
            set { _interferences = value; RaisePropertyChanged(nameof(Interferences)); }
        }
        private IInterference _selectedInterference;
        public IInterference SelectedInterference
        {
            get { return _selectedInterference; }
            set { _selectedInterference = value; RaisePropertyChanged(nameof(SelectedInterference)); }
        }
        private double _frequency;
        public double Frequency
        {
            get { return _frequency; }
            set { _frequency = value; }
        }
        private double _time;
        public double Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public InterferenceViewModel()
        {
            Interferences= new List<IInterference>()
            {
                new SinusInterference()
            };
            SelectedInterference = Interferences.First();
            Frequency = 1;
            Time = 10;
        }
    }
}
