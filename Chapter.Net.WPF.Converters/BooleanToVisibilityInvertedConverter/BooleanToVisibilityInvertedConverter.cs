// -----------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToVisibilityInvertedConverter.cs" company="my-libraries">
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
///     Converts true to Visible and false to Collapsed. (The opposite of BooleanToVisibilityConverter.
/// </summary>
[ValueConversion(typeof(bool), typeof(Visibility))]
public sealed class BooleanToVisibilityInvertedConverter : IValueConverter
{
    /// <summary>
    ///     Converts the value to visibility.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">unused</param>
    /// <param name="parameter">unused</param>
    /// <param name="culture">unused</param>
    /// <returns><see cref="Visibility.Collapsed" /> if the value is true; otherwise <see cref="Visibility.Visible" />.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var bValue = false;
        if (value is bool tmp1)
            bValue = tmp1;

        return bValue ? Visibility.Collapsed : Visibility.Visible;
    }

    /// <summary>
    ///     Converts the value back to bool.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">unused</param>
    /// <param name="parameter">unused</param>
    /// <param name="culture">unused</param>
    /// <returns>True if the value is <see cref="Visibility.Collapsed" />; otherwise false.</returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Visibility visibility)
            return visibility == Visibility.Collapsed;
        return false;
    }
}