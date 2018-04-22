/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:DifferentialTransmissionSimulator"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace DifferentialTransmissionSimulator.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<DataToSendViewModel>();
            SimpleIoc.Default.Register<InterferenceViewModel>();
            SimpleIoc.Default.Register<BitsChart1ViewModel>();
            SimpleIoc.Default.Register<BitsChart2ViewModel>();
            SimpleIoc.Default.Register<BitsChartOut1ViewModel>();
            SimpleIoc.Default.Register<BitsChartOut2ViewModel>();
            SimpleIoc.Default.Register<InterferenceChartViewModel>();
            SimpleIoc.Default.Register<OutputChartViewModel>();
            SimpleIoc.Default.Register<OutputViewModel>();
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public DataToSendViewModel DataToSendViewModel
        {
            get { return ServiceLocator.Current.GetInstance<DataToSendViewModel>(); }
        }
        public InterferenceViewModel InterferenceViewModel
        {
            get { return ServiceLocator.Current.GetInstance<InterferenceViewModel>(); }
        }
        public BitsChart1ViewModel BitsChart1ViewModel
        {
            get { return ServiceLocator.Current.GetInstance<BitsChart1ViewModel>(); }
        }
        public BitsChart2ViewModel BitsChart2ViewModel
        {
            get { return ServiceLocator.Current.GetInstance<BitsChart2ViewModel>(); }
        }
        public BitsChartOut1ViewModel BitsChartOut1ViewModel
        {
            get { return ServiceLocator.Current.GetInstance<BitsChartOut1ViewModel>(); }
        }
        public BitsChartOut2ViewModel BitsChartOut2ViewModel
        {
            get { return ServiceLocator.Current.GetInstance<BitsChartOut2ViewModel>(); }
        }
        public InterferenceChartViewModel InterferenceChartViewModel
        {
            get { return ServiceLocator.Current.GetInstance<InterferenceChartViewModel>(); }
        }
        public OutputChartViewModel OutputChartViewModel
        {
            get { return ServiceLocator.Current.GetInstance<OutputChartViewModel>(); }
        }
        public OutputViewModel OutputViewModel
        {
            get { return ServiceLocator.Current.GetInstance<OutputViewModel>(); }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}