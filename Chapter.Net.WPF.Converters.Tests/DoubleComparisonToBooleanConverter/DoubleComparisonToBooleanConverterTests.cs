// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleComparisonToBooleanConverterTests.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class DoubleComparisonToBooleanConverterTests : SingleAndMultiValueConverterTester<DoubleComparisonToBooleanConverter>
{
    [TestCase(NumberComparisonType.BiggerThan, true, false, 5d, 5.1, true)]
    [TestCase(NumberComparisonType.BiggerThan, false, false, 5d, 5.1, false)]
    [TestCase(NumberComparisonType.BiggerThan, null, false, 5d, 5.1, null)]
    [TestCase(NumberComparisonType.BiggerThan, true, false, 5d, 4.9, false)]
    [TestCase(NumberComparisonType.BiggerThan, true, true, 5d, 4.9, true)]
    [TestCase(NumberComparisonType.BiggerThan, true, null, 5d, 4.9, null)]
    [TestCase(NumberComparisonType.BiggerThan, true, false, 5d, "", false)]
    [TestCase(NumberComparisonType.BiggerThan, true, false, 5d, null, false)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, 5d, 4.9, true)]
    [TestCase(NumberComparisonType.SmallerThan, false, false, 5d, 4.9, false)]
    [TestCase(NumberComparisonType.SmallerThan, null, false, 5d, 4.9, null)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, 5d, 5.1, false)]
    [TestCase(NumberComparisonType.SmallerThan, true, true, 5d, 5.1, true)]
    [TestCase(NumberComparisonType.SmallerThan, true, null, 5d, 5.1, null)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, 5d, "", false)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, 5d, null, false)]
    public void Convert_Called_Converts(NumberComparisonType comparisonType, bool? trueIs, bool? falseIs, double variable, object input, bool? expectation)
    {
        _target.ComparisonType = comparisonType;
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;
        _target.Variable = variable;

        Convert(input, expectation);
    }

    [TestCase(NumberComparisonType.BiggerThan, true, false, null, 5d, true, 5.1, 5.2, 5.3)]
    [TestCase(NumberComparisonType.BiggerThan, false, false, null, 5d, false, 5.1, 5.2, 5.3)]
    [TestCase(NumberComparisonType.BiggerThan, null, false, null, 5d, null, 5.1, 5.2, 5.3)]
    [TestCase(NumberComparisonType.BiggerThan, true, false, null, 5d, false, 4.9, 4.9, 4.9)]
    [TestCase(NumberComparisonType.BiggerThan, true, true, null, 5d, true, 4.9, 4.9, 4.9)]
    [TestCase(NumberComparisonType.BiggerThan, true, null, null, 5d, null, 4.9, 4.9, 4.9)]
    [TestCase(NumberComparisonType.BiggerThan, true, false, null, 5d, null, 4.9, 5.1, 4.9)]
    [TestCase(NumberComparisonType.BiggerThan, true, false, true, 5d, true, 4.9, 5.1, 4.9)]
    [TestCase(NumberComparisonType.BiggerThan, true, false, false, 5d, false, 4.9, 5.1, 4.9)]
    [TestCase(NumberComparisonType.BiggerThan, true, false, null, 5d, false, "")]
    [TestCase(NumberComparisonType.BiggerThan, true, false, null, 5d, false, null)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, null, 5d, true, 4.9, 4.8, 4.7)]
    [TestCase(NumberComparisonType.SmallerThan, false, false, null, 5d, false, 4.9, 4.8, 4.7)]
    [TestCase(NumberComparisonType.SmallerThan, null, false, null, 5d, null, 4.9, 4.8, 4.7)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, null, 5d, false, 5.1, 5.2, 5.3)]
    [TestCase(NumberComparisonType.SmallerThan, true, true, null, 5d, true, 5.1, 5.2, 5.3)]
    [TestCase(NumberComparisonType.SmallerThan, true, null, null, 5d, null, 5.1, 5.2, 5.3)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, null, 5d, null, 5.1, 4.9, 5.3)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, true, 5d, true, 5.1, 4.9, 5.3)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, false, 5d, false, 5.1, 4.9, 5.3)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, null, 5d, false, "")]
    [TestCase(NumberComparisonType.SmallerThan, true, false, null, 5d, false, null)]
    public void Convert_Called_Converts(NumberComparisonType comparisonType, bool? trueIs, bool? falseIs, bool? mixedIs, double variable, bool? expectation, params object[] input)
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
        Assert.That(() => MultiConvertBack(null, []), Throws.TypeOf<NotImplementedException>());
    }
}