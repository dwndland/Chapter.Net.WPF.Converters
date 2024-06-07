// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleComparisonToVisibilityConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

#pragma warning disable CA2208
// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Executes a comparison on a single Visibility or list of Visibilities to a boolean representation.
/// </summary>
[ValueConversion(typeof(double), typeof(Visibility))]
[ValueConversion(typeof(double[]), typeof(Visibility))]
public class DoubleComparisonToVisibilityConverter : SingleAndMultiValueConverter
{
    /// <summary>
    ///     Defines the comparison type.
    /// </summary>
    /// <value>Default: NumberComparisonType.BiggerThan.</value>
    [DefaultValue(NumberComparisonType.BiggerThan)]
    public NumberComparisonType ComparisonType { get; set; } = NumberComparisonType.BiggerThan;

    /// <summary>
    ///     The variable to compare with.
    /// </summary>
    /// <value>Default: 0d.</value>
    [DefaultValue(0d)]
    public double Variable { get; set; } = 0d;

    /// <summary>
    ///     The return if the comparison is true.
    /// </summary>
    /// <value>Default: Visibility.Visible.</value>
    [DefaultValue(Visibility.Visible)]
    public Visibility TrueIs { get; set; } = Visibility.Visible;

    /// <summary>
    ///     The return if the comparison is false.
    /// </summary>
    /// <value>Default: Visibility.Collapsed.</value>
    [DefaultValue(Visibility.Collapsed)]
    public Visibility FalseIs { get; set; } = Visibility.Collapsed;

    /// <summary>
    ///     The return if the comparisons are mixed.
    /// </summary>
    /// <value>Default: Visibility.Hidden.</value>
    [DefaultValue(Visibility.Hidden)]
    public Visibility MixedIs { get; set; } = Visibility.Hidden;

    /// <summary>
    ///     Executes a comparison on a single double to a Visibility representation.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">ComparisonType got extended but not covered.</exception>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is double number ? Compare(number) : FalseIs;
    }

    /// <summary>
    ///     Executes a comparison on a list of doubles to a Visibilities representation.
    /// </summary>
    /// <param name="values">The values to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">ComparisonType got extended but not covered.</exception>
    public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null)
            return FalseIs;

        var numbers = values.OfType<double>().Select(Compare).Distinct().ToList();
        if (numbers.Count == 0)
            return FalseIs;
        if (numbers.Count > 1)
            return MixedIs;
        return numbers[0];
    }

    private Visibility Compare(double number)
    {
        switch (ComparisonType)
        {
            case NumberComparisonType.BiggerThan:
                return number > Variable ? TrueIs : FalseIs;
            case NumberComparisonType.SmallerThan:
                return number < Variable ? TrueIs : FalseIs;
            default:
                throw new ArgumentOutOfRangeException(nameof(ComparisonType), ComparisonType, "ComparisonType got extended but not covered.");
        }
    }
}