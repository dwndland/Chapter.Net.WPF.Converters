// -----------------------------------------------------------------------------------------------------------------
// <copyright file="StringToUpperConverterTests.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class StringToUpperConverterTests : ValueConverterTester<StringToUpperConverter>
{
    [TestCase(null, "")]
    [TestCase("", "")]
    [TestCase("Def", "DEF")]
    [TestCase("abc", "ABC")]
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