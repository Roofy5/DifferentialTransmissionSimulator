using GalaSoft.MvvmLight;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentialTransmissionSimulator.ViewModel
{
    public class BitsChartViewModel : ViewModelBase
    {
        protected ChartValues<double> _values;
        public ChartValues<double> Values
        {
            get { return _values; }
            set { _values = value; RaisePropertyChanged(nameof(Values)); }
        }

        public BitsChartViewModel()
        {
            Values = new ChartValues<double>();
        }
    }

    public class BitsChart1ViewModel : BitsChartViewModel
    { }
    public class BitsChart2ViewModel : BitsChartViewModel
    { }
    public class BitsChartOut1ViewModel : BitsChartViewModel
    { }
    public class BitsChartOut2ViewModel : BitsChartViewModel
    { }
    public class InterferenceChartViewModel : BitsChartViewModel
    { }
    public class OutputChartViewModel : BitsChartViewModel
    { }
}
