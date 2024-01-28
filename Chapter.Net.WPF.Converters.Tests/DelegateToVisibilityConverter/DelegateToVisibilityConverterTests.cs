// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DelegateToVisibilityConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class DelegateToVisibilityConverterTests : SingleAndMultiValueConverterTester<DelegateToVisibilityConverter>
{
    [Test]
    public void Convert_Called_UsesDelegate()
    {
        _target.ConvertDelegate = input =>
        {
            Assert.That(input, Is.EqualTo(13));
            return Visibility.Visible;
        };

        Convert(13, Visibility.Visible);
    }

    [Test]
    public void ConvertBack_Called_UsesDelegate()
    {
        _target.ConvertBackDelegate = input =>
        {
            Assert.That(input, Is.EqualTo(Visibility.Visible));
            return 13;
        };

        ConvertBack(Visibility.Visible, 13);
    }

    [Test]
    public void MultiConvert_Called_UsesDelegate()
    {
        _target.MultiConvertDelegate = input =>
        {
            Assert.That(input, Is.EqualTo(new object[] { 13, 14 }));
            return Visibility.Visible;
        };

        MultiConvert([13, 14], Visibility.Visible);
    }

    [Test]
    public void MultiConvertBack_Called_UsesDelegate()
    {
        _target.MultiConvertBackDelegate = input =>
        {
            Assert.That(input, Is.EqualTo(Visibility.Visible));
            return [13, 14];
        };

        MultiConvertBack(Visibility.Visible, [13, 14]);
    }
}