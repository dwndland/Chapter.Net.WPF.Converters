// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IntegerToBooleanConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class IntegerToBooleanConverterTests : ConverterTester<IntegerToBooleanConverter>
{
    [TestCase(0, false)]
    [TestCase(1, true)]
    [TestCase(14.5, true)]
    [TestCase(-5, true)]
    [TestCase("Dummy", true)]
    [TestCase(null, true)]
    public void ConvertBack_CalledWithExpectedFormats_Expects(object input, bool expected)
    {
        Convert(input, expected);
    }

    [TestCase(false, 0)]
    [TestCase(true, 1)]
    [TestCase(14.5, 1)]
    [TestCase(-5, 1)]
    [TestCase("Dummy", 1)]
    [TestCase(null, 1)]
    public void Convert_CalledWithExpectedFormats_Expects(object input, int expected)
    {
        ConvertBack(input, expected);
    }
}