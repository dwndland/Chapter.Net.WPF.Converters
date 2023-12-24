// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeToStringConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

// ReSharper disable CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Converts the given date time to a string by Format.
/// </summary>
[ValueConversion(typeof(DateTime), typeof(string))]
public class DateTimeToStringConverter : IValueConverter
{
    /// <summary>
    ///     Defines how the given DateTime shall be converted.
    /// </summary>
    /// <value>Default: DateTimeFormat.Formatter.</value>
    public DateTimeFormat Format { get; set; } = DateTimeFormat.Formatter;

    /// <summary>
    ///     The formatter to use if the Format is set to DateTimeFormat.Formatter.
    /// </summary>
    /// <value>Default: "g".</value>
    public string Formatter { get; set; } = "g";

    /// <summary>
    ///     Defines if the date time shall be converted to local time.
    /// </summary>
    /// <value>Default: false.</value>
    public bool ToLocalTime { get; set; } = false;

    /// <summary>
    ///     Defines if the date time shall be converted to universal time.
    /// </summary>
    /// <value>Default: false.</value>
    public bool ToUniversalTime { get; set; } = false;

    /// <summary>
    ///     Converts the given date time to a string by <see cref="Format" />.
    /// </summary>
    /// <param name="value">The date time.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The formatted date time; otherwise string.Empty.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not DateTime dateTime)
            return string.Empty;

        if (ToLocalTime)
            dateTime = dateTime.ToLocalTime();
        else if (ToUniversalTime)
            dateTime = dateTime.ToUniversalTime();

        return Format switch
        {
            DateTimeFormat.Formatter => dateTime.ToString(Formatter, CultureInfo.CurrentCulture),
            DateTimeFormat.ShortTimePattern => dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern, CultureInfo.CurrentCulture),
            DateTimeFormat.LongTimePattern => dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern, CultureInfo.CurrentCulture),
            DateTimeFormat.ShortDatePattern => dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern, CultureInfo.CurrentCulture),
            DateTimeFormat.LongDatePattern => dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern, CultureInfo.CurrentCulture),
            DateTimeFormat.FullDateTimePattern => dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern, CultureInfo.CurrentCulture),
            DateTimeFormat.ShortDateString => dateTime.ToShortDateString(),
            DateTimeFormat.LongDateString => dateTime.ToLongDateString(),
            DateTimeFormat.ShortTimeString => dateTime.ToShortTimeString(),
            DateTimeFormat.LongTimeString => dateTime.ToLongTimeString(),
            _ => dateTime.ToString(CultureInfo.CurrentCulture)
        };
    }

    /// <summary>
    ///     Not implemented.
    /// </summary>
    /// <param name="value">Unused.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>Nothing.</returns>
    /// <exception cref="NotImplementedException">The DateTimeToStringConverter.ConvertBack is not implemented.</exception>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}