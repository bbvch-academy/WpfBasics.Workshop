namespace SbbApi
{
    using System;
    using System.Globalization;

    using ServiceStack.Text;

    public static class SerializationExtensions
    {
        public static void RegisterAdditionalSerializers()
        {
            JsConfig<DateTime?>.SerializeFn = SerializeNullableDateTime;
            JsConfig<DateTime?>.DeSerializeFn = DeserializeNullableDateTime;
            JsConfig<TimeSpan?>.SerializeFn = SerializeNullableTimeSpan;
            JsConfig<TimeSpan?>.DeSerializeFn = DeserializeNullableTimeSpan;
        }

        private static DateTime? DeserializeNullableDateTime(string s)
        {
            DateTime res;
            if (DateTime.TryParseExact(
                s, "yyyy-MM-ddTHH:mm:sszzzz", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out res))
            {
                return res;
            }

            return null;
        }

        private static string SerializeNullableDateTime(DateTime? c)
        {
            if (c.HasValue)
            {
                return String.Format("{0:yyyy-MM-ddTHH:mm:sszzzz}", c);
            }

            return String.Empty;
        }

        private static TimeSpan? DeserializeNullableTimeSpan(string s)
        {
            // 00d01:00:00
            TimeSpan res;
            if (TimeSpan.TryParseExact(
                s, @"d\dhh\:mm\:ss", CultureInfo.InvariantCulture, TimeSpanStyles.None, out res))
            {
                return res;
            }

            return null;
        }

        private static string SerializeNullableTimeSpan(TimeSpan? c)
        {
            if (c.HasValue)
            {
                return String.Format("{0:[d]'d'hh’:’mm’:’ss}", c);
            }

            return String.Empty;
        }
    }
}