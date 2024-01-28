// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleValueToThicknessConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class DoubleValueToThicknessConverterTests : ValueConverterTester<DoubleValueToThicknessConverter>
{
    [TestCase(13)]
    [TestCase("Anything")]
    [TestCase(null)]
    public void Convert_WithAnythingButDateOnly_ReturnsDefault(object input)
    {
        Convert(input, default(Thickness));
    }

    [TestCase(14.3, Position.All, 14.3, 14.3, 14.3, 14.3)]
    [TestCase(14.3, Position.Left, 14.3, 0, 0, 0)]
    [TestCase(14.3, Position.Top, 0, 14.3, 0, 0)]
    [TestCase(14.3, Position.Right, 0, 0, 14.3, 0)]
    [TestCase(14.3, Position.Bottom, 0, 0, 0, 14.3)]
    [TestCase(14.3, Position.LeftRight, 14.3, 0, 14.3, 0)]
    [TestCase(14.3, Position.TopBottom, 0, 14.3, 0, 14.3)]
    public void Convert_WithData_CreatesThickness(double input, Position position, double left, double top, double right, double bottom)
    {
        _target.Position = position;

        Convert(input, new Thickness(left, top, right, bottom));
    }

    [TestCase(14.3, 14.3, 14.3, 14.3, Position.All, 14.3)]
    [TestCase(14.3, 0, 0, 0, Position.Left, 14.3)]
    [TestCase(0, 14.3, 0, 0, Position.Top, 14.3)]
    [TestCase(0, 0, 14.3, 0, Position.Right, 14.3)]
    [TestCase(0, 0, 0, 14.3, Position.Bottom, 14.3)]
    [TestCase(14.3, 0, 14.3, 0, Position.LeftRight, 14.3)]
    [TestCase(0, 14.3, 0, 14.3, Position.TopBottom, 14.3)]
    public void ConvertBack_WithData_CreatesThickness(double inputLeft, double inputTop, double inputRight, double inputBottom, Position position, double expectation)
    {
        _target.Position = position;

        ConvertBack(new Thickness(inputLeft, inputTop, inputRight, inputBottom), expectation);
    }
}