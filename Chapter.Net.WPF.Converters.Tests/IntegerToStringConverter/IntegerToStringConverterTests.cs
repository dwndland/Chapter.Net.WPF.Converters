// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IntegerToStringConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class IntegerToStringConverterTests : ValueConverterTester<IntegerToStringConverter>
{
    [TestCase(0, 2, "00")]
    [TestCase(1, 3, "001")]
    [TestCase(1.0, 1, "")]
    [TestCase("Hans", 1, "")]
    [TestCase(null, 1, "")]
    public void Convert_Called_ReturnsExpected(object input, int digits, string expectation)
    {
        _target.Digits = digits;

        Convert(input, expectation);
    }

    [TestCase("00", 0)]
    [TestCase("001", 1)]
    [TestCase(1.0, 0)]
    [TestCase("Hans", 0)]
    [TestCase(null, 0)]
    public void ConvertBack_Called_Converts(object input, int expectation)
    {
        ConvertBack(input, expectation);
    }
}