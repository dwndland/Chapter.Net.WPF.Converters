// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MultiEqualsToBooleanConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Equals multiple values and returns its result.
/// </summary>
[ValueConversion(typeof(object[]), typeof(bool))]
public class MultiEqualsToBooleanConverter : IMultiValueConverter
{
    /// <summary>
    ///     The value to return if all equals are true; otherwise the opposite.
    /// </summary>
    /// <value>Default: true.</value>
    public bool AreEqual { get; set; } = true;

    /// <summary>
    ///     Equals multiple values and returns its result.
    /// </summary>
    /// <param name="values">The values.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The boolean representation of the equals comparisons.</returns>
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null)
            return !AreEqual;

        if (values.Length == 0)
            return !AreEqual;

        var allEqual = values.All(o => Equals(o, values[0]));
        return allEqual ? AreEqual : !AreEqual;
    }

    /// <summary>
    ///     ConvertBack is not implemented.
    /// </summary>
    /// <param name="value">Unused.</param>
    /// <param name="targetTypes">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>Nothing.</returns>
    /// <exception cref="NotImplementedException">ConvertBack is not implemented.</exception>
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}