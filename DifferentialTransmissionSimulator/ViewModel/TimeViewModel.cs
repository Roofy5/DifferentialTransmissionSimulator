using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DifferentialTransmissionSimulator.ViewModel
{
    public class TimeViewModel : ViewModelBase
    {
        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; RaisePropertyChanged(nameof(IsEnabled)); }
        }
        private int _numberOfRepeats;
        public int NumberOfRepeats
        {
            get { return _numberOfRepeats; }
            set { _numberOfRepeats = value <= 0 ? 1 : value; RaisePropertyChanged(nameof(NumberOfRepeats)); }
        }

        public TimeViewModel()
        {
            IsEnabled = false;
            NumberOfRepeats = 1;
        }
    }
}
