// -----------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToVisibilityConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class BooleanToVisibilityConverterTests : SingleAndMultiValueConverterTester<BooleanToVisibilityConverter>
{
    [TestCase(Visibility.Visible, Visibility.Collapsed, true, Visibility.Visible)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, true, Visibility.Collapsed)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, "", Visibility.Collapsed)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, false, Visibility.Collapsed)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, false, Visibility.Visible)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, "", Visibility.Visible)]
    public void Convert_Called_Converts(Visibility trueIs, Visibility falseIs, object input, Visibility expectation)
    {
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;

        Convert(input, expectation);
    }

    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Visible, true, true, true)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, Visibility.Hidden, Visibility.Collapsed, true, true, true)]
    [TestCase(Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, true, true, true)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Collapsed, false, false, false)]
    [TestCase(Visibility.Visible, Visibility.Visible, Visibility.Hidden, Visibility.Visible, false, false, false)]
    [TestCase(Visibility.Visible, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, false, false, false)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, false, true, false)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Visible, Visibility.Visible, false, true, false)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, false, true, false)]
    public void Convert_Called_Converts(Visibility trueIs, Visibility falseIs, Visibility mixedIs, Visibility expectation, params object[] input)
    {
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;
        _target.MixedIs = mixedIs;

        MultiConvert(input, expectation);
    }

    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Visible, true)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, Visibility.Collapsed, true)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, "", false)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, false)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, Visibility.Visible, false)]
    [TestCase(Visibility.Collapsed, Visibility.Visible, "", false)]
    public void ConvertBack_Called_Converts(Visibility trueIs, Visibility falseIs, object input, object expectation)
    {
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;

        ConvertBack(input, expectation);
    }

    [Test]
    public void MultiConvertBack_Called_RaisesException()
    {
        Assert.That(() => MultiConvertBack(null, []), Throws.TypeOf<NotImplementedException>());
    }
}