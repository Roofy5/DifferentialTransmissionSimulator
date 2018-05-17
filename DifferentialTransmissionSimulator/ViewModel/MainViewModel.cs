using DifferentialTransmissionSimulator.Model;
using DifferentialTransmissionSimulator.Model.BitsTranslator;
using DifferentialTransmissionSimulator.Model.Converter;
using DifferentialTransmissionSimulator.Model.DistanceSimulator;
using DifferentialTransmissionSimulator.Model.Interferences;
using DifferentialTransmissionSimulator.Model.InterferencesSimulators;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DifferentialTransmissionSimulator.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ITranslator _translator;
        private IInterference _interference;
        private ISimulator _interferenceSimulator;
        private ICalculator _interferenceCalculator;
        private ISignalOperator _signalOperator;
        private IConverter _signalConverter;
        private IDistanceSimulator _distanceSimulator;
        private ViewModelLocator _locator;
        private bool _simulateTime;
        public bool SimulateTime
        {
            get { return _simulateTime; }
            set { _simulateTime = value; RaisePropertyChanged(nameof(SimulateTime)); }
        }
        public ICommand StartCommand { get; }
        public ICommand StartTimeCommand { get; }
        public ICommand StopTimeCommand { get; }

        public MainViewModel()
        {
            _simulateTime = false;
            _locator = App.Current.FindResource("Locator") as ViewModelLocator;
            StartCommand = new RelayCommand(Start);
            StartTimeCommand = new RelayCommand(TimeSimulatorStart);
            StopTimeCommand = new RelayCommand(TimeSimulatorStop);
        }

        protected async void TimeSimulatorStart()
        {
            SimulateTime = true;
            while (_simulateTime)
            {
                await Task.Factory.StartNew(() =>
                {
                    System.Threading.Thread.Sleep(500);
                    Send();
                });
            }
        }
        protected void TimeSimulatorStop()
        {
            SimulateTime = false;
        }
        protected async void Start()
        {
            if (_locator.TimeViewModel.IsEnabled)
            {
                await Task.Factory.StartNew(() => {
                    for (int i = 0; i < _locator.TimeViewModel.NumberOfRepeats; i++)
                    {
                            Send();
                    }
                });
            }
            else
                Send();
        }
        protected void Send()
        {
            GetTheData();
            string data = _locator.DataToSendViewModel.DataToSend;
            if (String.IsNullOrEmpty(data))
                return;
            var tranlsatedData = _translator.ToBits(data[0].ToString());

            IList<double> bits = new List<double>();
            foreach (var bit in tranlsatedData)
                bits.Add(bit);
            //bits.Add(bits.Last());

            IList<double> bitsInverted = InvertBits(tranlsatedData);

            var interferenceFrequency = _locator.InterferenceViewModel.Frequency;
            var interferenceTime = _locator.InterferenceViewModel.Time;
            var interferences = _interference.GetInterference(interferenceFrequency, interferenceTime);

            ClearCharts();

            _locator.BitsChart1ViewModel.Values.AddRange(bits);
            _locator.BitsChart2ViewModel.Values.AddRange(bitsInverted);
            _locator.InterferenceChartViewModel.Values.AddRange(interferences);
            _locator.BitsChartOut1ViewModel.Values.AddRange(
                _distanceSimulator.Simulate(Cable.FIRST, _interferenceSimulator.Interrupt(bits)));
            _locator.BitsChartOut2ViewModel.Values.AddRange(
                _distanceSimulator.Simulate(Cable.SECOND, _interferenceSimulator.Interrupt(bitsInverted)));
            _locator.OutputChartViewModel.Values.AddRange(
                _signalConverter.FromAnalog(bits.Count,
                    _signalOperator.Add(
                    _locator.BitsChartOut1ViewModel.Values,
                    InvertBits(_locator.BitsChartOut2ViewModel.Values))));

            _locator.OutputViewModel.OutData = _translator.FromBits(_locator.OutputChartViewModel.Values.ToIntArray());

            if (_locator.OutputViewModel.OutData.Equals(_locator.DataToSendViewModel.DataToSend))
                _locator.OutputViewModel.SuccessCount++;
            else
                _locator.OutputViewModel.FailCount++;
        }
        private void GetTheData()
        {
            _translator = new Utf8Translator();
            _interference = _locator.InterferenceViewModel.SelectedInterferenceChanger;
            _interferenceCalculator = new AnalogSumCalculator();//new SumCalculator(-0.8, 0.8);
            _interferenceSimulator = new InterferenceSimulator(
                _interference,
                _interferenceCalculator,
                _locator.InterferenceViewModel.Frequency, //TODO change this to Dependency Injection?
                _locator.InterferenceViewModel.Time);
            _distanceSimulator = new DistanceSimulator(
                _locator.DistanceViewModel.DistanceFromInterference,
                _locator.DistanceViewModel.DistancBetweenCables,
                _locator.DistanceViewModel.InterferencePower);
            _signalOperator = new StandardSignalOperator();
            //_signalConverter = new StandardConverter();
            _signalConverter = new AverageConverter(0.5, 0.5);
        }
        private void ClearCharts()
        {
            _locator.BitsChart1ViewModel.Values.Clear();
            _locator.BitsChart2ViewModel.Values.Clear();
            _locator.InterferenceChartViewModel.Values.Clear();
            _locator.BitsChartOut1ViewModel.Values.Clear();
            _locator.BitsChartOut2ViewModel.Values.Clear();
            _locator.OutputChartViewModel.Values.Clear();
        }
        private IList<double> InvertBits(int[] bits)
        {
            IList<double> bitsInverted = new List<double>();
            foreach (var bit in bits)
                bitsInverted.Add(bit == 0 ? 1 : 0);
            //bitsInverted.Add(bitsInverted.Last());
            return bitsInverted;
        }
        private IList<double> InvertBits(IEnumerable<double> bits)
        {
            IList<double> bitsInverted = new List<double>();
            foreach (var bit in bits)
                bitsInverted.Add(bit <= 1e-9 ? 1 : 0);
            //bitsInverted.Add(bitsInverted.Last());
            return bitsInverted;
        }
    }
}