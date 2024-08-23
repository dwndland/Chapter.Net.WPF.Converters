// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleToStringConverter.cs" company="dwndland">
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
///     Formats a double to string.
/// </summary>
[ValueConversion(typeof(double), typeof(string))]
public class DoubleToStringConverter : ValueConverter
{
    /// <summary>
    ///     Defines how many digits the integer left from the decimal separator shall have (leading zero).
    /// </summary>
    /// <value>Default: 2.</value>
    [DefaultValue(2)]
    public int Digits { get; set; } = 2;

    /// <summary>
    ///     Defines to how many decimal places shall be used.
    /// </summary>
    /// <value>Default: 2.</value>
    [DefaultValue(2)]
    public int DecimalCount { get; set; } = 2;

    /// <summary>
    ///     Defines if the decimal places shall be round to its expected decimal count or just cut.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool RoundDecimals { get; set; } = false;

    /// <summary>
    ///     Formats a double to string.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (!(value is double converted))
            return string.Empty;

        if (RoundDecimals)
            converted = RoundToDecimalPlaces(converted);

        return FormatDouble(converted);
    }

    /// <summary>
    ///     Parses the formatted string back to double.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string number && double.TryParse(number, NumberStyles.Float, CultureInfo.CurrentCulture, out var parsed))
            return parsed;
        return 0d;
    }

    private double RoundToDecimalPlaces(double value)
    {
        var multiplier = Math.Pow(10, DecimalCount);
        return Math.Round(value * multiplier) / multiplier;
    }

    private string FormatDouble(double value)
    {
        var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        var plainString = value.ToString(CultureInfo.CurrentCulture);
        var parts = plainString.Split([separator], StringSplitOptions.RemoveEmptyEntries);
        var beforeDecimal = parts[0];
        var afterDecimal = parts.Length > 1 ? int.Parse(parts[1]) : 0;

        if (DecimalCount == 0)
            return beforeDecimal.PadLeft(Digits, '0');

        var afterDecimalString = afterDecimal.ToString();
        if (afterDecimalString.Length > DecimalCount)
            afterDecimalString = afterDecimalString.Substring(0, DecimalCount);

        return beforeDecimal.PadLeft(Digits, '0') +
               separator +
               afterDecimalString.PadRight(DecimalCount, '0');
    }
}