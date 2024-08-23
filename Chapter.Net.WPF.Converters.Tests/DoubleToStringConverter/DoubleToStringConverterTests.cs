// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleToStringConverterTests.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Globalization;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class DoubleToStringConverterTests : ValueConverterTester<DoubleToStringConverter>
{
    [TestCase(4, 6, false, 15, "0015,000000")]
    [TestCase(0, 2, false, 15.199, "15,19")]
    [TestCase(3, 0, false, 15.199, "015")]
    [TestCase(4, 6, true, 15, "0015,000000")]
    [TestCase(0, 2, true, 15.199, "15,20")]
    [TestCase(3, 0, true, 15.199, "015")]
    public void Convert_Called_Converts(int digits, int decimalCount, bool roundDecimals, double input, string expectation)
    {
        CultureInfo.CurrentCulture = new CultureInfo("de-DE");

        _target.Digits = digits;
        _target.DecimalCount = decimalCount;
        _target.RoundDecimals = roundDecimals;

        Convert(input, expectation);
    }

    [TestCase("015,120", 15.12)]
    [TestCase("015", 15d)]
    [TestCase("", 0d)]
    [TestCase(null, 0d)]
    public void ConvertBack_Called_Converts(object input, object expectation)
    {
        CultureInfo.CurrentCulture = new CultureInfo("de-DE");

        ConvertBack(input, expectation);
    }
}