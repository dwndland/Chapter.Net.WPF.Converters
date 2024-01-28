// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IntegerComparisonToVisibilityConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class IntegerComparisonToVisibilityConverterTests : SingleAndMultiValueConverterTester<IntegerComparisonToVisibilityConverter>
{
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, 5, 6, Visibility.Visible)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Collapsed, Visibility.Collapsed, 5, 6, Visibility.Collapsed)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Hidden, Visibility.Collapsed, 5, 6, Visibility.Hidden)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, 5, 4, Visibility.Collapsed)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Visible, 5, 4, Visibility.Visible)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Hidden, 5, 4, Visibility.Hidden)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, 5, "", Visibility.Collapsed)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, 5, Visibility.Hidden, Visibility.Collapsed)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, 5, 4, Visibility.Visible)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Collapsed, Visibility.Collapsed, 5, 4, Visibility.Collapsed)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Hidden, Visibility.Collapsed, 5, 4, Visibility.Hidden)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, 5, 6, Visibility.Collapsed)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Visible, 5, 6, Visibility.Visible)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Hidden, 5, 6, Visibility.Hidden)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, 5, "", Visibility.Collapsed)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, 5, Visibility.Hidden, Visibility.Collapsed)]
    public void Convert_Called_Converts(NumberComparisonType comparisonType, Visibility trueIs, Visibility falseIs, int variable, object input, Visibility expectation)
    {
        _target.ComparisonType = comparisonType;
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;
        _target.Variable = variable;

        Convert(input, expectation);
    }

    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5, Visibility.Visible, 6, 7, 8)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Collapsed, Visibility.Collapsed, Visibility.Hidden, 5, Visibility.Collapsed, 6, 7, 8)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden, 5, Visibility.Hidden, 6, 7, 8)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5, Visibility.Collapsed, 4, 4, 4)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Visible, Visibility.Hidden, 5, Visibility.Visible, 4, 4, 4)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, 5, Visibility.Hidden, 4, 4, 4)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5, Visibility.Hidden, 4, 6, 4)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Visible, 5, Visibility.Visible, 4, 6, 4)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, 5, Visibility.Collapsed, 4, 6, 4)]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5, Visibility.Collapsed, "")]
    [TestCase(NumberComparisonType.BiggerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5, Visibility.Collapsed, Visibility.Hidden)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5, Visibility.Visible, 4, 3, 2)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Collapsed, Visibility.Collapsed, Visibility.Hidden, 5, Visibility.Collapsed, 4, 3, 2)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden, 5, Visibility.Hidden, 4, 3, 2)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5, Visibility.Collapsed, 6, 7, 8)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Visible, Visibility.Hidden, 5, Visibility.Visible, 6, 7, 8)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, 5, Visibility.Hidden, 6, 7, 8)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5, Visibility.Hidden, 6, 4, 8)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Visible, 5, Visibility.Visible, 6, 4, 8)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, 5, Visibility.Collapsed, 6, 4, 8)]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5, Visibility.Collapsed, "")]
    [TestCase(NumberComparisonType.SmallerThan, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, 5, Visibility.Collapsed, Visibility.Hidden)]
    public void Convert_Called_Converts(NumberComparisonType comparisonType, Visibility trueIs, Visibility falseIs, Visibility mixedIs, int variable, Visibility expectation, params object[] input)
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
        Assert.That(() => ConvertBack(Visibility.Hidden, ""), Throws.TypeOf<NotImplementedException>());
    }

    [Test]
    public void MultiConvertBack_Called_RaisesException()
    {
        Assert.That(() => MultiConvertBack(Visibility.Hidden, Array.Empty<object>()), Throws.TypeOf<NotImplementedException>());
    }
}