﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToBooleanConverter.cs" company="my-libraries">
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
///     Converts a single boolean or a list of booleans to another single boolean representation.
/// </summary>
[ValueConversion(typeof(bool), typeof(bool))]
[ValueConversion(typeof(bool[]), typeof(bool))]
public class BooleanToBooleanConverter : SingleAndMultiValueConverter
{
    /// <summary>
    ///     The return to use if the given boolean is true.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool? TrueIs { get; set; } = false;

    /// <summary>
    ///     The return to use if the given boolean is false.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool? FalseIs { get; set; } = true;

    /// <summary>
    ///     The return to use if the given booleans are mixed.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool? MixedIs { get; set; } = false;

    /// <summary>
    ///     Converts a single boolean to another single boolean representation.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is bool boolean ? boolean ? TrueIs : FalseIs : FalseIs;
    }

    /// <summary>
    ///     Converts a single boolean to another single boolean representation.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Convert(value, targetType, parameter, culture);
    }

    /// <summary>
    ///     Converts a list of booleans to another single boolean representation.
    /// </summary>
    /// <param name="values">The values to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null)
            return false;

        var booleans = values.OfType<bool>().Distinct().ToList();
        return booleans.Count switch
        {
            0 => false,
            > 1 => MixedIs,
            _ => booleans[0] ? TrueIs : FalseIs
        };
    }
}