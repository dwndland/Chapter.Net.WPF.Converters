// -----------------------------------------------------------------------------------------------------------------
// <copyright file="InverseBooleanConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class InverseBooleanConverterTests : ConverterTester<InverseBooleanConverter>
{
    [TestCase(true, true, false)]
    [TestCase(false, true, true)]
    [TestCase(null, true, true)]
    [TestCase(null, false, false)]
    [TestCase(null, null, null)]
    [TestCase(1, true, true)]
    [TestCase(1.5, true, true)]
    [TestCase("Dummy", true, true)]
    public void Convert_Called_ResultsIn(object input, bool? nullValue, bool? expected)
    {
        _target.NullValue = nullValue;
        Convert(input, expected);
    }

    [TestCase(true, true, false)]
    [TestCase(false, true, true)]
    [TestCase(null, true, true)]
    [TestCase(null, false, false)]
    [TestCase(null, null, null)]
    [TestCase(1, true, true)]
    [TestCase(1.5, true, true)]
    [TestCase("Dummy", true, true)]
    public void ConvertBack_Called_ResultsIn(object input, bool? nullValue, bool? expected)
    {
        _target.NullValue = nullValue;
        ConvertBack(input, expected);
    }
}