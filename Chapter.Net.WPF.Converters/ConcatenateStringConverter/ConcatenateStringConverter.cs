// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ConcatenateStringConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Concatenates all given values to a single string.
/// </summary>
[ValueConversion(typeof(object[]), typeof(string))]
public class ConcatenateStringConverter : IMultiValueConverter
{
    /// <summary>
    ///     Gets or sets the separator to use to concatenate the values with.
    /// </summary>
    /// <value>Default: "".</value>
    [DefaultValue("")]
    public string Separator { get; set; } = string.Empty;

    /// <summary>
    ///     Concatenates all given values to a single string.
    /// </summary>
    /// <param name="values">The values to connect.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The concatenated values as string.</returns>
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null)
            return string.Empty;

        return string.Join(Separator, values.Where(x => x != null));
    }

    /// <summary>
    ///     Not implemented.
    /// </summary>
    /// <param name="value">Unused.</param>
    /// <param name="targetTypes">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>Nothing.</returns>
    /// <exception cref="NotImplementedException">The ConcatenateStringConverter.ConvertBack is not implemented.</exception>
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}