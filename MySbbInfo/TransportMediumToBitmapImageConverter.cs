// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransportMediumToBitmapImageConverter.cs" company="bbv Software Services AG">
//   Copyright (c) 2012
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// <summary>
//   Defines the OccupancyToImageSourceConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    public class TransportMediumToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is string))
            {
                return this.ConvertToBitmapImage(TransportMedium.empty_transportation);
            }

            var transportMediumDescription = (string)value;

            if (string.IsNullOrWhiteSpace(transportMediumDescription))
            {
                return this.ConvertToBitmapImage(TransportMedium.walk);
            }

            if (transportMediumDescription.StartsWith("i", StringComparison.OrdinalIgnoreCase) ||
                transportMediumDescription.StartsWith("s", StringComparison.OrdinalIgnoreCase) ||
                transportMediumDescription.StartsWith("r", StringComparison.OrdinalIgnoreCase))
            {
                return this.ConvertToBitmapImage(TransportMedium.train);
            }

            if (transportMediumDescription.StartsWith("bus", StringComparison.OrdinalIgnoreCase))
            {
                return this.ConvertToBitmapImage(TransportMedium.bus);
            }

            if (transportMediumDescription.StartsWith("tram", StringComparison.OrdinalIgnoreCase))
            {
                return this.ConvertToBitmapImage(TransportMedium.tram);
            }
            
            return this.ConvertToBitmapImage(TransportMedium.empty_transportation);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private BitmapImage ConvertToBitmapImage(Image bitmap)
        {
            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Jpeg);

                ms.Seek(0, SeekOrigin.Begin);

                var bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.EndInit();

                return bi;
            }
        }
    }
}