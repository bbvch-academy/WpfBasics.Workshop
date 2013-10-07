// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OccupancyToBitmapImageConverter.cs" company="bbv Software Services AG">
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

namespace MySbbInfo.Modules.TimeTableModule.Content.Connections
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    public class OccupancyToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (IsValueInvalidOrEmpty(value))
            {
                return this.ConvertToBitmapImage(Occupancy.empty_occupancy);
            }

            var occupancy = (int?)value;

            switch (occupancy.Value)
            {
                case 0:
                    return this.ConvertToBitmapImage(Occupancy.occupancy0);
                case 1:
                    return this.ConvertToBitmapImage(Occupancy.occupancy1);
                case 2:
                    return this.ConvertToBitmapImage(Occupancy.occupancy2);
                case 3:
                    return this.ConvertToBitmapImage(Occupancy.occupancy3);
            }

            return this.ConvertToBitmapImage(Occupancy.empty_occupancy);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private static bool IsValueInvalidOrEmpty(object value)
        {
            return !(value is int?) || !((int?)value).HasValue;
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