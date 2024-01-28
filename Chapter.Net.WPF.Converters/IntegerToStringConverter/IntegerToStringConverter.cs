// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IntegerToStringConverter.cs" company="my-libraries">
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
///     Formats an integer to string.
/// </summary>
[ValueConversion(typeof(int), typeof(string))]
public class IntegerToStringConverter : ValueConverter
{
    /// <summary>
    ///     Defines how many digits the integer shall be formatted to (leading zero).
    /// </summary>
    /// <value>Default: 2.</value>
    [DefaultValue(2)]
    public int Digits { get; set; } = 2;

    /// <summary>
    ///     Formats an integer to string.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is int number ? number.ToString().PadLeft(Digits, '0') : string.Empty;
    }

    /// <summary>
    ///     Parses the formatted string back to integer.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string original && int.TryParse(original, NumberStyles.Integer, CultureInfo.CurrentCulture, out var parsed))
            return parsed;
        return 0;
    }
}