// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MultiEqualsToVisibilityConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class MultiEqualsToVisibilityConverterTests : MultiConverterTester<MultiEqualsToVisibilityConverter>
{
    [TestCase(Visibility.Collapsed)]
    [TestCase(Visibility.Hidden)]
    [TestCase(Visibility.Visible)]
    public void Convert_CalledWithNull_ReturnsExpected(Visibility areNotEqual)
    {
        _target.AreNotEqual = areNotEqual;
        Convert(null, areNotEqual);
    }

    [TestCase(Visibility.Collapsed)]
    [TestCase(Visibility.Hidden)]
    [TestCase(Visibility.Visible)]
    public void Convert_CalledWithEmpty_ReturnsExpected(Visibility areNotEqual)
    {
        _target.AreNotEqual = areNotEqual;
        Convert(Array.Empty<object>(), areNotEqual);
    }

    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Visible, 1, 1, 1)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, 0, 1, 1)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, 1, 0, 1)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, 1, 1, 0)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, 1, 0, 0)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, 0, 1, 0)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, 0, 0, 1)]
    [TestCase(Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden, 1, 1, 1)]
    [TestCase(Visibility.Hidden, Visibility.Collapsed, Visibility.Collapsed, 0, 1, 1)]
    [TestCase(Visibility.Hidden, Visibility.Collapsed, Visibility.Collapsed, 1, 0, 1)]
    [TestCase(Visibility.Hidden, Visibility.Collapsed, Visibility.Collapsed, 1, 1, 0)]
    [TestCase(Visibility.Hidden, Visibility.Collapsed, Visibility.Collapsed, 1, 0, 0)]
    [TestCase(Visibility.Hidden, Visibility.Collapsed, Visibility.Collapsed, 0, 1, 0)]
    [TestCase(Visibility.Hidden, Visibility.Collapsed, Visibility.Collapsed, 0, 0, 1)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed, 1, 1, 1)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, Visibility.Visible, 0, 1, 1)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, Visibility.Visible, 1, 0, 1)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, Visibility.Visible, 1, 1, 0)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, Visibility.Visible, 1, 0, 0)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, Visibility.Visible, 0, 1, 0)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, Visibility.Visible, 0, 0, 1)]
    [TestCase(Visibility.Collapsed, Visibility.Hidden, Visibility.Collapsed, 1, 1, 1)]
    [TestCase(Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, 0, 1, 1)]
    [TestCase(Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, 1, 0, 1)]
    [TestCase(Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, 1, 1, 0)]
    [TestCase(Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, 1, 0, 0)]
    [TestCase(Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, 0, 1, 0)]
    [TestCase(Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, 0, 0, 1)]
    public void Convert_Called_ReturnsAccordingly(Visibility areEqual, Visibility areNotEqual, Visibility expect, params object[] input)
    {
        _target.AreEqual = areEqual;
        _target.AreNotEqual = areNotEqual;
        Convert(input, expect);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, Array.Empty<object>()), Throws.TypeOf<NotImplementedException>());
    }
}