// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IntegerComparisonToBooleanConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class IntegerComparisonToBooleanConverterTests : SingleAndMultiValueConverterTester<IntegerComparisonToBooleanConverter>
{
    [TestCase(NumberComparisonType.BiggerThan, true, false, 5, 6, true)]
    [TestCase(NumberComparisonType.BiggerThan, false, false, 5, 6, false)]
    [TestCase(NumberComparisonType.BiggerThan, null, false, 5, 6, null)]
    [TestCase(NumberComparisonType.BiggerThan, true, false, 5, 4, false)]
    [TestCase(NumberComparisonType.BiggerThan, true, true, 5, 4, true)]
    [TestCase(NumberComparisonType.BiggerThan, true, null, 5, 4, null)]
    [TestCase(NumberComparisonType.BiggerThan, true, false, 5, "", false)]
    [TestCase(NumberComparisonType.BiggerThan, true, false, 5, null, false)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, 5, 4, true)]
    [TestCase(NumberComparisonType.SmallerThan, false, false, 5, 4, false)]
    [TestCase(NumberComparisonType.SmallerThan, null, false, 5, 4, null)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, 5, 6, false)]
    [TestCase(NumberComparisonType.SmallerThan, true, true, 5, 6, true)]
    [TestCase(NumberComparisonType.SmallerThan, true, null, 5, 6, null)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, 5, "", false)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, 5, null, false)]
    public void Convert_Called_Converts(NumberComparisonType comparisonType, bool? trueIs, bool? falseIs, int variable, object input, bool? expectation)
    {
        _target.ComparisonType = comparisonType;
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;
        _target.Variable = variable;

        Convert(input, expectation);
    }

    [TestCase(NumberComparisonType.BiggerThan, true, false, null, 5, true, 6, 7, 8)]
    [TestCase(NumberComparisonType.BiggerThan, false, false, null, 5, false, 6, 7, 8)]
    [TestCase(NumberComparisonType.BiggerThan, null, false, null, 5, null, 6, 7, 8)]
    [TestCase(NumberComparisonType.BiggerThan, true, false, null, 5, false, 4, 4, 4)]
    [TestCase(NumberComparisonType.BiggerThan, true, true, null, 5, true, 4, 4, 4)]
    [TestCase(NumberComparisonType.BiggerThan, true, null, null, 5, null, 4, 4, 4)]
    [TestCase(NumberComparisonType.BiggerThan, true, false, null, 5, null, 4, 6, 4)]
    [TestCase(NumberComparisonType.BiggerThan, true, false, true, 5, true, 4, 6, 4)]
    [TestCase(NumberComparisonType.BiggerThan, true, false, false, 5, false, 4, 6, 4)]
    [TestCase(NumberComparisonType.BiggerThan, true, false, null, 5, false, "")]
    [TestCase(NumberComparisonType.BiggerThan, true, false, null, 5, false, null)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, null, 5, true, 4, 3, 2)]
    [TestCase(NumberComparisonType.SmallerThan, false, false, null, 5, false, 4, 3, 2)]
    [TestCase(NumberComparisonType.SmallerThan, null, false, null, 5, null, 4, 3, 2)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, null, 5, false, 6, 7, 8)]
    [TestCase(NumberComparisonType.SmallerThan, true, true, null, 5, true, 6, 7, 8)]
    [TestCase(NumberComparisonType.SmallerThan, true, null, null, 5, null, 6, 7, 8)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, null, 5, null, 6, 4, 8)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, true, 5, true, 6, 4, 8)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, false, 5, false, 6, 4, 8)]
    [TestCase(NumberComparisonType.SmallerThan, true, false, null, 5, false, "")]
    [TestCase(NumberComparisonType.SmallerThan, true, false, null, 5, false, null)]
    public void Convert_Called_Converts(NumberComparisonType comparisonType, bool? trueIs, bool? falseIs, bool? mixedIs, int variable, bool? expectation, params object[] input)
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