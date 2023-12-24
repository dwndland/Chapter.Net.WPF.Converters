// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MultiValueToThicknessConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class MultiValueToThicknessConverterTests : MultiConverterTester<MultiValueToThicknessConverter>
{
    [TestCase(1, 2, 3)]
    [TestCase(1, 2, 3, 4, 5)]
    [TestCase(1, 2, 3, 4, 5, 6)]
    public void Convert_CalledWithWrongLength_ReturnsDefault(params object[] values)
    {
        Convert(values, default(Thickness));
    }

    [Test]
    public void Convert_CalledWithNull_ReturnsDefault()
    {
        Convert(null, default(Thickness));
    }

    [TestCase(0, 2, 3, 4, "1", 2d, 3d, 4d)]
    [TestCase(1, 0, 3, 4, 1d, 2, 3d, 4d)]
    [TestCase(1, 2, 0, 4, 1d, 2d, null, 4d)]
    [TestCase(1, 2, 3, 0, 1d, 2d, 3d, "")]
    public void Convert_CalledWithOtherThanADouble_InterpretsThoseAs0(double expectLeft, double expectTop, double expectRight, double expectBottom, params object[] values)
    {
        Convert(values, new Thickness(expectLeft, expectTop, expectRight, expectBottom));
    }

    [TestCase(1, 1, 1, 1, 1d)]
    [TestCase(2, 3, 2, 3, 2d, 3d)]
    [TestCase(4, 5, 6, 7, 4d, 5d, 6d, 7d)]
    public void Convert_Called_InterpretsCorrectly(double expectLeft, double expectTop, double expectRight, double expectBottom, params object[] values)
    {
        Convert(values, new Thickness(expectLeft, expectTop, expectRight, expectBottom));
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase(1)]
    [TestCase(15.3)]
    public void ConvertBack_CalledWithAnythingButThickness_ReturnsEmptyCollection(object input)
    {
        ConvertBack(input, Array.Empty<object>());
    }

    [TestCase(1d, 2d, 3d, 4d)]
    [TestCase(5d, 4d, 3d, 2d)]
    public void ConvertBack_Called_ReturnsItSeparated(double left, double top, double right, double bottom)
    {
        var input = new Thickness(left, top, right, bottom);
        ConvertBack(input, new object[] { left, top, right, bottom });
    }
}