using DifferentialTransmissionSimulator.Model;
using DifferentialTransmissionSimulator.Model.BitsTranslator;
using DifferentialTransmissionSimulator.Model.Interferences;
using DifferentialTransmissionSimulator.Model.InterferencesSimulators;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        private ViewModelLocator _locator;
        public ICommand StartCommand { get; }

        public MainViewModel()
        {
            _locator = App.Current.FindResource("Locator") as ViewModelLocator;
            StartCommand = new RelayCommand(Start);
        }

        protected void Start()
        {
            GetTheData();
            string data = _locator.DataToSendViewModel.DataToSend;
            var tranlsatedData = _translator.ToBits(data[0].ToString());

            IList<double> bits = new List<double>();
            foreach (var bit in tranlsatedData)
                bits.Add(bit);
            bits.Add(bits.Last());

            IList<double> bitsInverted = InvertBits(tranlsatedData);// new List<double>();
            /*foreach (var bit in tranlsatedData)
                bitsInverted.Add(bit == 0 ? 1 : 0);
            bitsInverted.Add(bitsInverted.Last());*/

            var interferenceFrequency = _locator.InterferenceViewModel.Frequency;
            var interferenceTime = _locator.InterferenceViewModel.Time;
            var interferences = _interference.GetInterference(interferenceFrequency, interferenceTime);

            _locator.BitsChart1ViewModel.Values.Clear();
            _locator.BitsChart1ViewModel.Values.AddRange(bits);
            _locator.BitsChart2ViewModel.Values.Clear();
            _locator.BitsChart2ViewModel.Values.AddRange(bitsInverted);

            _locator.InterferenceChartViewModel.Values.Clear();
            _locator.InterferenceChartViewModel.Values.AddRange(interferences);

            _locator.BitsChartOut1ViewModel.Values.Clear();
            _locator.BitsChartOut1ViewModel.Values.AddRange(_interferenceSimulator.Interrupt(bits));
            _locator.BitsChartOut2ViewModel.Values.Clear();
            _locator.BitsChartOut2ViewModel.Values.AddRange(_interferenceSimulator.Interrupt(bitsInverted));

            _locator.OutputChartViewModel.Values.Clear();
            _locator.OutputChartViewModel.Values.AddRange(_signalOperator.Add(
                _locator.BitsChartOut1ViewModel.Values,
                InvertBits(_locator.BitsChartOut2ViewModel.Values)));
        }
        private void GetTheData()
        {
            _translator = new Utf8Translator();
            _interference = _locator.InterferenceViewModel.SelectedInterference;
            _interferenceCalculator = new SumCalculator(-0.5, 0.5);
            _interferenceSimulator = new InterferenceSimulator(_interference,
                _interferenceCalculator,
                _locator.InterferenceViewModel.Frequency, //TODO change this to Dependency Injection?
                _locator.InterferenceViewModel.Time);
            _signalOperator = new StandardSignalOperator();
        }
        private IList<double> InvertBits(int[] bits)
        {
            IList<double> bitsInverted = new List<double>();
            foreach (var bit in bits)
                bitsInverted.Add(bit == 0 ? 1 : 0);
            bitsInverted.Add(bitsInverted.Last());
            return bitsInverted;
        }
        private IList<double> InvertBits(IEnumerable<double> bits)
        {
            IList<double> bitsInverted = new List<double>();
            foreach (var bit in bits)
                bitsInverted.Add(bit <= 1e-9 ? 1 : 0);
            bitsInverted.Add(bitsInverted.Last());
            return bitsInverted;
        }
    }
}