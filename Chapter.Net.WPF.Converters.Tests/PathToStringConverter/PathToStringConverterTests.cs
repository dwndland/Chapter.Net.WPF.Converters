// -----------------------------------------------------------------------------------------------------------------
// <copyright file="PathToStringConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class PathToStringConverterTests : ValueConverterTester<PathToStringConverter>
{
    [TestCase(PathSection.Drive, null, "")]
    [TestCase(PathSection.Drive, @"C:\Drive\File.txt", @"C:\")]
    [TestCase(PathSection.Directory, @"C:\Drive\File.txt", @"C:\Drive")]
    [TestCase(PathSection.FileName, @"C:\Drive\File.txt", "File.txt")]
    [TestCase(PathSection.Extension, @"C:\Drive\File.txt", ".txt")]
    [TestCase(PathSection.PathWithoutExtension, @"C:\Drive\File.txt", @"C:\Drive\File")]
    [TestCase(PathSection.FileWithoutExtension, @"C:\Drive\File.txt", "File")]
    public void Convert_Called_ReturnsAccordingly(PathSection section, string input, string expected)
    {
        _target.Section = section;
        Convert(input, expected);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, null), Throws.TypeOf<NotImplementedException>());
    }
}