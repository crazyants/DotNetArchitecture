using System;
using System.Linq;

public static class TimeSpanExtensions
{
	public static string Format(this TimeSpan timeSpan)
	{
		var days = timeSpan.Days > 0 ? $"{timeSpan.Days}d" : string.Empty;
		var hours = timeSpan.Hours > 0 ? $"{timeSpan.Hours}h" : string.Empty;
		var minutes = timeSpan.Minutes > 0 ? $"{timeSpan.Minutes}m" : string.Empty;
		var seconds = timeSpan.Seconds > 0 ? $"{timeSpan.Seconds}s" : string.Empty;
		return $"{days} {hours} {minutes} {seconds}".Trim();
	}

	public static TimeSpan GetNextHour(this TimeSpan timeSpan, params TimeSpan[] timesSpan)
	{
		return timesSpan.Where(x => x.Hours > timeSpan.Hours).OrderBy(x => x.Hours).FirstOrDefault();
	}
}