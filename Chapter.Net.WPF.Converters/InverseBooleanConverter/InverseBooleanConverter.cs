// -----------------------------------------------------------------------------------------------------------------
// <copyright file="InverseBooleanConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Converts a boolean to is opposite.
/// </summary>
[ValueConversion(typeof(bool), typeof(bool))]
public sealed class InverseBooleanConverter : IValueConverter
{
    /// <summary>
    ///     Defines the value to return if it null.
    /// </summary>
    /// <value>Default: null.</value>
    public bool? NullValue { get; set; } = null;

    /// <summary>
    ///     Converts the value as boolean to its opposite.
    /// </summary>
    /// <param name="value">The value to invert.</param>
    /// <param name="targetType">unused</param>
    /// <param name="parameter">unused</param>
    /// <param name="culture">unused</param>
    /// <returns>False if the value is true; otherwise true.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value switch
        {
            null => NullValue,
            bool tmp1 => !tmp1,
            _ => true
        };
    }

    /// <summary>
    ///     Converts the value as boolean to its opposite.
    /// </summary>
    /// <param name="value">The value to invert.</param>
    /// <param name="targetType">unused</param>
    /// <param name="parameter">unused</param>
    /// <param name="culture">unused</param>
    /// <returns>False if the value is true; otherwise true.</returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Convert(value, targetType, parameter, culture);
    }
}