// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IntegerMathConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

#pragma warning disable CA2208
// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters
{
    /// <summary>
    ///     Does a simple calculation with the given value as integer.
    /// </summary>
    [ValueConversion(typeof(int), typeof(int))]
    public class IntegerMathConverter : ValueConverter
    {
        /// <summary>
        ///     Gets or sets what operation shall be executed.
        /// </summary>
        /// <value>Default: Calculation.Addition.</value>
        [DefaultValue(Calculation.Addition)]
        public Calculation Calculation { get; set; } = Calculation.Addition;

        /// <summary>
        ///     Gets or sets the variable to calculate with.
        /// </summary>
        /// <value>Default: 1.</value>
        [DefaultValue(1)]
        public int Variable { get; set; } = 1;

        /// <summary>
        ///     Defines the direction of the calculation. False means (Value * Variable). True means (Variable * Value);
        /// </summary>
        /// <value>Default: false.</value>
        [DefaultValue(false)]
        public bool Backwards { get; set; } = false;

        /// <summary>
        ///     Does a simple calculation with the given value as integer.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">Unused.</param>
        /// <param name="parameter">Unused.</param>
        /// <param name="culture">Unused.</param>
        /// <returns>The converted value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Calculation got extended but not covered.</exception>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? 0 : Calculate(System.Convert.ToInt32(value));
        }

        /// <summary>
        ///     Does the backward simple calculation with the given value as integer.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">Unused.</param>
        /// <param name="parameter">Unused.</param>
        /// <param name="culture">Unused.</param>
        /// <returns>The converted value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Calculation got extended but not covered.</exception>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? 0 : CalculateOpposite(System.Convert.ToInt32(value));
        }

        private int Calculate(int input)
        {
            if (Backwards)
                switch (Calculation)
                {
                    case Calculation.Addition:
                        return Variable + input;
                    case Calculation.Subtraction:
                        return Variable - input;
                    case Calculation.Multiplication:
                        return Variable * input;
                    case Calculation.Division:
                        return Variable / input;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Calculation), Calculation, "Calculation got extended but not covered.");
                }

            switch (Calculation)
            {
                case Calculation.Addition:
                    return input + Variable;
                case Calculation.Subtraction:
                    return input - Variable;
                case Calculation.Multiplication:
                    return input * Variable;
                case Calculation.Division:
                    return input / Variable;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Calculation), Calculation, "Calculation got extended but not covered.");
            }
        }

        private int CalculateOpposite(int input)
        {
            if (Backwards)
                switch (Calculation)
                {
                    case Calculation.Addition:
                        return Variable - input;
                    case Calculation.Subtraction:
                        return Variable + input;
                    case Calculation.Multiplication:
                        return Variable / input;
                    case Calculation.Division:
                        return Variable * input;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Calculation), Calculation, "Calculation got extended but not covered.");
                }

            switch (Calculation)
            {
                case Calculation.Addition:
                    return input - Variable;
                case Calculation.Subtraction:
                    return input + Variable;
                case Calculation.Multiplication:
                    return input / Variable;
                case Calculation.Division:
                    return input * Variable;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Calculation), Calculation, "Calculation got extended but not covered.");
            }
        }
    }
}