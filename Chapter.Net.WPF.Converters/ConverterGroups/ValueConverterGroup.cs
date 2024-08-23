// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ValueConverterGroup.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Calls one converter after another by passing the result of the previous as a value to the second.
/// </summary>
public class ValueConverterGroup : List<IValueConverter>, IValueConverter
{
    /// <summary>
    ///     Calls one converter after another by passing the result of the previous as a value to the second.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">The target type passed to all converters.</param>
    /// <param name="parameter">The parameter passed to all converters.</param>
    /// <param name="culture">The culture passed to all converters.</param>
    /// <returns>The result of the last converter.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return this.Aggregate(value, (current, converter) => converter.Convert(current, targetType, parameter, culture));
    }

    /// <summary>
    ///     ConvertBack is not implemented.
    /// </summary>
    /// <param name="value">Unused.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>Nothing.</returns>
    /// <exception cref="NotImplementedException">The ConvertBack is not implemented.</exception>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}