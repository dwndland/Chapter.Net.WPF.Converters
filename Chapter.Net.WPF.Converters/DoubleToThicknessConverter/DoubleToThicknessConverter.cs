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

namespace Chapter.Net.WPF.Converters
{
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
                        throw new ArgumentOutOfRangeException(nameof(Position), Position, "Position got extended but not covered.");
                }

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

            switch (values.Length)
            {
                case 1:
                    return Create(values[0], values[0], values[0], values[0]);
                case 2:
                    return Create(values[0], values[1], values[0], values[1]);
                case 4:
                    return Create(values[0], values[1], values[2], values[3]);
                default:
                    return default(Thickness);
            }
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
            if (!(value is Thickness thickness))
                return new object[0];

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
                    throw new ArgumentOutOfRangeException(nameof(Position), Position, "Position got extended but not covered.");
            }
        }

        private static double AsDouble(object value, double fallback)
        {
            if (value is double number)
                return number;
            return fallback;
        }
    }
}