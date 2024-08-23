// -----------------------------------------------------------------------------------------------------------------
// <copyright file="EqualsToVisibilityConverter.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Compares a single value to a variable or a list of values to each other and returns its Visibility representation.
/// </summary>
[ValueConversion(typeof(object), typeof(Visibility))]
[ValueConversion(typeof(object[]), typeof(Visibility))]
public class EqualsToVisibilityConverter : SingleAndMultiValueConverter
{
    /// <summary>
    ///     The return if equals is true.
    /// </summary>
    /// <value>Default: Visibility.Visible.</value>
    [DefaultValue(Visibility.Visible)]
    public Visibility IsEqual { get; set; } = Visibility.Visible;

    /// <summary>
    ///     The return if equals is false.
    /// </summary>
    /// <value>Default: Visibility.Collapsed.</value>
    [DefaultValue(Visibility.Collapsed)]
    public Visibility IsNotEqual { get; set; } = Visibility.Collapsed;

    /// <summary>
    ///     The value to compare with.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object CompareWith { get; set; } = null;

    /// <summary>
    ///     Compares a single value to a variable and returns its Visibility representation.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Equals(value, CompareWith) ? IsEqual : IsNotEqual;
    }

    /// <summary>
    ///     Compares a list of values to each other and returns its Visibility representation.
    /// </summary>
    /// <param name="values">The values to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null)
            return IsNotEqual;

        if (values.Length == 0)
            return IsNotEqual;

        var allEqual = values.All(o => Equals(o, values[0]));
        return allEqual ? IsEqual : IsNotEqual;
    }
}