// -----------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToVisibilityConverterTests.cs" company="dwndland">
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
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, true, Visibility.Visible)]
    [TestCase(Visibility.Collapsed, Visibility.Collapsed, Visibility.Hidden, true, Visibility.Collapsed)]
    [TestCase(Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden, true, Visibility.Hidden)]
    [TestCase(Visibility.Visible, Visibility.Visible, Visibility.Hidden, false, Visibility.Visible)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, false, Visibility.Collapsed)]
    [TestCase(Visibility.Visible, Visibility.Hidden, Visibility.Hidden, false, Visibility.Hidden)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Visible, null, Visibility.Visible)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, null, Visibility.Collapsed)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, null, Visibility.Hidden)]
    public void Convert_Called_Converts(Visibility trueIs, Visibility falseIs, Visibility nullIs, object input, Visibility expectation)
    {
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;
        _target.NullIs = nullIs;

        Convert(input, expectation);
    }

    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, Visibility.Visible, true, true, true)]
    [TestCase(Visibility.Collapsed, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, Visibility.Collapsed, true, true, true)]
    [TestCase(Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, true, true, true)]
    [TestCase(Visibility.Visible, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, Visibility.Visible, false, false, false)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, Visibility.Collapsed, false, false, false)]
    [TestCase(Visibility.Visible, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, false, false, false)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Visible, Visibility.Hidden, Visibility.Visible, null, null, null)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Hidden, Visibility.Collapsed, null, null, null)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, null, null, null)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Visible, Visibility.Visible, null, true, false)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Collapsed, Visibility.Collapsed, null, true, false)]
    [TestCase(Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, null, true, false)]
    public void Convert_Called_Converts(Visibility trueIs, Visibility falseIs, Visibility nullIs, Visibility mixedIs, Visibility expectation, params object[] input)
    {
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;
        _target.NullIs = nullIs;
        _target.MixedIs = mixedIs;

        MultiConvert(input, expectation);
    }

    [TestCase(Visibility.Visible, Visibility.Hidden, Visibility.Hidden, Visibility.Visible, true)]
    [TestCase(Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, Visibility.Collapsed, true)]
    [TestCase(Visibility.Hidden, Visibility.Visible, Visibility.Visible, Visibility.Hidden, true)]
    [TestCase(Visibility.Hidden, Visibility.Visible, Visibility.Hidden, Visibility.Visible, false)]
    [TestCase(Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden, Visibility.Collapsed, false)]
    [TestCase(Visibility.Visible, Visibility.Hidden, Visibility.Visible, Visibility.Hidden, false)]
    [TestCase(Visibility.Hidden, Visibility.Hidden, Visibility.Visible, Visibility.Visible, null)]
    [TestCase(Visibility.Hidden, Visibility.Hidden, Visibility.Collapsed, Visibility.Collapsed, null)]
    [TestCase(Visibility.Visible, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, null)]
    public void ConvertBack_Called_Converts(Visibility trueIs, Visibility falseIs, Visibility nullIs, object input, object expectation)
    {
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;
        _target.NullIs = nullIs;

        ConvertBack(input, expectation);
    }

    [Test]
    public void MultiConvertBack_Called_RaisesException()
    {
        Assert.That(() => MultiConvertBack(null, []), Throws.TypeOf<NotImplementedException>());
    }
}