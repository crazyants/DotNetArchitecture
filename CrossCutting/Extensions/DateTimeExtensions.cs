using System;
using System.Linq;

public static class DateTimeExtensions
{
	public static DateTime GetNextDayByDayOfWeek(this DateTime dateTime, params DayOfWeek[] daysOfWeek)
	{
		return Enumerable.Range(1, 7).Select(day => dateTime.AddDays(day)).First(date => daysOfWeek.Contains(date.DayOfWeek));
	}

	public static DateTime SetTime(this DateTime dateTime, string time)
	{
		if (string.IsNullOrWhiteSpace(time)) { return dateTime; }
		var parts = time.Split(':');
		if (parts.Length < 3) { return dateTime; }
		if (!int.TryParse(parts[0], out var hours)) { return dateTime; }
		if (!int.TryParse(parts[1], out var minutes)) { return dateTime; }
		if (!int.TryParse(parts[2], out var seconds)) { return dateTime; }
		return SetTime(dateTime, hours, minutes, seconds);
	}

	public static DateTime SetTime(this DateTime dateTime, int hours, int minutes, int seconds)
	{
		if (hours < 0 || hours > 23) { return dateTime; }
		if (minutes < 0 || minutes > 59) { return dateTime; }
		if (seconds < 0 || seconds > 59) { return dateTime; }
		return dateTime.Date + new TimeSpan(hours, minutes, seconds);
	}
}
