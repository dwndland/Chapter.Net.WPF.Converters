// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NullToVisibilityConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Converts the null or not null value to Visibility with an optional direction parameter.
/// </summary>
[ValueConversion(typeof(object), typeof(Visibility))]
public sealed class NullToVisibilityConverter : IValueConverter
{
    /// <summary>
    ///     Defines the visibility direction to use if the value is null.
    /// </summary>
    /// <value>Default: NullToVisibilityDirection.NullIsCollapsed.</value>
    public NullToVisibilityDirection Direction { get; set; } = NullToVisibilityDirection.NullIsCollapsed;

    /// <summary>
    ///     Converts the value null or not null to <see cref="Visibility" />.
    /// </summary>
    /// <param name="value">The object value to convert.</param>
    /// <param name="targetType">unused</param>
    /// <param name="parameter">unused</param>
    /// <param name="culture">unused</param>
    /// <returns>The visibility defined by the value depending on the direction.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Direction switch
        {
            NullToVisibilityDirection.NullIsVisible => value == null ? Visibility.Visible : Visibility.Collapsed,
            NullToVisibilityDirection.NotNullIsHidden => value == null ? Visibility.Visible : Visibility.Hidden,
            NullToVisibilityDirection.NullIsCollapsed => value == null ? Visibility.Collapsed : Visibility.Visible,
            NullToVisibilityDirection.NullIsHidden => value == null ? Visibility.Hidden : Visibility.Visible,
            _ => Visibility.Collapsed
        };
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