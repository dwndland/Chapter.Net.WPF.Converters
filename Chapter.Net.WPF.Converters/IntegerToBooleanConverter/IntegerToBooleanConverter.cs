// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IntegerToBooleanConverter.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Converts a single integer or a list of integers to a boolean representation.
/// </summary>
[ValueConversion(typeof(int), typeof(bool))]
[ValueConversion(typeof(int[]), typeof(bool))]
public class IntegerToBooleanConverter : SingleAndMultiValueConverter
{
    /// <summary>
    ///     Defines the boolean to use if the integers are mixed.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool? MixedIs { get; set; } = false;

    /// <summary>
    ///     Converts a single integer to a boolean representation.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int integer)
            return System.Convert.ToBoolean(integer);
        return true;
    }

    /// <summary>
    ///     Converts a list of integers to a boolean representation.
    /// </summary>
    /// <param name="values">The values to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null)
            return false;

        var booleans = values.OfType<int>().Distinct().ToList();
        if (booleans.Count == 0)
            return false;
        if (booleans.Count > 1)
            return MixedIs;
        return System.Convert.ToBoolean(booleans[0]);
    }

    /// <summary>
    ///     Converts a single boolean back to it integer representation.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is bool boolean ? System.Convert.ToInt32(boolean) : System.Convert.ToInt32(true);
    }
}