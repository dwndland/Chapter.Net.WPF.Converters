// -----------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToIntegerConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Converts an boolean to its integer representation and back.
/// </summary>
[ValueConversion(typeof(bool), typeof(int))]
public class BooleanToIntegerConverter : IValueConverter
{
    /// <summary>
    ///     Converts a boolean to its integer representation.
    /// </summary>
    /// <param name="value">The boolean to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted integer value.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolean)
            return System.Convert.ToInt32(boolean);
        return System.Convert.ToInt32(true);
    }

    /// <summary>
    ///     Converts an integer to its boolean representation.
    /// </summary>
    /// <param name="value">The integer to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted boolean value.</returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int integer)
            return System.Convert.ToBoolean(integer);
        return true;
    }
}