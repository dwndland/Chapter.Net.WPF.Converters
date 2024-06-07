// -----------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToVisibilityConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Converts a single boolean or a list of booleans into a Visibility representation.
/// </summary>
[ValueConversion(typeof(bool), typeof(Visibility))]
[ValueConversion(typeof(bool[]), typeof(Visibility))]
public class BooleanToVisibilityConverter : SingleAndMultiValueConverter
{
    /// <summary>
    ///     The return to use if the given boolean is true.
    /// </summary>
    /// <value>Default: Visibility.Visible.</value>
    [DefaultValue(Visibility.Visible)]
    public Visibility TrueIs { get; set; } = Visibility.Visible;

    /// <summary>
    ///     The return to use if the given boolean is false.
    /// </summary>
    /// <value>Default: Visibility.Collapsed.</value>
    [DefaultValue(Visibility.Collapsed)]
    public Visibility FalseIs { get; set; } = Visibility.Collapsed;

    /// <summary>
    ///     The return to use if the given boolean is null.
    /// </summary>
    /// <value>Default: Visibility.Hidden.</value>
    [DefaultValue(Visibility.Hidden)]
    public Visibility NullIs { get; set; } = Visibility.Hidden;

    /// <summary>
    ///     The return to use if the given booleans are mixed.
    /// </summary>
    /// <value>Default: Visibility.Visible.</value>
    [DefaultValue(Visibility.Visible)]
    public Visibility MixedIs { get; set; } = Visibility.Hidden;

    /// <summary>
    ///     Converts a single boolean into a Visibility representation.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return NullIs;

        if (value is bool boolean)
            return boolean ? TrueIs : FalseIs;

        return FalseIs;
    }

    /// <summary>
    ///     Converts a list of booleans into a Visibility representation.
    /// </summary>
    /// <param name="values">The values to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null)
            return FalseIs;

        var booleans = values.Select(x => x as bool?).Distinct().ToList();
        if (booleans.Count == 0)
            return FalseIs;
        if (booleans.Count > 1)
            return MixedIs;
        if (booleans[0] == null)
            return NullIs;
        return booleans[0].Value ? TrueIs : FalseIs;
    }

    /// <summary>
    ///     Converts a visibility back to its single boolean representation.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">The unused targetType.</param>
    /// <param name="parameter">The unused parameter.</param>
    /// <param name="culture">The unused culture.</param>
    /// <returns>The converted value.</returns>
    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (!(value is Visibility visibility))
            return false;
        if (visibility == TrueIs)
            return true;
        if (visibility == FalseIs)
            return false;
        if (visibility == NullIs)
            return null;
        return false;
    }
}