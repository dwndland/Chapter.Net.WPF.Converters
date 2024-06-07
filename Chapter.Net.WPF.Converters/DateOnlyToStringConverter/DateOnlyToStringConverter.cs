// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DateOnlyToStringConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Formats a single DateOnly to a string.
/// </summary>
[ValueConversion(typeof(DateOnly), typeof(string))]
public class DateOnlyToStringConverter : ValueConverter
{
    /// <summary>
    ///     Defines how the given DateOnly shall be converted.
    /// </summary>
    /// <value>Default: DateOnlyFormat.Formatter.</value>
    [DefaultValue(DateOnlyFormat.Formatter)]
    public DateOnlyFormat Format { get; set; } = DateOnlyFormat.Formatter;

    /// <summary>
    ///     The formatter to use if the Format is set to DateOnlyFormat.Formatter.
    /// </summary>
    /// <value>Default: "d".</value>
    [DefaultValue("d")]
    public string Formatter { get; set; } = "d";

    /// <summary>
    ///     Formats a single DateOnly to a string.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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
}