// -----------------------------------------------------------------------------------------------------------------
// <copyright file="CountToVisibilityConverter.cs" company="my-libraries">
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
///     Converts a count to its visibility representation.
/// </summary>
[ValueConversion(typeof(int), typeof(Visibility))]
public class CountToVisibilityConverter : IValueConverter
{
    /// <summary>
    ///     Defines what to return if the count is on zero.
    /// </summary>
    /// <value>:Default: Visibility.Visible.</value>
    public Visibility IsEmpty { get; set; } = Visibility.Visible;

    /// <summary>
    ///     Defines what to return if the count is not on zero.
    /// </summary>
    /// <value>:Default: Visibility.Collapsed.</value>
    public Visibility IsNotEmpty { get; set; } = Visibility.Collapsed;

    /// <summary>
    ///     Converts a count to its visibility representation.
    /// </summary>
    /// <param name="value">The count value.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The visibility representation.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not int count)
            return IsNotEmpty;
        return count == 0 ? IsEmpty : IsNotEmpty;
    }

    /// <summary>
    ///     ConvertBack is not implemented.
    /// </summary>
    /// <param name="value">Unused.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>Nothing.</returns>
    /// <exception cref="NotImplementedException">The CountToVisibilityConverter.ConvertBack is not implemented.</exception>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}