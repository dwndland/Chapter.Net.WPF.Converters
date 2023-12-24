// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NullToBooleanConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Converts the null or not null value to bool with an optional direction parameter.
/// </summary>
[ValueConversion(typeof(object), typeof(bool))]
public sealed class NullToBooleanConverter : IValueConverter
{
    /// <summary>
    ///     Defines the direction how null shall be interpreted.
    /// </summary>
    /// <value>Default: NullToBooleanDirection.NullIsFalse.</value>
    public NullToBooleanDirection Direction { get; set; } = NullToBooleanDirection.NullIsFalse;

    /// <summary>
    ///     Converts the value null or not null to true or false.
    /// </summary>
    /// <param name="value">The object value to convert.</param>
    /// <param name="targetType">unused</param>
    /// <param name="parameter">unused</param>
    /// <param name="culture">unused</param>
    /// <returns>If NullIsFalse false is returned if the value is null; otherwise opposite.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return Direction != NullToBooleanDirection.NullIsFalse;

        return Direction == NullToBooleanDirection.NullIsFalse;
    }

    /// <summary>
    ///     Not Implemented.
    /// </summary>
    /// <param name="value">unused</param>
    /// <param name="targetType">unused</param>
    /// <param name="parameter">unused</param>
    /// <param name="culture">unused</param>
    /// <returns>Not implemented.</returns>
    /// <exception cref="NotImplementedException">The <see cref="ConvertBack" /> is not implemented.</exception>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}