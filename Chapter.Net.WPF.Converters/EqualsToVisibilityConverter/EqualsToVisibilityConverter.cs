// -----------------------------------------------------------------------------------------------------------------
// <copyright file="EqualsToVisibilityConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Compares a single value to a variable or a list of values to each other and returns its Visibility representation.
/// </summary>
[ValueConversion(typeof(object), typeof(Visibility))]
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
    ///     ConvertBack is not implemented.
    /// </summary>
    /// <param name="value">Unused.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>Nothing.</returns>
    /// <exception cref="NotImplementedException">The EqualsToVisibilityConverter.ConvertBack is not implemented.</exception>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}