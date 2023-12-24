// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MultiValueToPathConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Combines all given strings into a path.
/// </summary>
[ValueConversion(typeof(string[]), typeof(string))]
public class MultiValueToPathConverter : IMultiValueConverter
{
    /// <summary>
    ///     Combines all given strings into a path.
    /// </summary>
    /// <param name="values">The parts to combine.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The assembled path.</returns>
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null)
            return string.Empty;

        var sections = values.Where(x => x != null).Select(x => x.ToString()).ToArray();
        return Path.Combine(sections);
    }

    /// <summary>
    ///     Not implemented.
    /// </summary>
    /// <param name="value">Unused.</param>
    /// <param name="targetTypes">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>Nothing.</returns>
    /// <exception cref="NotImplementedException">The TimeOnlyToStringConverter.ConvertBack is not implemented.</exception>
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}