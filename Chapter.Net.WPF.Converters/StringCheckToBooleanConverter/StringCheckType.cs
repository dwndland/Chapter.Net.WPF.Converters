// -----------------------------------------------------------------------------------------------------------------
// <copyright file="StringCheckType.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Defines the check type to execute with the string check converters.
/// </summary>
public enum StringCheckType
{
    /// <summary>
    ///     The converter shall check for null or whitespace.
    /// </summary>
    IsNullOrWhitespace,

    /// <summary>
    ///     The converter shall check for null or empty.
    /// </summary>
    IsNullOrEmpty,

    /// <summary>
    ///     The converter shall check for null.
    /// </summary>
    IsNull,

    /// <summary>
    ///     The converter shall check for empty.
    /// </summary>
    IsEmpty,

    /// <summary>
    ///     The converter shall check for whitespace.
    /// </summary>
    IsWhitespace,

    /// <summary>
    ///     The converter shall check for upper.
    /// </summary>
    IsUpper,

    /// <summary>
    ///     The converter shall check for lower.
    /// </summary>
    IsLower,

    /// <summary>
    ///     The converter shall check for if it is shorter than the variable.
    /// </summary>
    IsShorterThan,

    /// <summary>
    ///     The converter shall check for if it is shorter than or equal to the variable.
    /// </summary>
    IsShorterThanOrEqualTo,

    /// <summary>
    ///     The converter shall check for if it is longer than the variable.
    /// </summary>
    IsLongerThan,

    /// <summary>
    ///     The converter shall check for if it is longer than or equal to the variable.
    /// </summary>
    IsLongerThanOrEqualTo,

    /// <summary>
    ///     The converter shall check for if it has the exact same length as the variable.
    /// </summary>
    IsExactLength
}