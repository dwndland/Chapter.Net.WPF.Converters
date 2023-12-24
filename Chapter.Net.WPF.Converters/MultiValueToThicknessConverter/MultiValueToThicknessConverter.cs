// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MultiValueToThicknessConverter.cs" company="my-libraries">
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
///     Creates a new thickness object by the given values.
/// </summary>
[ValueConversion(typeof(object[]), typeof(Thickness))]
public class MultiValueToThicknessConverter : IMultiValueConverter
{
    /// <summary>
    ///     Creates a new thickness object by the given values.
    /// </summary>
    /// <param name="values">The single, double and four values to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The generated thickness object.</returns>
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null)
            return default(Thickness);

        return values.Length switch
        {
            1 => Create(values[0], values[0], values[0], values[0]),
            2 => Create(values[0], values[1], values[0], values[1]),
            4 => Create(values[0], values[1], values[2], values[3]),
            _ => default
        };
    }

    /// <summary>
    ///     Generates the array of doubles from the given thickness object.
    /// </summary>
    /// <param name="value">The thickness object to read.</param>
    /// <param name="targetTypes">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The array of double values.</returns>
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        if (value is not Thickness thickness)
            return Array.Empty<object>();

        return new object[]
        {
            thickness.Left,
            thickness.Top,
            thickness.Right,
            thickness.Bottom
        };
    }

    private Thickness Create(object left, object top, object right, object bottom)
    {
        return new Thickness(Convert(left), Convert(top), Convert(right), Convert(bottom));
    }

    private double Convert(object value)
    {
        if (value is double number)
            return number;
        return 0;
    }
}