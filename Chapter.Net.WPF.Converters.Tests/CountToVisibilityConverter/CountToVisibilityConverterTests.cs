// -----------------------------------------------------------------------------------------------------------------
// <copyright file="CountToVisibilityConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class CountToVisibilityConverterTests : ConverterTester<CountToVisibilityConverter>
{
    [TestCase(0, Visibility.Visible, Visibility.Collapsed, Visibility.Visible)]
    [TestCase(0, Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed)]
    [TestCase(0, Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden)]
    [TestCase(13, Visibility.Collapsed, Visibility.Visible, Visibility.Visible)]
    [TestCase(13, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed)]
    [TestCase(13, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden)]
    [TestCase(-14, Visibility.Collapsed, Visibility.Visible, Visibility.Visible)]
    [TestCase(-14, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed)]
    [TestCase(-14, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden)]
    [TestCase(0.1, Visibility.Collapsed, Visibility.Visible, Visibility.Visible)]
    [TestCase(0.1, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed)]
    [TestCase(0.1, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden)]
    [TestCase("Dummy", Visibility.Collapsed, Visibility.Visible, Visibility.Visible)]
    [TestCase("Dummy", Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed)]
    [TestCase("Dummy", Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden)]
    [TestCase(null, Visibility.Collapsed, Visibility.Visible, Visibility.Visible)]
    [TestCase(null, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed)]
    [TestCase(null, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden)]
    public void Convert_WithExpectedFormats_Expects(object input, Visibility isEmpty, Visibility isNotEmpty, Visibility expected)
    {
        _target.IsEmpty = isEmpty;
        _target.IsNotEmpty = isNotEmpty;
        Convert(input, expected);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, null), Throws.TypeOf<NotImplementedException>());
    }
}