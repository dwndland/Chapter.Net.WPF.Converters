// -----------------------------------------------------------------------------------------------------------------
// <copyright file="Calculation.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters
{
    /// <summary>
    ///     Defines what calculation shall be done within <see cref="IntegerMathConverter" /> and
    ///     <see cref="DoubleMathConverter" />.
    /// </summary>
    public enum Calculation
    {
        /// <summary>
        ///     The property shall be added to the value.
        /// </summary>
        Addition,

        /// <summary>
        ///     The property shall be subtracted from the value.
        /// </summary>
        Subtraction,

        /// <summary>
        ///     The property shall be multiplied with the value.
        /// </summary>
        Multiplication,

        /// <summary>
        ///     The property shall be divided from the value.
        /// </summary>
        Division
    }
}