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
            set { _dataToSend = value; RaisePropertyChanged(nameof(DataToSend)); }
        }

        public ICommand TestCommand { get; }

        public DataToSendViewModel()
        {
            TestCommand = new RelayCommand(Test);
            DataToSend = "SAD";
        }
        private void Test()
        {
            ViewModelLocator locator = App.Current.FindResource("Locator") as ViewModelLocator;
            locator.BitsChart1ViewModel.Values = new LiveCharts.ChartValues<double>() { 2, 3, 3 };
        }
    }
}
