// -----------------------------------------------------------------------------------------------------------------
// <copyright file="StringToLowerConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class StringToLowerConverterTests : ValueConverterTester<StringToLowerConverter>
{
    [TestCase(null, "")]
    [TestCase("", "")]
    [TestCase("Def", "def")]
    [TestCase("ABC", "abc")]
    public void Convert_Called_MakesUpper(string input, string expectation)
    {
        Convert(input, expectation);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, null), Throws.TypeOf<NotImplementedException>());
    }
}