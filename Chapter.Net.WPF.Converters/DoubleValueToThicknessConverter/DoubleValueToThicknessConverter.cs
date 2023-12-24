// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleValueToThicknessConverter.cs" company="my-libraries">
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
///     Converts a value to a thickness by telling for what that value it.
/// </summary>
[ValueConversion(typeof(double), typeof(Thickness))]
public class DoubleValueToThicknessConverter : IValueConverter
{
    /// <summary>
    ///     Defines for what place the given double stands for.
    /// </summary>
    /// <value>Default: Position.All.</value>
    public Position Position { get; set; } = Position.All;

    /// <summary>
    ///     Converts a value to a thickness by telling for what that value it.
    /// </summary>
    /// <param name="value">The double value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted thickness object.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not double number)
            return default(Thickness);

        return Create(number);
    }

    /// <summary>
    ///     Returns a particular thickness value.
    /// </summary>
    /// <param name="value">The thickness value to read.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The read double value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Position got extended but converter did not cover all new cases.</exception>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Thickness thickness)
            switch (Position)
            {
                case Position.All:
                case Position.Left:
                case Position.LeftRight:
                    return thickness.Left;
                case Position.Top:
                case Position.TopBottom:
                    return thickness.Top;
                case Position.Right:
                    return thickness.Right;
                case Position.Bottom:
                    return thickness.Bottom;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        return 0;
    }

    private Thickness Create(double number)
    {
        switch (Position)
        {
            case Position.Left:
                return new Thickness(number, 0, 0, 0);
            case Position.Top:
                return new Thickness(0, number, 0, 0);
            case Position.Right:
                return new Thickness(0, 0, number, 0);
            case Position.Bottom:
                return new Thickness(0, 0, 0, number);
            case Position.All:
                return new Thickness(number);
            case Position.LeftRight:
                return new Thickness(number, 0, number, 0);
            case Position.TopBottom:
                return new Thickness(0, number, 0, number);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}