// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ValueToPathConverterTests.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class ValueToPathConverterTests : MultiValueConverterTester<ValueToPathConverter>
{
    [TestCase(@"C:\directory\sub\file.txt", "C:", "directory", "sub", "file.txt")]
    [TestCase(@"C:\sub\file.txt", "C:", null, "sub", "file.txt")]
    [TestCase(@"C:\1\sub\file.txt", "C:", 1, "sub", "file.txt")]
    [TestCase(@"C:\1:\sub\file.txt", "C:", "1:", "sub", "file.txt")]
    [TestCase(@"C:", "C:")]
    [TestCase(@"C:\", @"C:\")]
    [TestCase(@"C:\1.txt", @"C:\", "1.txt")]
    [TestCase(@"1.txt", "1.txt")]
    public void Convert_WithParts_ReturnsExpected(string expected, params object[] sections)
    {
        Convert(sections, expected);
    }

    [Test]
    public void Convert_WithNull_ReturnsEmptyString()
    {
        Convert(null, string.Empty);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, []), Throws.TypeOf<NotImplementedException>());
    }
}