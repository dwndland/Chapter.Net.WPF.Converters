// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NumberCheckType.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Defines what check shall be done by <see cref="NumberCheckToBooleanConverter" />.
/// </summary>
public enum NumberCheckType
{
    /// <summary>
    ///     The value shall be checked if its negative.
    /// </summary>
    IsNegative,

    /// <summary>
    ///     The value shall be checked if its maximum value.
    /// </summary>
    IsMaxValue,

    /// <summary>
    ///     The value shall be checked if its minimum value.
    /// </summary>
    IsMinValue,

    /// <summary>
    ///     The value shall be checked if its even.
    /// </summary>
    IsEven,

    /// <summary>
    ///     The value shall be checked if its odd.
    /// </summary>
    IsOdd,

    /// <summary>
    ///     The value shall be checked if its NaN.
    /// </summary>
    IsNaN,

    /// <summary>
    ///     The value shall be checked if its negative infinity.
    /// </summary>
    IsNegativeInfinity,

    /// <summary>
    ///     The value shall be checked if its positive infinity.
    /// </summary>
    IsPositiveInfinity,

    /// <summary>
    ///     The value shall be checked if its zero.
    /// </summary>
    IsZero
}