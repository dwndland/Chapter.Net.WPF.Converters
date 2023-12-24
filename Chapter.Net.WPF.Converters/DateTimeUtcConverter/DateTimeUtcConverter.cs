// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeUtcConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Converts the given date time to universal or local time.
/// </summary>
[ValueConversion(typeof(DateTime), typeof(DateTime))]
public class DateTimeUtcConverter : IValueConverter
{
    /// <summary>
    ///     Defines if the value shall be converted to universal time. If false its to local time.
    /// </summary>
    /// <value>Default: false.</value>
    public bool ToUniversalTime { get; set; } = false;

    /// <summary>
    ///     Converts the given date time to UTC or local time.
    /// </summary>
    /// <param name="value">The date and time to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted date and time.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DateTime dateTime)
            return ToUniversalTime ? dateTime.ToUniversalTime() : dateTime.ToLocalTime();
        return default(DateTime);
    }

    /// <summary>
    ///     Converts the given date time to UTC or local time.
    /// </summary>
    /// <param name="value">The date and time to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted date and time.</returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DateTime dateTime)
            return ToUniversalTime ? dateTime.ToLocalTime() : dateTime.ToUniversalTime();
        return default(DateTime);
    }
}