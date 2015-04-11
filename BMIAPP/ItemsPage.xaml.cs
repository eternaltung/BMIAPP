using BMIAPP.Data;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.DataTransfer;

namespace BMIAPP
{
    public sealed partial class ItemsPage : BMIAPP.Common.LayoutAwarePage
    {
        DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
        public ItemsPage()
        {
            this.InitializeComponent();
            this.Loaded += ItemsPage_Loaded;
            dataTransferManager.DataRequested += dataTransferManager_DataRequested;
        }

        void dataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            args.Request.Data.Properties.Title = "BMI";
            args.Request.Data.SetText("這是一個計算BMI的APP");
        }

        void ItemsPage_Loaded(object sender, RoutedEventArgs e)
        {
            AgeTextBox.TextChanged += AgeTextBox_TextChanged;
            WeightTextBox.TextChanged += AgeTextBox_TextChanged;
            HeightTextBox.TextChanged += AgeTextBox_TextChanged;
            GenderSwitch.Toggled += GenderSwitch_Toggled;
            
        }

        void GenderSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            CalculatorBMI();
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        void CalculatorBMI()
        {
            if (AgeTextBox.Text.Trim() == string.Empty || WeightTextBox.Text.Trim() == string.Empty ||
                HeightTextBox.Text.Trim() == string.Empty)
            {
                return;
            }
            int a;
            double b;
            if (!int.TryParse(AgeTextBox.Text, out a) || !double.TryParse(WeightTextBox.Text, out b) ||
                !double.TryParse(HeightTextBox.Text, out b))
            {
                return;
            }
            double idealbmi_low, idealbmi_high = 0;
            double weight = double.Parse(WeightTextBox.Text);
            double height = double.Parse(HeightTextBox.Text) / 100;
            if (!GenderSwitch.IsOn)
            {   //男生
                switch (AgeTextBox.Text.Trim())
                {
                    case "2":
                        idealbmi_low = 15.2 * height * height;
                        idealbmi_high = 17.7 * height * height;
                        break;
                    case "3":
                        idealbmi_low = 14.8 * height * height;
                        idealbmi_high = 17.7 * height * height;
                        break;
                    case "4":
                        idealbmi_low = 14.4 * height * height;
                        idealbmi_high = 17.7 * height * height;
                        break;
                    case "5":
                        idealbmi_low = 14 * height * height;
                        idealbmi_high = 17.7 * height * height;
                        break;
                    case "6":
                        idealbmi_low = 13.9 * height * height;
                        idealbmi_high = 17.9 * height * height;
                        break;
                    case "7":
                        idealbmi_low = 14.7 * height * height;
                        idealbmi_high = 18.6 * height * height;
                        break;
                    case "8":
                        idealbmi_low = 15 * height * height;
                        idealbmi_high = 19.3 * height * height;
                        break;
                    case "9":
                        idealbmi_low = 15.2 * height * height;
                        idealbmi_high = 20.3 * height * height;
                        break;
                    case "10":
                        idealbmi_low = 15.4 * height * height;
                        idealbmi_high = 20.3 * height * height;
                        break;
                    case "11":
                        idealbmi_low = 15.8 * height * height;
                        idealbmi_high = 21 * height * height;
                        break;
                    case "12":
                        idealbmi_low = 16.4 * height * height;
                        idealbmi_high = 21.5 * height * height;
                        break;
                    case "13":
                        idealbmi_low = 17 * height * height;
                        idealbmi_high = 22.2 * height * height;
                        break;
                    case "14":
                        idealbmi_low = 17.6 * height * height;
                        idealbmi_high = 22.7 * height * height;
                        break;
                    case "15":
                        idealbmi_low = 18.2 * height * height;
                        idealbmi_high = 23.1 * height * height;
                        break;
                    case "16":
                        idealbmi_low = 18.6 * height * height;
                        idealbmi_high = 23.4 * height * height;
                        break;
                    case "17":
                        idealbmi_low = 19 * height * height;
                        idealbmi_high = 23.6 * height * height;
                        break;
                    case "18":
                        idealbmi_low = 19.2 * height * height;
                        idealbmi_high = 23.7 * height * height;
                        break;
                    default:
                        idealbmi_low = 18.5 * height * height;
                        idealbmi_high = 25 * height * height;
                        break;
                }
            }
            else
            {       //女生
                switch (AgeTextBox.Text.Trim())
                {
                    case "2":
                        idealbmi_low = 14.9 * height * height;
                        idealbmi_high = 17.3 * height * height;
                        break;
                    case "3":
                        idealbmi_low = 14.5 * height * height;
                        idealbmi_high = 17.2 * height * height;
                        break;
                    case "4":
                        idealbmi_low = 14.2 * height * height;
                        idealbmi_high = 17.1 * height * height;
                        break;
                    case "5":
                        idealbmi_low = 13.9 * height * height;
                        idealbmi_high = 17.1 * height * height;
                        break;
                    case "6":
                        idealbmi_low = 13.6 * height * height;
                        idealbmi_high = 17.2 * height * height;
                        break;
                    case "7":
                        idealbmi_low = 14.4 * height * height;
                        idealbmi_high = 18 * height * height;
                        break;
                    case "8":
                        idealbmi_low = 14.6 * height * height;
                        idealbmi_high = 18.8 * height * height;
                        break;
                    case "9":
                        idealbmi_low = 14.9 * height * height;
                        idealbmi_high = 19.3 * height * height;
                        break;
                    case "10":
                        idealbmi_low = 15.2 * height * height;
                        idealbmi_high = 20.1 * height * height;
                        break;
                    case "11":
                        idealbmi_low = 15.8 * height * height;
                        idealbmi_high = 20.9 * height * height;
                        break;
                    case "12":
                        idealbmi_low = 16.4 * height * height;
                        idealbmi_high = 21.6 * height * height;
                        break;
                    case "13":
                        idealbmi_low = 17 * height * height;
                        idealbmi_high = 22.2 * height * height;
                        break;
                    case "14":
                        idealbmi_low = 17.6 * height * height;
                        idealbmi_high = 22.7 * height * height;
                        break;
                    case "15":
                        idealbmi_low = 18 * height * height;
                        idealbmi_high = 22.7 * height * height;
                        break;
                    case "16":
                        idealbmi_low = 18 * height * height;
                        idealbmi_high = 22.7 * height * height;
                        break;
                    case "17":
                        idealbmi_low = 18.3 * height * height;
                        idealbmi_high = 22.7 * height * height;
                        break;
                    case "18":
                        idealbmi_low = 18.3 * height * height;
                        idealbmi_high = 22.7 * height * height;
                        break;
                    default:
                        idealbmi_low = 18.5 * height * height;
                        idealbmi_high = 25 * height * height;
                        break;
                }
            }
            double bmi = Math.Round(weight / Math.Pow(height, 2),2);
            BMIText.Text = bmi.ToString();

            //移動bar指標
            double left = 770 * (bmi - 10) / 32;
            if (left < 0)
                left = 0;
            else if (left > 740)
                left = 740;
            BarImage.SetValue(Canvas.LeftProperty, left);

            idealbmi_low = Math.Round(idealbmi_low, 2);
            idealbmi_high = Math.Round(idealbmi_high, 2);
            IdealBMIText.Text = idealbmi_low + "~" + idealbmi_high;
        }
                
        private void AgeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculatorBMI();
        }
    }
}
