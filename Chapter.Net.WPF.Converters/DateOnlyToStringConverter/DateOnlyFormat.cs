// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DateOnlyFormat.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

#if NET6_0_OR_GREATER
using System;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters
{
    /// <summary>
    ///     Defines the way how the DateOnly shall be converted by <see cref="DateOnlyToStringConverter" />.
    /// </summary>
    public enum DateOnlyFormat
    {
        /// <summary>
        ///     The formatter shall be used.
        /// </summary>
        Formatter,

        /// <summary>
        ///     The <see cref="DateOnly.ToShortDateString" /> shall be used.
        /// </summary>
        ShortDateString,

        /// <summary>
        ///     The <see cref="DateOnly.ToLongDateString" /> shall be used.
        /// </summary>
        LongDateString
    }
}
#endif