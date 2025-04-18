﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="RoundingConverter.cs" company="dwndland">
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
        if (!(value is double number))
            return 0d;

        switch (Mode)
        {
            case RoundingMode.Round:
                return Math.Round(number);
            case RoundingMode.RoundWithDecimals:
                return Math.Round(number, DecimalPlaces, MidpointRounding);
            case RoundingMode.Ceiling:
                return Math.Ceiling(number);
            case RoundingMode.Floor:
                return Math.Floor(number);
            default:
                throw new ArgumentOutOfRangeException(nameof(Mode), Mode, "Mode got extended but not covered.");
        }
    }
}