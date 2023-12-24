// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MultiEqualsToVisibilityConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Equals multiple values and returns its visibility representation.
/// </summary>
[ValueConversion(typeof(object[]), typeof(Visibility))]
public class MultiEqualsToVisibilityConverter : IMultiValueConverter
{
    /// <summary>
    ///     The visibility to return if all equals are true.
    /// </summary>
    /// <value>Default: Visibility.Visible.</value>
    public Visibility AreEqual { get; set; } = Visibility.Visible;

    /// <summary>
    ///     The visibility to return if all equals are false.
    /// </summary>
    /// <value>Default: Visibility.Collapsed.</value>
    public Visibility AreNotEqual { get; set; } = Visibility.Collapsed;

    /// <summary>
    ///     Equals multiple values and returns its visibility representation.
    /// </summary>
    /// <param name="values">The values.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The visibility representation of the equals comparisons.</returns>
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null)
            return AreNotEqual;

        if (values.Length == 0)
            return AreNotEqual;

        var allEqual = values.All(o => Equals(o, values[0]));
        return allEqual ? AreEqual : AreNotEqual;
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