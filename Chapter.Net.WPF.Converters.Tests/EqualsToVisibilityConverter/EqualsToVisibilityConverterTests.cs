// -----------------------------------------------------------------------------------------------------------------
// <copyright file="EqualsToVisibilityConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class EqualsToVisibilityConverterTests : SingleAndMultiValueConverterTester<EqualsToVisibilityConverter>
{
    [TestCase(1, 1, Visibility.Visible, Visibility.Collapsed, Visibility.Visible)]
    [TestCase(1, 1, Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed)]
    [TestCase(1, 1, Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden)]
    [TestCase(1, 1.0, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed)]
    [TestCase(1, 1.0, Visibility.Collapsed, Visibility.Visible, Visibility.Visible)]
    [TestCase(1, 1.0, Visibility.Visible, Visibility.Hidden, Visibility.Hidden)]
    [TestCase(1, 2, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed)]
    [TestCase(1, 2, Visibility.Collapsed, Visibility.Visible, Visibility.Visible)]
    [TestCase(1, 2, Visibility.Visible, Visibility.Hidden, Visibility.Hidden)]
    [TestCase("First", "First", Visibility.Visible, Visibility.Collapsed, Visibility.Visible)]
    [TestCase("First", "First", Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed)]
    [TestCase("First", "First", Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden)]
    [TestCase("First", "Second", Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed)]
    [TestCase("First", "Second", Visibility.Collapsed, Visibility.Visible, Visibility.Visible)]
    [TestCase("First", "Second", Visibility.Visible, Visibility.Hidden, Visibility.Hidden)]
    public void Convert_Called_Compares(object first, object second, Visibility isEqual, Visibility isNotEqual, Visibility expectation)
    {
        _target.IsEqual = isEqual;
        _target.IsNotEqual = isNotEqual;
        _target.CompareWith = second;

        Convert(first, expectation);
    }
    [TestCase(1, 1.0, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed)]
    [TestCase(1, 2, Visibility.Collapsed, Visibility.Visible, Visibility.Visible)]
    [TestCase(1, 2, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden)]
    [TestCase(1, 2, Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed)]
    [TestCase("First", "Second", Visibility.Collapsed, Visibility.Visible, Visibility.Visible)]
    [TestCase("First", "Second", Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden)]
    [TestCase("First", "Second", Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed)]
    public void Convert_Called_Compares(object first, object second, Visibility isEqual, Visibility isNotEqual, Visibility expectation)
    {
        _target.IsEqual = isEqual;
        _target.IsNotEqual = isNotEqual;
        Convert(first, second, expectation);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, null), Throws.TypeOf<NotImplementedException>());
    }
}