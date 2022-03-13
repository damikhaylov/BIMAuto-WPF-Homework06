using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task1
{
    internal class WeatherControl:DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        public enum PrecipitationType
        {
            Sunny = 0,
            Cloudy = 1,
            Raining = 2,
            Snowing = 3
        }
        private PrecipitationType precipitation;
        private int temperature = 0;
        private string windDiraction = "";

        public int Temperature
        {
            get => (int) GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public string WindDirection
        {
            get => windDiraction;
            set => windDiraction = value;
        }

        public PrecipitationType Precipitation
        {
            get => precipitation;
            set => precipitation = value;
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int temp = (int) baseValue;
            if (temp > 50)
            {
                return 50;
            }
            else if (temp < -50)
            {
                return -50;
            }
            else
            {
                return temp;
            }
        }

        private static bool ValidateTemperature(object value)
        {
            int temp = (int)value;
            return (temp >= -50 && temp <= 50);
        }
    }
}
