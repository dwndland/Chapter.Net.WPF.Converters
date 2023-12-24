// -----------------------------------------------------------------------------------------------------------------
// <copyright file="NullToVisibilityConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class NullToVisibilityConverterTests : ConverterTester<NullToVisibilityConverter>
{
    [TestCase(NullToVisibilityDirection.NullIsVisible, null, Visibility.Visible)]
    [TestCase(NullToVisibilityDirection.NullIsVisible, 1, Visibility.Collapsed)]
    [TestCase(NullToVisibilityDirection.NullIsVisible, 1.0, Visibility.Collapsed)]
    [TestCase(NullToVisibilityDirection.NullIsVisible, "", Visibility.Collapsed)]
    [TestCase(NullToVisibilityDirection.NullIsVisible, "Default", Visibility.Collapsed)]
    [TestCase(NullToVisibilityDirection.NotNullIsHidden, null, Visibility.Visible)]
    [TestCase(NullToVisibilityDirection.NotNullIsHidden, 1, Visibility.Hidden)]
    [TestCase(NullToVisibilityDirection.NotNullIsHidden, 1.0, Visibility.Hidden)]
    [TestCase(NullToVisibilityDirection.NotNullIsHidden, "", Visibility.Hidden)]
    [TestCase(NullToVisibilityDirection.NotNullIsHidden, "Default", Visibility.Hidden)]
    [TestCase(NullToVisibilityDirection.NullIsCollapsed, null, Visibility.Collapsed)]
    [TestCase(NullToVisibilityDirection.NullIsCollapsed, 1, Visibility.Visible)]
    [TestCase(NullToVisibilityDirection.NullIsCollapsed, 1.0, Visibility.Visible)]
    [TestCase(NullToVisibilityDirection.NullIsCollapsed, "", Visibility.Visible)]
    [TestCase(NullToVisibilityDirection.NullIsCollapsed, "Default", Visibility.Visible)]
    [TestCase(NullToVisibilityDirection.NullIsHidden, null, Visibility.Hidden)]
    [TestCase(NullToVisibilityDirection.NullIsHidden, "Default", Visibility.Visible)]
    [TestCase(NullToVisibilityDirection.NullIsHidden, 1, Visibility.Visible)]
    [TestCase(NullToVisibilityDirection.NullIsHidden, 1.0, Visibility.Visible)]
    [TestCase(NullToVisibilityDirection.NullIsHidden, "", Visibility.Visible)]
    public void Convert_Called_ReturnsAccordingly(NullToVisibilityDirection direction, object input, Visibility expect)
    {
        _target.Direction = direction;
        Convert(input, expect);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, null), Throws.TypeOf<NotImplementedException>());
    }
}