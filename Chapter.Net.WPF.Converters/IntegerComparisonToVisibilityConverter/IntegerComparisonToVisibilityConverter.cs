// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IntegerComparisonToVisibilityConverter.cs" company="my-libraries">
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
///     Executes a comparison on a single integer or list of integers to a Visibility representation.
/// </summary>
[ValueConversion(typeof(int), typeof(Visibility))]
[ValueConversion(typeof(int[]), typeof(Visibility))]
public class IntegerComparisonToVisibilityConverter : SingleAndMultiValueConverter
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
    /// <value>Default: 0.</value>
    [DefaultValue(0)]
    public int Variable { get; set; } = 0;

    /// <summary>
    ///     Defines the return if the comparison is true.
    /// </summary>
    /// <value>Default: Visibility.Visible.</value>
    [DefaultValue(Visibility.Visible)]
    public Visibility TrueIs { get; set; } = Visibility.Visible;

    /// <summary>
    ///     Defines the return if the comparison is false.
    /// </summary>
    /// <value>Default: Visibility.Collapsed.</value>
    [DefaultValue(Visibility.Collapsed)]
    public Visibility FalseIs { get; set; } = Visibility.Collapsed;

    /// <summary>
    ///     Defines the return if the comparisons are mixed.
    /// </summary>
    /// <value>Default: Visibility.Collapsed.</value>
    [DefaultValue(Visibility.Collapsed)]
    public Visibility MixedIs { get; set; } = Visibility.Hidden;

    /// <summary>
    ///     Executes a comparison on a single integer to a Visibility representation.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">ComparisonType got extended but not covered.</exception>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is int integer ? Compare(integer) : FalseIs;
    }

    /// <summary>
    ///     Executes a comparison on a list of integers to a Visibility representation.
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

        var numbers = values.OfType<int>().Select(Compare).Distinct().ToList();
        if (numbers.Count == 0)
            return FalseIs;
        if (numbers.Count > 1)
            return MixedIs;
        return numbers[0];
    }

    private Visibility Compare(int number)
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