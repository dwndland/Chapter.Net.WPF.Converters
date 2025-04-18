﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NumberCheckToBooleanConverter.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Windows.Data;

#pragma warning disable CA2208
// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Executes a check on a single number or list of numbers and returns a boolean representation of that result.
/// </summary>
[ValueConversion(typeof(object), typeof(bool))]
[ValueConversion(typeof(object[]), typeof(bool))]
public class NumberCheckToBooleanConverter : SingleAndMultiValueConverter
{
    /// <summary>
    ///     Defines what check shall be done.
    /// </summary>
    /// <value>Default: NumberCheckType.IsZero.</value>
    [DefaultValue(NumberCheckType.IsZero)]
    public NumberCheckType CheckType { get; set; } = NumberCheckType.IsZero;

    /// <summary>
    ///     The return if the check is true.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool? TrueIs { get; set; } = true;

    /// <summary>
    ///     The return if the check is false.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool? FalseIs { get; set; } = false;

    /// <summary>
    ///     The return if the checks are mixed.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool? MixedIs { get; set; } = false;

    /// <summary>
    ///     Executes a check on a single number and returns a boolean representation of that result.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">CheckType got extended but not covered.</exception>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value == null ? FalseIs : Check(value);
    }

    /// <summary>
    ///     Executes a check on a list of numbers and returns a boolean representation of that result.
    /// </summary>
    /// <param name="values">The values to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">CheckType got extended but not covered.</exception>
    public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null)
            return FalseIs;

        var booleans = values.Select(Check).Distinct().ToList();
        if (booleans.Count == 0)
            return FalseIs;
        if (booleans.Count > 1)
            return MixedIs;
        return booleans[0];
    }

    private bool? Check(object value)
    {
        switch (CheckType)
        {
            case NumberCheckType.IsNegative:
                return IsNegative(value);
            case NumberCheckType.IsMaxValue:
                return IsMaxValue(value);
            case NumberCheckType.IsMinValue:
                return IsMinValue(value);
            case NumberCheckType.IsEven:
                return IsEven(value);
            case NumberCheckType.IsOdd:
                return IsOdd(value);
            case NumberCheckType.IsNaN:
                return IsNaN(value);
            case NumberCheckType.IsNegativeInfinity:
                return IsNegativeInfinity(value);
            case NumberCheckType.IsPositiveInfinity:
                return IsPositiveInfinity(value);
            case NumberCheckType.IsZero:
                return IsZero(value);
            default:
                throw new ArgumentOutOfRangeException(nameof(CheckType), CheckType, "CheckType got extended but not covered.");
        }
    }

    private bool? IsNegative(object value)
    {
        if (value is int converted1)
            return converted1 < 0 ? TrueIs : FalseIs;
        if (value is short converted3)
            return converted3 < 0 ? TrueIs : FalseIs;
        if (value is double converted4)
            return converted4 < 0 ? TrueIs : FalseIs;
        if (value is decimal converted6)
            return converted6 < 0 ? TrueIs : FalseIs;
        if (value is float converted7)
            return converted7 < 0 ? TrueIs : FalseIs;
        if (value is sbyte converted9)
            return converted9 < 0 ? TrueIs : FalseIs;
        if (value is long converted10)
            return converted10 < 0 ? TrueIs : FalseIs;
        if (value is BigInteger converted12)
            return converted12 < 0 ? TrueIs : FalseIs;
        return FalseIs;
    }

    private bool? IsMaxValue(object value)
    {
        if (value is int converted1)
            return converted1 == int.MaxValue ? TrueIs : FalseIs;
        if (value is uint converted2)
            return converted2 == uint.MaxValue ? TrueIs : FalseIs;
        if (value is short converted3)
            return converted3 == short.MaxValue ? TrueIs : FalseIs;
        if (value is double converted4)
            return Math.Abs(converted4 - double.MaxValue) == 0 ? TrueIs : FalseIs;
        if (value is byte converted5)
            return converted5 == byte.MaxValue ? TrueIs : FalseIs;
        if (value is decimal converted6)
            return converted6 == decimal.MaxValue ? TrueIs : FalseIs;
        if (value is float converted7)
            return Math.Abs(converted7 - float.MaxValue) == 0 ? TrueIs : FalseIs;
        if (value is ulong converted8)
            return converted8 == ulong.MaxValue ? TrueIs : FalseIs;
        if (value is sbyte converted9)
            return converted9 == sbyte.MaxValue ? TrueIs : FalseIs;
        if (value is long converted10)
            return converted10 == long.MaxValue ? TrueIs : FalseIs;
        if (value is ushort converted11)
            return converted11 == ushort.MaxValue ? TrueIs : FalseIs;
        return FalseIs;
    }

    private bool? IsMinValue(object value)
    {
        if (value is int converted1)
            return converted1 == int.MinValue ? TrueIs : FalseIs;
        if (value is uint converted2)
            return converted2 == uint.MinValue ? TrueIs : FalseIs;
        if (value is short converted3)
            return converted3 == short.MinValue ? TrueIs : FalseIs;
        if (value is double converted4)
            return Math.Abs(converted4 - double.MinValue) == 0 ? TrueIs : FalseIs;
        if (value is byte converted5)
            return converted5 == byte.MinValue ? TrueIs : FalseIs;
        if (value is decimal converted6)
            return converted6 == decimal.MinValue ? TrueIs : FalseIs;
        if (value is float converted7)
            return Math.Abs(converted7 - float.MinValue) == 0 ? TrueIs : FalseIs;
        if (value is ulong converted8)
            return converted8 == ulong.MinValue ? TrueIs : FalseIs;
        if (value is sbyte converted9)
            return converted9 == sbyte.MinValue ? TrueIs : FalseIs;
        if (value is long converted10)
            return converted10 == long.MinValue ? TrueIs : FalseIs;
        if (value is ushort converted11)
            return converted11 == ushort.MinValue ? TrueIs : FalseIs;
        return FalseIs;
    }

    private bool? IsEven(object value)
    {
        if (value is int converted1)
            return converted1 % 2 == 0 ? TrueIs : FalseIs;
        if (value is uint converted2)
            return converted2 % 2 == 0 ? TrueIs : FalseIs;
        if (value is short converted3)
            return converted3 % 2 == 0 ? TrueIs : FalseIs;
        if (value is double converted4)
            return converted4 % 2 == 0 ? TrueIs : FalseIs;
        if (value is byte converted5)
            return converted5 % 2 == 0 ? TrueIs : FalseIs;
        if (value is decimal converted6)
            return converted6 % 2 == 0 ? TrueIs : FalseIs;
        if (value is float converted7)
            return converted7 % 2 == 0 ? TrueIs : FalseIs;
        if (value is ulong converted8)
            return converted8 % 2 == 0 ? TrueIs : FalseIs;
        if (value is sbyte converted9)
            return converted9 % 2 == 0 ? TrueIs : FalseIs;
        if (value is long converted10)
            return converted10 % 2 == 0 ? TrueIs : FalseIs;
        if (value is ushort converted11)
            return converted11 % 2 == 0 ? TrueIs : FalseIs;
        if (value is BigInteger converted12)
            return converted12 % 2 == 0 ? TrueIs : FalseIs;
        return FalseIs;
    }

    private bool? IsOdd(object value)
    {
        if (value is int converted1)
            return converted1 % 2 != 0 ? TrueIs : FalseIs;
        if (value is uint converted2)
            return converted2 % 2 != 0 ? TrueIs : FalseIs;
        if (value is short converted3)
            return converted3 % 2 != 0 ? TrueIs : FalseIs;
        if (value is double converted4)
            return converted4 % 2 != 0 ? TrueIs : FalseIs;
        if (value is byte converted5)
            return converted5 % 2 != 0 ? TrueIs : FalseIs;
        if (value is decimal converted6)
            return converted6 % 2 != 0 ? TrueIs : FalseIs;
        if (value is float converted7)
            return converted7 % 2 != 0 ? TrueIs : FalseIs;
        if (value is ulong converted8)
            return converted8 % 2 != 0 ? TrueIs : FalseIs;
        if (value is sbyte converted9)
            return converted9 % 2 != 0 ? TrueIs : FalseIs;
        if (value is long converted10)
            return converted10 % 2 != 0 ? TrueIs : FalseIs;
        if (value is ushort converted11)
            return converted11 % 2 != 0 ? TrueIs : FalseIs;
        if (value is BigInteger converted12)
            return converted12 % 2 != 0 ? TrueIs : FalseIs;
        return FalseIs;
    }

    private bool? IsNaN(object value)
    {
        if (value is double converted1)
            return double.IsNaN(converted1) ? TrueIs : FalseIs;
        if (value is float converted2)
            return float.IsNaN(converted2) ? TrueIs : FalseIs;
        return FalseIs;
    }

    private bool? IsNegativeInfinity(object value)
    {
        if (value is double converted1)
            return double.IsNegativeInfinity(converted1) ? TrueIs : FalseIs;
        if (value is float converted2)
            return float.IsNegativeInfinity(converted2) ? TrueIs : FalseIs;
        return FalseIs;
    }

    private bool? IsPositiveInfinity(object value)
    {
        if (value is double converted1)
            return double.IsPositiveInfinity(converted1) ? TrueIs : FalseIs;
        if (value is float converted2)
            return float.IsPositiveInfinity(converted2) ? TrueIs : FalseIs;
        return FalseIs;
    }

    private bool? IsZero(object value)
    {
        if (value is int converted1)
            return converted1 == 0 ? TrueIs : FalseIs;
        if (value is uint converted2)
            return converted2 == 0 ? TrueIs : FalseIs;
        if (value is short converted3)
            return converted3 == 0 ? TrueIs : FalseIs;
        if (value is double converted4)
            return converted4 == 0 ? TrueIs : FalseIs;
        if (value is byte converted5)
            return converted5 == 0 ? TrueIs : FalseIs;
        if (value is decimal converted6)
            return converted6 == 0 ? TrueIs : FalseIs;
        if (value is float converted7)
            return converted7 == 0 ? TrueIs : FalseIs;
        if (value is ulong converted8)
            return converted8 == 0 ? TrueIs : FalseIs;
        if (value is sbyte converted9)
            return converted9 == 0 ? TrueIs : FalseIs;
        if (value is long converted10)
            return converted10 == 0 ? TrueIs : FalseIs;
        if (value is ushort converted11)
            return converted11 == 0 ? TrueIs : FalseIs;
        if (value is BigInteger converted12)
            return converted12 == 0 ? TrueIs : FalseIs;
        return FalseIs;
    }
}