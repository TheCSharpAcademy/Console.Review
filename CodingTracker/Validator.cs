﻿using System.Globalization;
namespace CodingTracker;

internal static class Validator
{
    public static bool IsValidFilterOption(string? input)
    {
        string[] validOptions = { "a", "d", "w", "m", "y" };
        foreach (string validOption in validOptions)
        {
            if (input == validOption)
            {
                return true;
            }
        }
        return false;
    }

    public static bool IsValidOption(string? input)
    {
        string[] validOptions = { "v", "a", "d", "u", "srt", "stp", "0" };
        foreach (string validOption in validOptions)
        {
            if (input == validOption)
            {
                return true;
            }
        }
        return false;
    }

    public static bool IsValidDateInput(string input) => DateTime.TryParseExact(input, "dd-MM-yy HH-mm-ss", new CultureInfo("en-US"), DateTimeStyles.None, out _);

    public static DateTime ConvertToDate(string time) => DateTime.ParseExact(time, "dd-MM-yy HH-mm-ss", new CultureInfo("en-US"), DateTimeStyles.None);

    public static string ConvertFromDate(DateTime time) => time.ToString(@"dd-MM-yy HH-mm-ss");

    public static TimeSpan CalculateDuration(string startTimeStr, string endTimeStr)
    {
        DateTime startTime = ConvertToDate(startTimeStr);
        DateTime endTime = ConvertToDate(endTimeStr);
        return endTime.Subtract(startTime);
    }
}