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
    public class DataToSendViewModel : ViewModelBase
    {
        private string _dataToSend;
        public string DataToSend
        {
            get { return _dataToSend; }
            set
            {
                _dataToSend = value;
                NumberCode = _dataToSend.ToIntString();
                RaisePropertyChanged(nameof(DataToSend));
            }
        }
        private string _numberCode;
        public string NumberCode
        {
            get { return _numberCode; }
            set { _numberCode = "U+" + value; RaisePropertyChanged(nameof(NumberCode)); }
        }

        public DataToSendViewModel()
        {
            DataToSend = String.Empty;
        }
    }
}
