// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ConcatenateStringConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class ConcatenateStringConverterTests : MultiConverterTester<ConcatenateStringConverter>
{
    [TestCase("a..b..c", "..", "a", "b", "c")]
    [TestCase("a..1..4", "..", "a", 1, 4)]
    [TestCase("a.b.c", ".", "a", null, "b", "c", null)]
    [TestCase("", "/", null, null)]
    public void Convert_Called_Concatenates(string expectation, string separator, params object[] values)
    {
        _target.Separator = separator;

        Convert(values, expectation);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, Array.Empty<object>()), Throws.TypeOf<NotImplementedException>());
    }
}