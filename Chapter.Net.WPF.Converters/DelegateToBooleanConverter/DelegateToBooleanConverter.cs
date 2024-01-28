// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DelegateToBooleanConverter.cs" company="my-libraries">
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
///     Provides a delegate to convert a single value or a list of values to boolean.
/// </summary>
[ValueConversion(typeof(object), typeof(bool))]
[ValueConversion(typeof(object[]), typeof(bool))]
public class DelegateToBooleanConverter : SingleAndMultiValueConverter
{
    /// <summary>
    ///     The delegate to use to convert.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public Func<object, bool> ConvertDelegate { get; set; } = null;

    /// <summary>
    ///     The delegate to use to convert back.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public Func<bool, object> ConvertBackDelegate { get; set; } = null;

    /// <summary>
    ///     The delegate to use to convert.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public Func<object[], bool> MultiConvertDelegate { get; set; } = null;

    /// <summary>
    ///     The delegate to use to convert back.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public Func<bool, object[]> MultiConvertBackDelegate { get; set; } = null;

    /// <summary>
    ///     Provides a delegate to convert a single value to boolean.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return ConvertDelegate != null && ConvertDelegate(value);
    }

    /// <summary>
    ///     Provides a delegate to convert a boolean back to a single value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (ConvertBackDelegate == null || value is not bool boolean)
            return value;

        return ConvertBackDelegate(boolean);
    }

    /// <summary>
    ///     Provides a delegate to convert a list of values to boolean.
    /// </summary>
    /// <param name="values">The values to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return MultiConvertDelegate?.Invoke(values);
    }

    /// <summary>
    ///     Provides a delegate to convert a boolean back to a list of values.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetTypes">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        if (MultiConvertBackDelegate == null || value is not bool boolean)
            return null;

        return MultiConvertBackDelegate(boolean);
    }
}