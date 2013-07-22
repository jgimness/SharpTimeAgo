using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpTimeAgo
{
    public static class DateExtensions
    {
        /// <summary>
        /// Returns a verbal "time ago" representation of the date
        /// </summary>
        public static string GetTimeAgo(this DateTime dateTime, bool isUtc)
        {
            return TimeAgo.GetTimeAgo(dateTime, isUtc);
        }

        /// <summary>
        /// Returns a verbal "time ago" representation of the date
        /// </summary>
        public static string GetTimeAgo(this TimeSpan timeSpan)
        {
            return TimeAgo.GetTimeAgo(timeSpan);
        }

        /// <summary>
        /// Returns whether the Date portion represents today
        /// </summary>
        public static bool IsToday(this DateTime dateTime)
        {
            return DateTime.Today == dateTime.Date;
        }

        /// <summary>
        /// Returns whether the Data portion represents yesterday
        /// </summary>
        public static bool IsYesterday(this DateTime dateTime)
        {
            return DateTime.Today.AddDays(-1) == dateTime.Date;
        }

        /// <summary>
        /// Returns whether the Data portion represents tomorrow
        /// </summary>
        public static bool IsTomorrow(this DateTime dateTime)
        {
            return DateTime.Today.AddDays(1) == dateTime.Date;
        }

    }
}
