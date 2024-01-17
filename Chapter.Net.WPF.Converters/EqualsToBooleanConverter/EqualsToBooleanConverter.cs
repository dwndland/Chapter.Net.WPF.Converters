// -----------------------------------------------------------------------------------------------------------------
// <copyright file="EqualsToBooleanConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Equals two values and returns its result.
/// </summary>
[ValueConversion(typeof(object), typeof(bool), ParameterType = typeof(object))]
public class EqualsToBooleanConverter : IValueConverter
{
    /// <summary>
    ///     The value to return if equals is true; otherwise the opposite.
    /// </summary>
    /// <value>Default: true.</value>
    public bool IsEqual { get; set; } = true;

    /// <summary>
    ///     Equals two values and returns its result.
    /// </summary>
    /// <param name="value">The first value.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">The second value.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The boolean representation of the equals comparison.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Equals(value, parameter) ? IsEqual : !IsEqual;
    }

    /// <summary>
    ///     ConvertBack is not implemented.
    /// </summary>
    /// <param name="value">Unused.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>Nothing.</returns>
    /// <exception cref="NotImplementedException">The EqualsToBooleanConverter.ConvertBack is not implemented.</exception>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}