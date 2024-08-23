// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleToThicknessConverterTests.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class DoubleToThicknessConverterTests : SingleAndMultiValueConverterTester<DoubleToThicknessConverter>
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

    [TestCase(1, 2, 3)]
    [TestCase(1, 2, 3, 4, 5)]
    [TestCase(1, 2, 3, 4, 5, 6)]
    public void MultiConvert_CalledWithWrongLength_ReturnsDefault(params object[] values)
    {
        MultiConvert(values, default(Thickness));
    }

    [Test]
    public void MultiConvert_CalledWithNull_ReturnsDefault()
    {
        MultiConvert(null, default(Thickness));
    }

    [TestCase(0, 2, 3, 4, "1", 2d, 3d, 4d)]
    [TestCase(1, 0, 3, 4, 1d, 2, 3d, 4d)]
    [TestCase(1, 2, 0, 4, 1d, 2d, null, 4d)]
    [TestCase(1, 2, 3, 0, 1d, 2d, 3d, "")]
    public void MultiConvert_CalledWithOtherThanADouble_InterpretsThoseAs0(double expectLeft, double expectTop, double expectRight, double expectBottom, params object[] values)
    {
        MultiConvert(values, new Thickness(expectLeft, expectTop, expectRight, expectBottom));
    }

    [TestCase(1, 1, 1, 1, 1d)]
    [TestCase(2, 3, 2, 3, 2d, 3d)]
    [TestCase(4, 5, 6, 7, 4d, 5d, 6d, 7d)]
    public void MultiConvert_Called_InterpretsCorrectly(double expectLeft, double expectTop, double expectRight, double expectBottom, params object[] values)
    {
        MultiConvert(values, new Thickness(expectLeft, expectTop, expectRight, expectBottom));
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase(1)]
    [TestCase(15.3)]
    public void MultiConvertBack_CalledWithAnythingButThickness_ReturnsEmptyCollection(object input)
    {
        MultiConvertBack(input, []);
    }

    [TestCase(1d, 2d, 3d, 4d)]
    [TestCase(5d, 4d, 3d, 2d)]
    public void MultiConvertBack_Called_ReturnsItSeparated(double left, double top, double right, double bottom)
    {
        var input = new Thickness(left, top, right, bottom);
        MultiConvertBack(input, [left, top, right, bottom]);
    }
}