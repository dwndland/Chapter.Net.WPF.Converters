// -----------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterCheckType.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters
{
    /// <summary>
    ///     Defines the check to execute with the character check converters.
    /// </summary>
    public enum CharacterCheckType
    {
        /// <summary>
        ///     The character shall be checked if it is a digit.
        /// </summary>
        IsDigit,

        /// <summary>
        ///     The character shall be checked if it is a letter.
        /// </summary>
        IsLetter,

        /// <summary>
        ///     The character shall be checked if it is upper.
        /// </summary>
        IsUpper,

        /// <summary>
        ///     The character shall be checked if it is lower.
        /// </summary>
        IsLower,

        /// <summary>
        ///     The character shall be checked if it is a letter or digit.
        /// </summary>
        IsLetterOrDigit
    }
}