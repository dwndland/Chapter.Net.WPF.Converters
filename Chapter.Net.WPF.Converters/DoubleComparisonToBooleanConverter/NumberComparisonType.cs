// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NumberComparisonType.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Defines how the integer or double comparison converters shall compare.
/// </summary>
public enum NumberComparisonType
{
    /// <summary>
    ///     Checks if the given value is bigger than the variable.
    /// </summary>
    BiggerThan,

    /// <summary>
    ///     Checks if the given value is smaller than the variable.
    /// </summary>
    SmallerThan
}