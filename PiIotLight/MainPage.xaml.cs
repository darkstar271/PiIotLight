using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PiIotLight
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    ///  windows 10 UWP APP vid Part 4 time 9:55, just working on toggle methoeds.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            InitializGpio();

        }

        private GpioPin pin1, pin2;

        void InitializGpio()
        {
            var _gpio = GpioController.GetDefault();
            if (_gpio != null)
            {
                pin1 = _gpio.OpenPin(20);
                pin2 = _gpio.OpenPin(21);

                pin1.Write(GpioPinValue.Low);
                pin2.Write(GpioPinValue.Low);

                pin1.SetDriveMode(GpioPinDriveMode.Output);
                pin2.SetDriveMode(GpioPinDriveMode.Output);

            }
            else
            {
                var msg = new MessageDialog("No Gpio found").ShowAsync();

            }

        }

        private void SwitchOne_Toggled(object sender, RoutedEventArgs e)
        {
            if (SwitchOne.IsOn)
            {
                pin1.Write(GpioPinValue.High);
            }
            else
            {
                pin1.Write(GpioPinValue.Low);
            }
        }

        private void switchTwo_Toggled(object sender, RoutedEventArgs e)
        {
            if (SwitchTwo.IsOn)
            {
                pin2.Write(GpioPinValue.High);

            }
            else
            {
                pin2.Write(GpioPinValue.Low);
            }
        }

    }
}
