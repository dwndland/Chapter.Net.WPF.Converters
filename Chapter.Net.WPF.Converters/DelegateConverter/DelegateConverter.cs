// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DelegateConverter.cs" company="my-libraries">
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
///     Provides a delegate to convert a single value or a list of values.
/// </summary>
[ValueConversion(typeof(object), typeof(object))]
[ValueConversion(typeof(object[]), typeof(object))]
public class DelegateConverter : SingleAndMultiValueConverter
{
    /// <summary>
    ///     The delegate to use to convert.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public Func<object, object> ConvertDelegate { get; set; } = null;

    /// <summary>
    ///     The delegate to use to convert back.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public Func<object, object> ConvertBackDelegate { get; set; } = null;

    /// <summary>
    ///     The delegate to use to convert.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public Func<object[], object> MultiConvertDelegate { get; set; } = null;

    /// <summary>
    ///     The delegate to use to convert back.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public Func<object, object[]> MultiConvertBackDelegate { get; set; } = null;

    /// <summary>
    ///     Provides a delegate to convert a single value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return ConvertDelegate == null ? value : ConvertDelegate(value);
    }

    /// <summary>
    ///     Provides a delegate to convert a single value back.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return ConvertBackDelegate == null ? value : ConvertBackDelegate(value);
    }

    /// <summary>
    ///     Provides a delegate to convert a list of values.
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
    ///     Provides a delegate to convert a list of values back.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetTypes">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        return MultiConvertBackDelegate?.Invoke(value);
    }
}