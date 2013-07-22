using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpTimeAgo
{
    public static class TimeAgo
    {
        private const string _SECOND = "{0} second ago";
        private const string _SECONDS = "{0} seconds ago";

        private const string _MINUTE_ALMOST = "almost a minute ago";
        private const string _MINUTE = "{0} minute ago";        
        private const string _MINUTES = "{0} minutes ago";

        private const string _HOUR_ALMOST = "almost an hour ago";
        private const string _HOUR = "{0} hour ago";        
        private const string _HOURS = "{0} hours ago";

        //private const string _YESTERDAY = "yesterday";
        private const string _DAY_ALMOST = "almost a day ago";
        private const string _DAY = "{0} day ago";
        private const string _DAYS = "{0} days ago";

        private const string _WEEK_ALMOST = "almost a week ago";
        private const string _WEEK = "{0} week ago";        
        private const string _WEEKS = "{0} weeks ago";

        private const string _MONTH = "{0} month ago";
        private const string _MONTH_ALMOST = "almost a month ago";
        private const string _MONTHS = "{0} months ago";

        private const string _YEAR_ALMOST = "almost {0} year ago";
        private const string _YEARS_ALMOST = "almost {0} years ago";
        private const string _YEAR = "{0} year ago";
        private const string _YEARS = "{0} years ago";



        public static string GetTimeAgo(DateTime dateTime, bool isUtc)
        {
            var now = isUtc ? DateTime.UtcNow : DateTime.Now;
            return GetTimeAgo(now.Subtract(dateTime));
        }

        public static string GetTimeAgo(TimeSpan timeSpan)
        {
            string date = "";
            if (timeSpan.TotalSeconds < 45)
            {
                date = Pluralize(timeSpan.Seconds, _SECOND, _SECONDS);
            }
            else if (timeSpan.TotalMinutes < 1)
            {
                date = _MINUTE_ALMOST;
            }
            else if (timeSpan.TotalMinutes < 45)
            {
                date = Pluralize(timeSpan.Minutes, _MINUTE, _MINUTES);
            }
            else if (timeSpan.TotalHours < 1)
            {
                date = _HOUR_ALMOST;
            }
            else if (timeSpan.TotalDays < 1)
            {
                //if (when.IsYesterday())
                //{
                //    if (timeSpan.TotalHours < 12)
                //    {
                //        date = Pluralize(timeSpan.Hours, _HOUR, _HOURS);
                //    }
                //    else
                //    {
                //        date = _YESTERDAY;
                //    }
                //}
                //else 
                if (timeSpan.TotalHours < 18)
                {
                    date = Pluralize(timeSpan.Hours, _HOUR, _HOURS);
                }
                else
                {
                    date = _DAY_ALMOST;
                }                
            }
            else
            {
                double days = timeSpan.TotalDays;
                if (days < 6)
                {
                    date = Pluralize(timeSpan.Days, _DAY, _DAYS);
                }
                else if (days < 7)
                {
                    date = _WEEK_ALMOST;
                }
                else if (days < 28)
                {
                    int weeks = (int)(timeSpan.Days / 7);
                    date = Pluralize(weeks, _WEEK, _WEEKS);
                }
                else if (days < 31)
                {
                    date = _MONTH_ALMOST;
                }
                else if (days < 292)
                {
                    int months = (int)(days / 30);
                    date = Pluralize(months, _MONTH, _MONTHS);
                }
                //else if (days < 365)
                //{
                //    date = _YEAR_ALMOST;
                //}
                else
                {
                    double years = timeSpan.Days / 365.0f;
                    int y = (int)years;
                    double delta = Math.Ceiling(years) - years;
                    if (delta < .20)
                    {
                        date = Pluralize(y+1, _YEAR_ALMOST, _YEARS_ALMOST);
                    }
                    else
                    {
                        date = Pluralize(y, _YEAR, _YEARS);
                    }
                }
            }

            return date;
        }

        private static string Pluralize(int number, string singular, string plural) 
        {
            return number == 1 ? String.Format(singular, number) : String.Format(plural, number);
        }
    }
}
