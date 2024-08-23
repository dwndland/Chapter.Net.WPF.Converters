// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectToTypeConverter.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Returns the type of the given object.
/// </summary>
[ValueConversion(typeof(object), typeof(Type))]
public class ObjectToTypeConverter : ValueConverter
{
    /// <summary>
    ///     Returns the type of the given object.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value?.GetType();
    }
}