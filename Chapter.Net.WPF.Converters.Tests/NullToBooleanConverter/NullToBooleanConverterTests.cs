// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NullToBooleanConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class NullToBooleanConverterTests : ConverterTester<NullToBooleanConverter>
{
    [TestCase(NullToBooleanDirection.NullIsFalse, null, false)]
    [TestCase(NullToBooleanDirection.NullIsFalse, 1, true)]
    [TestCase(NullToBooleanDirection.NullIsFalse, 1.0, true)]
    [TestCase(NullToBooleanDirection.NullIsFalse, "", true)]
    [TestCase(NullToBooleanDirection.NullIsFalse, "Default", true)]
    [TestCase(NullToBooleanDirection.NullIsTrue, null, true)]
    [TestCase(NullToBooleanDirection.NullIsTrue, 1, false)]
    [TestCase(NullToBooleanDirection.NullIsTrue, 1.0, false)]
    [TestCase(NullToBooleanDirection.NullIsTrue, "", false)]
    [TestCase(NullToBooleanDirection.NullIsTrue, "Default", false)]
    public void Convert_Called_ReturnsAccordingly(NullToBooleanDirection direction, object input, bool expect)
    {
        _target.Direction = direction;
        Convert(input, expect);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, null), Throws.TypeOf<NotImplementedException>());
    }
}