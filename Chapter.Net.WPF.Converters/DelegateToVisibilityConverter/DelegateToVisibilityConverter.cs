// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DelegateToVisibilityConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Provides a delegate to convert a single value or a list of values to Visibility.
/// </summary>
[ValueConversion(typeof(object), typeof(Visibility))]
[ValueConversion(typeof(object[]), typeof(Visibility))]
public class DelegateToVisibilityConverter : SingleAndMultiValueConverter
{
    /// <summary>
    ///     The delegate to use to convert.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public Func<object, Visibility> ConvertDelegate { get; set; } = null;

    /// <summary>
    ///     The delegate to use to convert back.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public Func<Visibility, object> ConvertBackDelegate { get; set; } = null;

    /// <summary>
    ///     The delegate to use to convert.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public Func<object[], Visibility> MultiConvertDelegate { get; set; } = null;

    /// <summary>
    ///     The delegate to use to convert back.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public Func<Visibility, object[]> MultiConvertBackDelegate { get; set; } = null;

    /// <summary>
    ///     Provides a delegate to convert a single value to Visibility.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return ConvertDelegate?.Invoke(value) ?? Visibility.Collapsed;
    }

    /// <summary>
    ///     Provides a delegate to convert a Visibility back to a single value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (ConvertBackDelegate == null || value is not Visibility visibility)
            return value;

        return ConvertBackDelegate(visibility);
    }

    /// <summary>
    ///     Provides a delegate to convert a list of values to Visibility.
    /// </summary>
    /// <param name="values">The values to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return MultiConvertDelegate?.Invoke(values) ?? Visibility.Collapsed;
    }

    /// <summary>
    ///     Provides a delegate to convert a Visibility back to a list of values.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetTypes">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        if (MultiConvertBackDelegate == null || value is not Visibility visibility)
            return null;

        return MultiConvertBackDelegate(visibility);
    }
}