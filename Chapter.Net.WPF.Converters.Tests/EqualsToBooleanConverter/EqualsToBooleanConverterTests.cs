// -----------------------------------------------------------------------------------------------------------------
// <copyright file="EqualsToBooleanConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class EqualsToBooleanConverterTests : ValueConverterTester<EqualsToBooleanConverter>
{
    [TestCase(1, 1, true, true)]
    [TestCase(1, 1, false, false)]
    [TestCase(1, 1.0, true, false)]
    [TestCase(1, 1.0, false, true)]
    [TestCase(1, 2, true, false)]
    [TestCase(1, 2, false, true)]
    [TestCase("First", "First", true, true)]
    [TestCase("First", "First", false, false)]
    [TestCase("First", "Second", true, false)]
    [TestCase("First", "Second", false, true)]
    public void Convert_Called_Compares(object first, object second, bool isEqual, bool expectation)
    {
        _target.IsEqual = isEqual;
        Convert(first, second, expectation);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, null), Throws.TypeOf<NotImplementedException>());
    }
}