// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeToStringConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

// ReSharper disable CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Formats a single DateTime to a string.
/// </summary>
[ValueConversion(typeof(DateTime), typeof(string))]
public class DateTimeToStringConverter : ValueConverter
{
    /// <summary>
    ///     Defines how the given DateTime shall be converted.
    /// </summary>
    /// <value>Default: DateTimeFormat.Formatter.</value>
    [DefaultValue(DateTimeFormat.Formatter)]
    public DateTimeFormat Format { get; set; } = DateTimeFormat.Formatter;

    /// <summary>
    ///     The formatter to use if the Format is set to DateTimeFormat.Formatter.
    /// </summary>
    /// <value>Default: "g".</value>
    [DefaultValue("g")]
    public string Formatter { get; set; } = "g";

    /// <summary>
    ///     Defines if the date time shall be converted to local time.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool ToLocalTime { get; set; } = false;

    /// <summary>
    ///     Defines if the date time shall be converted to universal time.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool ToUniversalTime { get; set; } = false;

    /// <summary>
    ///     Formats a single DateTime to a string.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (!(value is DateTime dateTime))
            return string.Empty;

        if (ToLocalTime)
            dateTime = dateTime.ToLocalTime();
        else if (ToUniversalTime)
            dateTime = dateTime.ToUniversalTime();

        switch (Format)
        {
            case DateTimeFormat.Formatter:
                return dateTime.ToString(Formatter, CultureInfo.CurrentCulture);
            case DateTimeFormat.ShortTimePattern:
                return dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern, CultureInfo.CurrentCulture);
            case DateTimeFormat.LongTimePattern:
                return dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern, CultureInfo.CurrentCulture);
            case DateTimeFormat.ShortDatePattern:
                return dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern, CultureInfo.CurrentCulture);
            case DateTimeFormat.LongDatePattern:
                return dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern, CultureInfo.CurrentCulture);
            case DateTimeFormat.FullDateTimePattern:
                return dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern, CultureInfo.CurrentCulture);
            case DateTimeFormat.ShortDateString:
                return dateTime.ToShortDateString();
            case DateTimeFormat.LongDateString:
                return dateTime.ToLongDateString();
            case DateTimeFormat.ShortTimeString:
                return dateTime.ToShortTimeString();
            case DateTimeFormat.LongTimeString:
                return dateTime.ToLongTimeString();
            default:
                return dateTime.ToString(CultureInfo.CurrentCulture);
        }
    }
}