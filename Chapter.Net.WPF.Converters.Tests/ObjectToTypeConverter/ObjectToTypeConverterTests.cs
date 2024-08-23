// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectToTypeConverterTests.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class ObjectToTypeConverterTests : ValueConverterTester<ObjectToTypeConverter>
{
    [TestCase(1, typeof(int))]
    [TestCase(1.2, typeof(double))]
    [TestCase("Hans", typeof(string))]
    public void Convert_CalledWithObject_ReturnsItsType(object input, Type expectedType)
    {
        Convert(input, expectedType);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, null), Throws.TypeOf<NotImplementedException>());
    }
}