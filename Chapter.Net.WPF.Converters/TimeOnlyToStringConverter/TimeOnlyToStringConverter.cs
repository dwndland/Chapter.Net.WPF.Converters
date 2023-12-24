// -----------------------------------------------------------------------------------------------------------------
// <copyright file="TimeOnlyToStringConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Converts the given time only to a string by Format.
/// </summary>
[ValueConversion(typeof(TimeOnly), typeof(string))]
public class TimeOnlyToStringConverter : IValueConverter
{
    /// <summary>
    ///     Defines how the given TimeOnly shall be converted.
    /// </summary>
    /// <value>Default: TimeOnlyFormat.Formatter.</value>
    public TimeOnlyFormat Format { get; set; } = TimeOnlyFormat.Formatter;

    /// <summary>
    ///     The formatter to use if the Format is set to TimeOnlyFormat.Formatter.
    /// </summary>
    /// <value>Default: "t".</value>
    public string Formatter { get; set; } = "t";

    /// <summary>
    ///     Converts the given time only to a string by <see cref="Format" />.
    /// </summary>
    /// <param name="value">The time only.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The formatted time only; otherwise string.Empty.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not TimeOnly timeOnly)
            return string.Empty;

        return Format switch
        {
            TimeOnlyFormat.Formatter => timeOnly.ToString(Formatter, CultureInfo.CurrentCulture),
            TimeOnlyFormat.ToShortTimeString => timeOnly.ToShortTimeString(),
            TimeOnlyFormat.ToLongTimeString => timeOnly.ToLongTimeString(),
            _ => timeOnly.ToString(CultureInfo.CurrentCulture)
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
    /// <exception cref="NotImplementedException">The TimeOnlyToStringConverter.ConvertBack is not implemented.</exception>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}