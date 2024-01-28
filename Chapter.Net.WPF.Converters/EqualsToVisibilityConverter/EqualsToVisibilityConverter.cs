// -----------------------------------------------------------------------------------------------------------------
// <copyright file="EqualsToVisibilityConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Equals two values and returns its visibility representation.
/// </summary>
[ValueConversion(typeof(object), typeof(Visibility), ParameterType = typeof(object))]
public class EqualsToVisibilityConverter : SingleAndMultiValueConverter
{
    /// <summary>
    ///     The visibility to return if equals is true.
    /// </summary>
    /// <value>Default: Visibility.Visible.</value>
    public Visibility IsEqual { get; set; } = Visibility.Visible;

    /// <summary>
    ///     The visibility to return if equals is false.
    /// </summary>
    /// <value>Default: Visibility.Collapsed.</value>
    public Visibility IsNotEqual { get; set; } = Visibility.Collapsed;

    /// <summary>
    ///     Equals two values and returns its visibility representation.
    /// </summary>
    /// <param name="value">The first value.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">The second value.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The visibility representation of the equals comparison.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Equals(value, parameter) ? IsEqual : IsNotEqual;
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