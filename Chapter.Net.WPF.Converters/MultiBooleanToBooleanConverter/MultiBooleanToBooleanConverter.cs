// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MultiBooleanToBooleanConverter.cs" company="my-libraries">
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
///     Checks all given booleans and returns the given single boolean representation.
/// </summary>
[ValueConversion(typeof(bool[]), typeof(bool))]
public class MultiBooleanToBooleanConverter : IMultiValueConverter
{
    /// <summary>
    ///     The visibility to use if all given booleans are true.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool? AllTrueIs { get; set; } = true;

    /// <summary>
    ///     The visibility to use if all given booleans are false.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool? AllFalseIs { get; set; } = false;

    /// <summary>
    ///     The visibility to use if the given booleans are mixed state.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool? MixedIs { get; set; } = false;

    /// <summary>
    ///     Checks all given booleans and returns the given single boolean representation.
    /// </summary>
    /// <param name="values">The booleans to check.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The boolean representation of all given booleans.</returns>
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null)
            return false;

        var booleans = values.OfType<bool>().Distinct().ToList();
        if (booleans.Count == 0)
            return false;

        if (booleans.Count > 1)
            return MixedIs;

        return booleans.First() ? AllTrueIs : AllFalseIs;
    }

    /// <summary>
    ///     Not implemented.
    /// </summary>
    /// <param name="value">Unused.</param>
    /// <param name="targetTypes">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>Nothing.</returns>
    /// <exception cref="NotImplementedException">The MultiBooleanToBooleanConverter.ConvertBack is not implemented.</exception>
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}