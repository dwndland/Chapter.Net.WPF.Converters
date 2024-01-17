// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MultiBooleanToVisibilityConverter.cs" company="my-libraries">
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
///     Checks all given booleans and returns the given single visibility representation.
/// </summary>
[ValueConversion(typeof(bool[]), typeof(Visibility))]
public class MultiBooleanToVisibilityConverter : IMultiValueConverter
{
    /// <summary>
    ///     The visibility to use if all given booleans are true.
    /// </summary>
    /// <value>Default: Visibility.Visible.</value>
    [DefaultValue(Visibility.Visible)]
    public Visibility AllTrueIs { get; set; } = Visibility.Visible;

    /// <summary>
    ///     The visibility to use if all given booleans are false.
    /// </summary>
    /// <value>Default: Visibility.Collapsed.</value>
    [DefaultValue(Visibility.Collapsed)]
    public Visibility AllFalseIs { get; set; } = Visibility.Collapsed;

    /// <summary>
    ///     The visibility to use if the given booleans are mixed state.
    /// </summary>
    /// <value>Default: Visibility.Collapsed.</value>
    [DefaultValue(Visibility.Collapsed)]
    public Visibility MixedIs { get; set; } = Visibility.Collapsed;

    /// <summary>
    ///     Checks all given booleans and returns the given single visibility representation.
    /// </summary>
    /// <param name="values">The booleans to check.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The visibility representation of all given booleans.</returns>
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null)
            return Visibility.Collapsed;

        var booleans = values.OfType<bool>().Distinct().ToList();
        if (booleans.Count == 0)
            return Visibility.Collapsed;

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
    /// <exception cref="NotImplementedException">The MultiBooleanToVisibilityConverter.ConvertBack is not implemented.</exception>
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}