using DifferentialTransmissionSimulator.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DifferentialTransmissionSimulator.ViewModel
{
    public class OutputViewModel : ViewModelBase
    {
        private string _outData;
        public string OutData
        {
            get { return _outData; }
            set
            {
                _outData = value.Replace("\0", "");
                OutNumberCode = _outData.ToIntString();
                RaisePropertyChanged(nameof(OutData));
            }
        }

        private string _outNumberCode;
        public string OutNumberCode
        {
            get { return _outNumberCode; }
            set { _outNumberCode = "U+" + value; RaisePropertyChanged(nameof(OutNumberCode)); }
        }

        private int _successCount;
        public int SuccessCount
        {
            get { return _successCount; }
            set { _successCount = value; RaisePropertyChanged(nameof(SuccessCount)); }
        }

        private int _failCount;
        public int FailCount
        {
            get { return _failCount; }
            set { _failCount = value; RaisePropertyChanged(nameof(FailCount)); }
        }

        public ICommand ResetCountersCommand { get; }

        public OutputViewModel()
        {
            OutData = String.Empty;
            SuccessCount = 0;
            FailCount = 0;
            ResetCountersCommand = new RelayCommand(() => { SuccessCount = 0; FailCount = 0; });
        }
    }
}
