// -----------------------------------------------------------------------------------------------------------------
// <copyright file="Position.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Defines for what place the given double stands for.
/// </summary>
public enum Position
{
    /// <summary>
    ///     The left value.
    /// </summary>
    Left,

    /// <summary>
    ///     The top value.
    /// </summary>
    Top,

    /// <summary>
    ///     The right value.
    /// </summary>
    Right,

    /// <summary>
    ///     The bottom value.
    /// </summary>
    Bottom,

    /// <summary>
    ///     The left and right value.
    /// </summary>
    LeftRight,

    /// <summary>
    ///     The top and bottom value.
    /// </summary>
    TopBottom,

    /// <summary>
    ///     The value for all sides.
    /// </summary>
    All
}