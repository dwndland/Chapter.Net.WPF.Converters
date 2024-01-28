// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleMathConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

#pragma warning disable CA2208
// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Does a simple calculation with the given value as double.
/// </summary>
[ValueConversion(typeof(double), typeof(double))]
public class DoubleMathConverter : ValueConverter
{
    /// <summary>
    ///     Defines what calculation shall be executed.
    /// </summary>
    /// <value>Default: Calculation.Addition.</value>
    [DefaultValue(Calculation.Addition)]
    public Calculation Calculation { get; set; } = Calculation.Addition;

    /// <summary>
    ///     The variable to calculate with.
    /// </summary>
    /// <value>Default: 1d.</value>
    [DefaultValue(1d)]
    public double Variable { get; set; } = 1d;

    /// <summary>
    ///     Defines the direction of the calculation. False means (Value * Variable). True means (Variable * Value);
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool Backwards { get; set; } = false;

    /// <summary>
    ///     Does a simple calculation with the given value as double.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Calculation got extended but not covered.</exception>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value == null ? 0d : Calculate(System.Convert.ToDouble(value));
    }

    /// <summary>
    ///     Does the backward simple calculation with the given value as double.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Calculation got extended but not covered.</exception>
    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value == null ? 0d : CalculateOpposite(System.Convert.ToDouble(value));
    }

    private double Calculate(double input)
    {
        if (Backwards)
            return Calculation switch
            {
                Calculation.Addition => Variable + input,
                Calculation.Subtraction => Variable - input,
                Calculation.Multiplication => Variable * input,
                Calculation.Division => Variable / input,
                _ => throw new ArgumentOutOfRangeException(nameof(Calculation), Calculation, "Calculation got extended but not covered.")
            };

        return Calculation switch
        {
            Calculation.Addition => input + Variable,
            Calculation.Subtraction => input - Variable,
            Calculation.Multiplication => input * Variable,
            Calculation.Division => input / Variable,
            _ => throw new ArgumentOutOfRangeException(nameof(Calculation), Calculation, "Calculation got extended but not covered.")
        };
    }

    private double CalculateOpposite(double input)
    {
        if (Backwards)
            return Calculation switch
            {
                Calculation.Addition => Variable - input,
                Calculation.Subtraction => Variable + input,
                Calculation.Multiplication => Variable / input,
                Calculation.Division => Variable * input,
                _ => throw new ArgumentOutOfRangeException(nameof(Calculation), Calculation, "Calculation got extended but not covered.")
            };

        return Calculation switch
        {
            Calculation.Addition => input - Variable,
            Calculation.Subtraction => input + Variable,
            Calculation.Multiplication => input / Variable,
            Calculation.Division => input * Variable,
            _ => throw new ArgumentOutOfRangeException(nameof(Calculation), Calculation, "Calculation got extended but not covered.")
        };
    }
}