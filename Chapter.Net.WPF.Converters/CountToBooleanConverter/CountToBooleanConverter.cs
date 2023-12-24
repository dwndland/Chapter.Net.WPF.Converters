// -----------------------------------------------------------------------------------------------------------------
// <copyright file="CountToBooleanConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Converts a count to its boolean representation.
/// </summary>
[ValueConversion(typeof(int), typeof(bool))]
public class CountToBooleanConverter : IValueConverter
{
    /// <summary>
    ///     Defines what to return if zero; If not zero it returns that opposite.
    /// </summary>
    /// <value>Default: true.</value>
    public bool IsEmpty { get; set; } = true;

    /// <summary>
    ///     Converts a count to its boolean representation.
    /// </summary>
    /// <param name="value">The count value.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The boolean representation.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not int count)
            return !IsEmpty;
        return count == 0 ? IsEmpty : !IsEmpty;
    }

    /// <summary>
    ///     ConvertBack is not implemented.
    /// </summary>
    /// <param name="value">Unused.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>Nothing.</returns>
    /// <exception cref="NotImplementedException">ConvertBack is not implemented.</exception>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}