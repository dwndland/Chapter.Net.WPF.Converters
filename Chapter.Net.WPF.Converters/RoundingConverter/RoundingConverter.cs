// -----------------------------------------------------------------------------------------------------------------
// <copyright file="RoundingConverter.cs" company="my-libraries">
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
///     Rounds the given value as double.
/// </summary>
[ValueConversion(typeof(double), typeof(double))]
public class RoundingConverter : ValueConverter
{
    /// <summary>
    ///     Gets or sets the rounding mode.
    /// </summary>
    /// <value>Default: RoundingMode.Round.</value>
    [DefaultValue(RoundingMode.Round)]
    public RoundingMode Mode { get; set; } = RoundingMode.Round;

    /// <summary>
    ///     Gets or sets the mathematical rounding method.
    /// </summary>
    /// <value>Default: MidpointRounding.ToEven.</value>
    [DefaultValue(MidpointRounding.ToEven)]
    public MidpointRounding MidpointRounding { get; set; } = MidpointRounding.ToEven;

    /// <summary>
    ///     Gets or sets the decimal places to round to if RoundingMode.RoundWithDecimals is used.
    /// </summary>
    /// <value>Default: 2.</value>
    [DefaultValue(2)]
    public int DecimalPlaces { get; set; } = 2;

    /// <summary>
    ///     Rounds the given value as double.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Mode got extended but not covered.</exception>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not double number)
            return 0d;

        return Mode switch
        {
            RoundingMode.Round => Math.Round(number),
            RoundingMode.RoundWithDecimals => Math.Round(number, DecimalPlaces, MidpointRounding),
            RoundingMode.Ceiling => Math.Ceiling(number),
            RoundingMode.Floor => Math.Floor(number),
            _ => throw new ArgumentOutOfRangeException(nameof(Mode), Mode, "Mode got extended but not covered.")
        };
    }
}