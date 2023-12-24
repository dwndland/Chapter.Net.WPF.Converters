// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeFormat.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Defines the way how the DateTime shall be converted by <see cref="DateTimeToStringConverter" />.
/// </summary>
public enum DateTimeFormat
{
    /// <summary>
    ///     The formatter shall be used.
    /// </summary>
    Formatter,

    /// <summary>
    ///     The <see cref="DateTimeFormatInfo.ShortTimePattern" /> of the <see cref="CultureInfo.CurrentCulture" /> shall be
    ///     used.
    /// </summary>
    ShortTimePattern,

    /// <summary>
    ///     The <see cref="DateTimeFormatInfo.LongTimePattern" /> of the <see cref="CultureInfo.CurrentCulture" /> shall be
    ///     used.
    /// </summary>
    LongTimePattern,

    /// <summary>
    ///     The <see cref="DateTimeFormatInfo.ShortDatePattern" /> of the <see cref="CultureInfo.CurrentCulture" /> shall be
    ///     used.
    /// </summary>
    ShortDatePattern,

    /// <summary>
    ///     The <see cref="DateTimeFormatInfo.LongDatePattern" /> of the <see cref="CultureInfo.CurrentCulture" /> shall be
    ///     used.
    /// </summary>
    LongDatePattern,

    /// <summary>
    ///     The <see cref="DateTimeFormatInfo.FullDateTimePattern" /> of the <see cref="CultureInfo.CurrentCulture" /> shall be
    ///     used.
    /// </summary>
    FullDateTimePattern,

    /// <summary>
    ///     The <see cref="DateTime.ToShortDateString" /> shall be used.
    /// </summary>
    ShortDateString,

    /// <summary>
    ///     The <see cref="DateTime.ToLongDateString" /> shall be used.
    /// </summary>
    LongDateString,

    /// <summary>
    ///     The <see cref="DateTime.ToShortTimeString" /> shall be used.
    /// </summary>
    ShortTimeString,

    /// <summary>
    ///     The <see cref="DateTime.ToLongTimeString" /> shall be used.
    /// </summary>
    LongTimeString
}