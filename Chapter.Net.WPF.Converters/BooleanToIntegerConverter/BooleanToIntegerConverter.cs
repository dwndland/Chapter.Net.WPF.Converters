// -----------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToIntegerConverter.cs" company="dwndland">
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
///     Converts a single boolean or a list of booleans to an integer representation.
/// </summary>
[ValueConversion(typeof(bool), typeof(int))]
[ValueConversion(typeof(bool[]), typeof(int))]
public class BooleanToIntegerConverter : SingleAndMultiValueConverter
{
    /// <summary>
    ///     The return to use if the booleans are mixed.
    /// </summary>
    /// <value>Default: 0.</value>
    [DefaultValue(0)]
    public int MixedIs { get; set; } = 0;

    /// <summary>
    ///     Converts a single boolean to an integer representation.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolean)
            return System.Convert.ToInt32(boolean);
        return System.Convert.ToInt32(true);
    }

    /// <summary>
    ///     Converts a list of booleans to an integer representation.
    /// </summary>
    /// <param name="values">The values to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null)
            return 0;

        var booleans = values.OfType<bool>().Distinct().ToList();
        if (booleans.Count == 0)
            return 0;
        if (booleans.Count > 1)
            return MixedIs;
        return System.Convert.ToInt32(booleans[0]);
    }

    /// <summary>
    ///     Converts a single integer back to it boolean representation.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int integer)
            return System.Convert.ToBoolean(integer);
        return true;
    }
}