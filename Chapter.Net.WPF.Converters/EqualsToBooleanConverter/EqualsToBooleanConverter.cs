// -----------------------------------------------------------------------------------------------------------------
// <copyright file="EqualsToBooleanConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Compares a single value to a variable or a list of values to each other and returns its boolean representation.
/// </summary>
[ValueConversion(typeof(object), typeof(bool))]
public class EqualsToBooleanConverter : SingleAndMultiValueConverter
{
    /// <summary>
    ///     The return if equals is true.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool? IsEqual { get; set; } = true;

    /// <summary>
    ///     The return if equals is false.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool? IsNotEqual { get; set; } = false;

    /// <summary>
    ///     The value to compare with.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object CompareWith { get; set; } = null;

    /// <summary>
    ///     Compares a single value to a variable and returns its boolean representation.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Equals(value, CompareWith) ? IsEqual : IsNotEqual;
    }

    /// <summary>
    ///     ConvertBack is not implemented.
    /// </summary>
    /// <param name="value">Unused.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>Nothing.</returns>
    /// <exception cref="NotImplementedException">The EqualsToBooleanConverter.ConvertBack is not implemented.</exception>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}