// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IsNullToVisibilityConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class IsNullToVisibilityConverterTests : SingleAndMultiValueConverterTester<IsNullToVisibilityConverter>
{
    [TestCase(Visibility.Visible, Visibility.Collapsed, null, Visibility.Visible)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, null, Visibility.Collapsed)]
    [TestCase(Visibility.Hidden, Visibility.Visible, null, Visibility.Hidden)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, "", Visibility.Collapsed)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, "", Visibility.Visible)]
    [TestCase(Visibility.Collapsed, Visibility.Hidden, "", Visibility.Hidden)]
    public void Convert_Called_Converts(Visibility nullIs, Visibility notNullIs, object input, Visibility result)
    {
        _target.NullIs = nullIs;
        _target.NotNullIs = notNullIs;

        Convert(input, result);
    }

    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Visible, null, null, null)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, Visibility.Hidden, Visibility.Collapsed, null, null, null)]
    [TestCase(Visibility.Hidden, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, null, null, null)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Collapsed, "", "", "")]
    [TestCase(Visibility.Collapsed, Visibility.Visible, Visibility.Hidden, Visibility.Visible, "", "", "")]
    [TestCase(Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, "", "", "")]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, "", null, "")]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Visible, Visibility.Visible, "", null, "")]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, "", null, "")]
    public void MultiConvert_Called_Converts(Visibility nullIs, Visibility notNullIs, Visibility mixedIs, Visibility result, params object[] input)
    {
        _target.NullIs = nullIs;
        _target.NotNullIs = notNullIs;
        _target.MixedIs = mixedIs;

        MultiConvert(input, result);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(Visibility.Hidden, Visibility.Hidden), Throws.TypeOf<NotImplementedException>());
    }

    [Test]
    public void MultiConvertBack_Called_RaisesException()
    {
        Assert.That(() => MultiConvertBack(Visibility.Hidden, Array.Empty<object>()), Throws.TypeOf<NotImplementedException>());
    }
}