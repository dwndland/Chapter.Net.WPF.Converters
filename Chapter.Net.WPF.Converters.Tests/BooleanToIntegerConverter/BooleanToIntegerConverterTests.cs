// -----------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToIntegerConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using System;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class BooleanToIntegerConverterTests : SingleAndMultiValueConverterTester<BooleanToIntegerConverter>
{
    [TestCase(false, 0)]
    [TestCase(true, 1)]
    [TestCase(14.5, 1)]
    [TestCase(-5, 1)]
    [TestCase("Dummy", 1)]
    [TestCase(null, 1)]
    public void Convert_CalledWithExpectedFormats_Expects(object input, int expected)
    {
        Convert(input, expected);
    }

    [TestCase(0, 0, false, false, false)]
    [TestCase(0, 1, true, true, true)]
    [TestCase(0, 1, 14.5, true, true)]
    [TestCase(0, 1, -5, true, true)]
    [TestCase(0, 1, "Dummy", true, true)]
    [TestCase(0, 1, null, true, true)]
    [TestCase(0, 0, true, false, true)]
    [TestCase(1, 1, true, false, true)]
    public void MultiConvert_CalledWithExpectedFormats_Expects(int mixedIs, int expected, params object[] input)
    {
        _target.MixedIs = mixedIs;

        MultiConvert(input, expected);
    }

    [TestCase(0, false)]
    [TestCase(1, true)]
    [TestCase(14.5, true)]
    [TestCase(-5, true)]
    [TestCase("Dummy", true)]
    [TestCase(null, true)]
    public void ConvertBack_CalledWithExpectedFormats_Expects(object input, bool expected)
    {
        ConvertBack(input, expected);
    }

    [Test]
    public void MultiConvertBack_Called_RaisesException()
    {
        Assert.That(() => MultiConvertBack(null, []), Throws.TypeOf<NotImplementedException>());
    }
}