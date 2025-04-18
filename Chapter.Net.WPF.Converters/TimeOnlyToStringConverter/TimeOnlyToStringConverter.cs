﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="TimeOnlyToStringConverter.cs" company="dwndland">
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
///     Formats a single TimeOnly to a string.
/// </summary>
[ValueConversion(typeof(TimeOnly), typeof(string))]
public class TimeOnlyToStringConverter : ValueConverter
{
    /// <summary>
    ///     Defines how the given TimeOnly shall be converted.
    /// </summary>
    /// <value>Default: TimeOnlyFormat.Formatter.</value>
    [DefaultValue(TimeOnlyFormat.Formatter)]
    public TimeOnlyFormat Format { get; set; } = TimeOnlyFormat.Formatter;

    /// <summary>
    ///     The formatter to use if the Format is set to TimeOnlyFormat.Formatter.
    /// </summary>
    /// <value>Default: "t".</value>
    [DefaultValue("t")]
    public string Formatter { get; set; } = "t";

    /// <summary>
    ///     Formats a single TimeOnly to a string.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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
}