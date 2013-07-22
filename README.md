#SharpTimeAgo - Short sentence for relative time difference



This is a small library to help you show relative time differences in a sentence form.  It currently supports seconds, minutes, hours, days, months, and years.

For example, calling it with a Date of June 22 would give you 
"__almost a month ago__"

    string timeAgo = SharpTimeAgo.GetTimeAgo(myDate, isUtc);

There is also a DateExtensions class which adds several utility methods to System.DateTime	 