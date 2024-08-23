// -----------------------------------------------------------------------------------------------------------------
// <copyright file="SingleAndMultiValueConverter.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     The base class for all converter which are IValueConverter and IMultiValueConverter together.
/// </summary>
public abstract class SingleAndMultiValueConverter : IValueConverter, IMultiValueConverter
{
    /// <inheritdoc />
    public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

    /// <summary>
    ///     ConvertBack is not implemented.
    /// </summary>
    /// <param name="value">Unused.</param>
    /// <param name="targetTypes">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>Nothing.</returns>
    /// <exception cref="NotImplementedException">The ConvertBack is not implemented.</exception>
    public virtual object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

    /// <summary>
    ///     ConvertBack is not implemented.
    /// </summary>
    /// <param name="value">Unused.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>Nothing.</returns>
    /// <exception cref="NotImplementedException">The ConvertBack is not implemented.</exception>
    public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}