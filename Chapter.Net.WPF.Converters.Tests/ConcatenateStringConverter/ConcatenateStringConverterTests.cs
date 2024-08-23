// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ConcatenateStringConverterTests.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class ConcatenateStringConverterTests : MultiValueConverterTester<ConcatenateStringConverter>
{
    [TestCase(false, "a..b..c", "..", "a", "b", "c")]
    [TestCase(false, "a..1..4", "..", "a", 1, 4)]
    [TestCase(false, "a.b.c", ".", "a", null, "b", "c", null)]
    [TestCase(false, "", "/", null, null)]
    [TestCase(true, "a..b..c", "..", "a", "b", "c")]
    [TestCase(true, "a..1..4", "..", "a", 1, 4)]
    [TestCase(true, "a..b.c.", ".", "a", null, "b", "c", null)]
    [TestCase(true, "/", "/", null, null)]
    public void Convert_Called_Concatenates(bool acceptNullParts, string expectation, string separator, params object[] values)
    {
        _target.AcceptNullParts = acceptNullParts;
        _target.Separator = separator;

        Convert(values, expectation);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, []), Throws.TypeOf<NotImplementedException>());
    }
}