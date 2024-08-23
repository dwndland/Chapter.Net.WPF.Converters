// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IntegerToBooleanConverterTests.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class IntegerToBooleanConverterTests : SingleAndMultiValueConverterTester<IntegerToBooleanConverter>
{
    [TestCase(0, false)]
    [TestCase(1, true)]
    [TestCase(14.5, true)]
    [TestCase(-5, true)]
    [TestCase("Dummy", true)]
    [TestCase(null, true)]
    public void Convert_CalledWithExpectedFormats_Expects(object input, bool expected)
    {
        Convert(input, expected);
    }

    [TestCase(false, 0)]
    [TestCase(true, 1)]
    [TestCase(14.5, 1)]
    [TestCase(-5, 1)]
    [TestCase("Dummy", 1)]
    [TestCase(null, 1)]
    public void ConvertBack_CalledWithExpectedFormats_Expects(object input, int expected)
    {
        ConvertBack(input, expected);
    }

    [TestCase(null, false, 0, 0, 0)]
    [TestCase(null, true, 1, 1, 1)]
    [TestCase(null, true, -5, -5, -5)]
    [TestCase(null, false, 14.5, 14.5, 14.5)]
    [TestCase(null, false, "Dummy", "Dummy", "Dummy")]
    [TestCase(null, false, null, null, null)]
    [TestCase(null, false, null, null, null)]
    [TestCase(true, true, 1, 0, 1)]
    [TestCase(false, false, 1, 0, 1)]
    [TestCase(null, null, 1, 0, 1)]
    public void MultiConvert_CalledWithExpectedFormats_Expects(bool? mixedIs, bool? expected, params object[] input)
    {
        _target.MixedIs = mixedIs;

        MultiConvert(input, expected);
    }

    [Test]
    public void MultiConvertBack_Called_RaisesException()
    {
        Assert.That(() => MultiConvertBack(Visibility.Hidden, []), Throws.TypeOf<NotImplementedException>());
    }
}