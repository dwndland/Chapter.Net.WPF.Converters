// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleComparisonToVisibilityConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class DoubleComparisonToVisibilityConverterTests : SingleAndMultiValueConverterTester<DoubleComparisonToVisibilityConverter>
{
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, 5d, 5.1, Visibility.Visible)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Collapsed, Visibility.Collapsed, 5d, 5.1, Visibility.Collapsed)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Hidden, Visibility.Collapsed, 5d, 5.1, Visibility.Hidden)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, 5d, 4.9, Visibility.Collapsed)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Visible, 5d, 4.9, Visibility.Visible)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Hidden, 5d, 4.9, Visibility.Hidden)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, 5d, "", Visibility.Collapsed)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, 5d, Visibility.Hidden, Visibility.Collapsed)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, 5d, 4.9, Visibility.Visible)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Collapsed, Visibility.Collapsed, 5d, 4.9, Visibility.Collapsed)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Hidden, Visibility.Collapsed, 5d, 4.9, Visibility.Hidden)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, 5d, 5.1, Visibility.Collapsed)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Visible, 5d, 5.1, Visibility.Visible)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Hidden, 5d, 5.1, Visibility.Hidden)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, 5d, "", Visibility.Collapsed)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, 5d, Visibility.Hidden, Visibility.Collapsed)]
    public void Convert_Called_Converts(NumberComparisonType comparisonType, Visibility trueIs, Visibility falseIs, double variable, object input, Visibility expectation)
    {
        _target.ComparisonType = comparisonType;
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;
        _target.Variable = variable;

        Convert(input, expectation);
    }

    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5d, Visibility.Visible, 5.1, 5.2, 5.3)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Collapsed, Visibility.Collapsed, Visibility.Hidden, 5d, Visibility.Collapsed, 5.1, 5.2, 5.3)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden, 5d, Visibility.Hidden, 5.1, 5.2, 5.3)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5d, Visibility.Collapsed, 4.9, 4.9, 4.9)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Visible, Visibility.Hidden, 5d, Visibility.Visible, 4.9, 4.9, 4.9)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, 5d, Visibility.Hidden, 4.9, 4.9, 4.9)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5d, Visibility.Hidden, 4.9, 5.1, 4.9)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Visible, 5d, Visibility.Visible, 4.9, 5.1, 4.9)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, 5d, Visibility.Collapsed, 4.9, 5.1, 4.9)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5d, Visibility.Collapsed, "")]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5d, Visibility.Collapsed, Visibility.Hidden)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5d, Visibility.Visible, 4.9, 4.8, 4.7)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Collapsed, Visibility.Collapsed, Visibility.Hidden, 5d, Visibility.Collapsed, 4.9, 4.8, 4.7)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden, 5d, Visibility.Hidden, 4.9, 4.8, 4.7)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5d, Visibility.Collapsed, 5.1, 5.2, 5.3)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Visible, Visibility.Hidden, 5d, Visibility.Visible, 5.1, 5.2, 5.3)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, 5d, Visibility.Hidden, 5.1, 5.2, 5.3)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5d, Visibility.Hidden, 5.1, 4.9, 5.3)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Visible, 5d, Visibility.Visible, 5.1, 4.9, 5.3)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, 5d, Visibility.Collapsed, 5.1, 4.9, 5.3)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5d, Visibility.Collapsed, "")]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5d, Visibility.Collapsed, Visibility.Hidden)]
    public void Convert_Called_Converts(NumberComparisonType comparisonType, Visibility trueIs, Visibility falseIs, Visibility mixedIs, double variable, Visibility expectation, params object[] input)
    {
        _target.ComparisonType = comparisonType;
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;
        _target.MixedIs = mixedIs;
        _target.Variable = variable;

        MultiConvert(input, expectation);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, ""), Throws.TypeOf<NotImplementedException>());
    }

    [Test]
    public void MultiConvertBack_Called_RaisesException()
    {
        Assert.That(() => MultiConvertBack(null, Array.Empty<object>()), Throws.TypeOf<NotImplementedException>());
    }
}