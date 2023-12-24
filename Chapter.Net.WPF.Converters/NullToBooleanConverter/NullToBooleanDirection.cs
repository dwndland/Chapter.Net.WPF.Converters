// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NullToBooleanDirection.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Represents the direction to be used in the <see cref="NullToBooleanConverter" />.
/// </summary>
public enum NullToBooleanDirection
{
    /// <summary>
    ///     If the value is null, it returns true; otherwise false.
    /// </summary>
    NullIsTrue,

    /// <summary>
    ///     If the value is null, it returns false; otherwise true
    /// </summary>
    NullIsFalse
}