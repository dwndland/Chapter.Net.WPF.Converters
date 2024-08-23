// -----------------------------------------------------------------------------------------------------------------
// <copyright file="StringToLowerConverter.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Converts the given value as string to lower.
/// </summary>
[ValueConversion(typeof(string), typeof(string))]
public class StringToLowerConverter : ValueConverter
{
    /// <summary>
    ///     Converts the given value as string to lower.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value == null ? string.Empty : value.ToString()!.ToLower();
    }
}