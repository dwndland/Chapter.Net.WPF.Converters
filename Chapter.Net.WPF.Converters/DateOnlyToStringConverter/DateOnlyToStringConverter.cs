// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DateOnlyToStringConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Converts the given date only to a string by Format.
/// </summary>
[ValueConversion(typeof(DateOnly), typeof(string))]
public class DateOnlyToStringConverter : IValueConverter
{
    /// <summary>
    ///     Defines how the given DateOnly shall be converted.
    /// </summary>
    /// <value>Default: DateOnlyFormat.Formatter.</value>
    public DateOnlyFormat Format { get; set; } = DateOnlyFormat.Formatter;

    /// <summary>
    ///     The formatter to use if the Format is set to DateOnlyFormat.Formatter.
    /// </summary>
    /// <value>Default: "d".</value>
    public string Formatter { get; set; } = "d";

    /// <summary>
    ///     Converts the given date only to a string by <see cref="Format" />.
    /// </summary>
    /// <param name="value">The date only.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The formatted date only; otherwise string.Empty.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not DateOnly dateOnly)
            return string.Empty;

        return Format switch
        {
            DateOnlyFormat.Formatter => dateOnly.ToString(Formatter, CultureInfo.CurrentCulture),
            DateOnlyFormat.ShortDateString => dateOnly.ToShortDateString(),
            DateOnlyFormat.LongDateString => dateOnly.ToLongDateString(),
            _ => dateOnly.ToString(CultureInfo.CurrentCulture)
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
    /// <exception cref="NotImplementedException">The DateOnlyToStringConverter.ConvertBack is not implemented.</exception>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}