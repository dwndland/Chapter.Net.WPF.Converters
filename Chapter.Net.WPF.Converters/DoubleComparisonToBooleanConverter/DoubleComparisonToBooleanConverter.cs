// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleComparisonToBooleanConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

#pragma warning disable CA2208
// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Executes a comparison on a single double or list of doubles to a boolean representation.
/// </summary>
[ValueConversion(typeof(double), typeof(bool))]
[ValueConversion(typeof(double[]), typeof(bool))]
public class DoubleComparisonToBooleanConverter : SingleAndMultiValueConverter
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
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool? TrueIs { get; set; } = true;

    /// <summary>
    ///     The return if the comparison is false.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool? FalseIs { get; set; } = false;

    /// <summary>
    ///     The return if the comparisons are mixed.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool? MixedIs { get; set; } = false;

    /// <summary>
    ///     Executes a comparison on a single double to a boolean representation.
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
    ///     Executes a comparison on a list of doubles to a boolean representation.
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
        return numbers.Count switch
        {
            0 => FalseIs,
            > 1 => MixedIs,
            _ => numbers[0]
        };
    }

    private bool? Compare(double number)
    {
        return ComparisonType switch
        {
            NumberComparisonType.BiggerThan => number > Variable ? TrueIs : FalseIs,
            NumberComparisonType.SmallerThan => number < Variable ? TrueIs : FalseIs,
            _ => throw new ArgumentOutOfRangeException(nameof(ComparisonType), ComparisonType, "ComparisonType got extended but not covered.")
        };
    }
}