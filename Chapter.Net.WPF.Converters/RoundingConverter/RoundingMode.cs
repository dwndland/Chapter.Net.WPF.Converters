// -----------------------------------------------------------------------------------------------------------------
// <copyright file="RoundingMode.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters
{
    /// <summary>
    ///     Defines the rounding method for <see cref="RoundingConverter" />.
    /// </summary>
    public enum RoundingMode
    {
        /// <summary>
        ///     Math.Round(number) shall be used.
        /// </summary>
        Round,

        /// <summary>
        ///     Math.Round(number, decimals) shall be used.
        /// </summary>
        RoundWithDecimals,

        /// <summary>
        ///     Math.Ceiling(number) shall be used.
        /// </summary>
        Ceiling,

        /// <summary>
        ///     Math.Floor(number) shall be used.
        /// </summary>
        Floor
    }
}