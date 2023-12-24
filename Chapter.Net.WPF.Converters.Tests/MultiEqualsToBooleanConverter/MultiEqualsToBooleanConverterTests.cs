// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MultiEqualsToBooleanConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class MultiEqualsToBooleanConverterTests : MultiConverterTester<MultiEqualsToBooleanConverter>
{
    [TestCase(true, false)]
    [TestCase(false, true)]
    public void Convert_NullCollection_ReturnsAccordingly(bool areEqual, bool expect)
    {
        _target.AreEqual = areEqual;
        Convert(null, expect);
    }

    [TestCase(true, false)]
    [TestCase(false, true)]
    public void Convert_EmptyCollection_ReturnsAccordingly(bool areEqual, bool expect)
    {
        _target.AreEqual = areEqual;
        Convert(Array.Empty<object>(), expect);
    }

    [TestCase(true, true, 1, 1, 1)]
    [TestCase(true, false, 0, 1, 1)]
    [TestCase(true, false, 1, 0, 1)]
    [TestCase(true, false, 1, 1, 0)]
    [TestCase(true, false, 1, 0, 0)]
    [TestCase(true, false, 0, 1, 0)]
    [TestCase(true, false, 0, 0, 1)]
    [TestCase(false, false, 1, 1, 1)]
    [TestCase(false, true, 0, 1, 1)]
    [TestCase(false, true, 1, 0, 1)]
    [TestCase(false, true, 1, 1, 0)]
    [TestCase(false, true, 1, 0, 0)]
    [TestCase(false, true, 0, 1, 0)]
    [TestCase(false, true, 0, 0, 1)]
    public void Convert_Called_ReturnsAccordingly(bool areEqual, bool expect, params object[] input)
    {
        _target.AreEqual = areEqual;
        Convert(input, expect);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, Array.Empty<object>()), Throws.TypeOf<NotImplementedException>());
    }
}