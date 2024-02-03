// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleToThicknessConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

#pragma warning disable CA2208
// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Builds a Thickness object by a given single double value.
/// </summary>
[ValueConversion(typeof(double), typeof(Thickness))]
[ValueConversion(typeof(double[]), typeof(Thickness))]
public class DoubleToThicknessConverter : SingleAndMultiValueConverter
{
    /// <summary>
    ///     Defines for what place the given double stands for.
    /// </summary>
    /// <value>Default: Position.All.</value>
    [DefaultValue(Position.All)]
    public Position Position { get; set; } = Position.All;

    /// <summary>
    ///     Builds a Thickness object by a given single double value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Position got extended but not covered.</exception>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is double number ? Create(number) : default;
    }

    /// <summary>
    ///     Reads a part of the given Thickness object and returns its double.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Position got extended but not covered.</exception>
    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Thickness thickness)
            return Position switch
            {
                Position.All => thickness.Left,
                Position.Left => thickness.Left,
                Position.LeftRight => thickness.Left,
                Position.Top => thickness.Top,
                Position.TopBottom => thickness.Top,
                Position.Right => thickness.Right,
                Position.Bottom => thickness.Bottom,
                _ => throw new ArgumentOutOfRangeException(nameof(Position), Position, "Position got extended but not covered.")
            };

        return 0;
    }

    /// <summary>
    ///     Builds a Thickness object by a list of double values.
    /// </summary>
    /// <param name="values">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
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
    ///     Reads the parts of the given Thickness object and returns list of doubles.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetTypes">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
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

    private static Thickness Create(object left, object top, object right, object bottom)
    {
        return new Thickness(AsDouble(left, 0), AsDouble(top, 0), AsDouble(right, 0), AsDouble(bottom, 0));
    }

    private Thickness Create(double number)
    {
        return Position switch
        {
            Position.Left => new Thickness(number, 0, 0, 0),
            Position.Top => new Thickness(0, number, 0, 0),
            Position.Right => new Thickness(0, 0, number, 0),
            Position.Bottom => new Thickness(0, 0, 0, number),
            Position.All => new Thickness(number),
            Position.LeftRight => new Thickness(number, 0, number, 0),
            Position.TopBottom => new Thickness(0, number, 0, number),
            _ => throw new ArgumentOutOfRangeException(nameof(Position), Position, "Position got extended but not covered.")
        };
    }

    private static double AsDouble(object value, double fallback)
    {
        if (value is double number)
            return number;
        return fallback;
    }
}