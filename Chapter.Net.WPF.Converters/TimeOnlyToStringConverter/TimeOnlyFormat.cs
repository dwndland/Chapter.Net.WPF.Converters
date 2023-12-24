// -----------------------------------------------------------------------------------------------------------------
// <copyright file="TimeOnlyFormat.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Defines the way how the DateOnly shall be converted by <see cref="TimeOnlyToStringConverter" />.
/// </summary>
public enum TimeOnlyFormat
{
    /// <summary>
    ///     The formatter shall be used.
    /// </summary>
    Formatter,

    /// <summary>
    ///     The <see cref="TimeOnly.ToShortTimeString" /> shall be used.
    /// </summary>
    ToShortTimeString,

    /// <summary>
    ///     The <see cref="TimeOnly.ToLongTimeString" /> shall be used.
    /// </summary>
    ToLongTimeString
}