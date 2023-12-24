// -----------------------------------------------------------------------------------------------------------------
// <copyright file="CountToBooleanConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class CountToBooleanConverterTests : ConverterTester<CountToBooleanConverter>
{
    [TestCase(0, true, true)]
    [TestCase(13, true, false)]
    [TestCase(-14, true, false)]
    [TestCase(0.1, true, false)]
    [TestCase("Dummy", true, false)]
    [TestCase(null, true, false)]
    [TestCase(0, false, false)]
    [TestCase(13, false, true)]
    [TestCase(-14, false, true)]
    [TestCase(0.1, false, true)]
    [TestCase("Dummy", false, true)]
    [TestCase(null, false, true)]
    public void Convert_WithExpectedFormats_Expects(object input, bool isEmpty, bool expected)
    {
        _target.IsEmpty = isEmpty;
        Convert(input, expected);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, null), Throws.TypeOf<NotImplementedException>());
    }
}