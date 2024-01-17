// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MultiBooleanToVisibilityConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class MultiBooleanToVisibilityConverterTests : MultiConverterTester<MultiBooleanToVisibilityConverter>
{
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible, true, "", true)]
    [TestCase(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, true, "", true)]
    [TestCase(Visibility.Hidden, Visibility.Collapsed, Visibility.Collapsed, Visibility.Hidden, true, "", true)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed, Visibility.Visible, false, "", false)]
    [TestCase(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, false, "", false)]
    [TestCase(Visibility.Collapsed, Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden, false, "", false)]
    [TestCase(Visibility.Collapsed, Visibility.Collapsed, Visibility.Visible, Visibility.Visible, true, "", false)]
    [TestCase(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, true, "", false)]
    [TestCase(Visibility.Collapsed, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, true, "", false)]
    [TestCase(Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Collapsed, null, null)]
    public void Convert_Called_Converts(Visibility allTrueIs, Visibility allFalseIs, Visibility mixedIs, Visibility expected, params object[] values)
    {
        _target.AllTrueIs = allTrueIs;
        _target.AllFalseIs = allFalseIs;
        _target.MixedIs = mixedIs;

        Convert(values, expected);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, Array.Empty<object>()), Throws.TypeOf<NotImplementedException>());
    }
}