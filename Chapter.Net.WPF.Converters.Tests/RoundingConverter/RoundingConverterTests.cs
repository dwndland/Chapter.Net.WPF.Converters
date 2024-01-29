// -----------------------------------------------------------------------------------------------------------------
// <copyright file="RoundingConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class RoundingConverterTests : ValueConverterTester<RoundingConverter>
{
    [TestCase(RoundingMode.Ceiling, 2, 15.1, 16)]
    [TestCase(RoundingMode.Ceiling, 2, 15.5, 16)]
    [TestCase(RoundingMode.Ceiling, 2, 15.9, 16)]
    [TestCase(RoundingMode.Ceiling, 2, null, 0)]
    [TestCase(RoundingMode.Ceiling, 2, "abc", 0)]
    [TestCase(RoundingMode.Floor, 2, 15.1, 15)]
    [TestCase(RoundingMode.Floor, 2, 15.5, 15)]
    [TestCase(RoundingMode.Floor, 2, 15.9, 15)]
    [TestCase(RoundingMode.Floor, 2, null, 0)]
    [TestCase(RoundingMode.Floor, 2, "abc", 0)]
    [TestCase(RoundingMode.Round, 2, 15.4, 15)]
    [TestCase(RoundingMode.Round, 2, 15.5, 16)]
    [TestCase(RoundingMode.Round, 2, 15.6, 16)]
    [TestCase(RoundingMode.Round, 2, null, 0)]
    [TestCase(RoundingMode.Round, 2, "abc", 0)]
    [TestCase(RoundingMode.RoundWithDecimals, 2, 15.449, 15.45)]
    [TestCase(RoundingMode.RoundWithDecimals, 2, 15.450, 15.45)]
    [TestCase(RoundingMode.RoundWithDecimals, 2, 15.451, 15.45)]
    [TestCase(RoundingMode.RoundWithDecimals, 2, null, 0)]
    [TestCase(RoundingMode.RoundWithDecimals, 2, "abc", 0)]
    public void Convert_Called_Rounds(RoundingMode mode, int decimals, object input, double expectation)
    {
        _target.Mode = mode;
        _target.DecimalPlaces = decimals;

        Convert(input, expectation);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, null), Throws.TypeOf<NotImplementedException>());
    }
}