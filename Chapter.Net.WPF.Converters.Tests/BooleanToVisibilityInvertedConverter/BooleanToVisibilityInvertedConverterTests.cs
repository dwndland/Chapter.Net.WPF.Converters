// -----------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToVisibilityInvertedConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Windows;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class BooleanToVisibilityInvertedConverterTests : ConverterTester<BooleanToVisibilityInvertedConverter>
{
    [TestCase(false, Visibility.Visible)]
    [TestCase(true, Visibility.Collapsed)]
    [TestCase(14.5, Visibility.Visible)]
    [TestCase(-5, Visibility.Visible)]
    [TestCase("Dummy", Visibility.Visible)]
    [TestCase(null, Visibility.Visible)]
    public void Convert_CalledWithExpectedFormats_Expects(object input, Visibility expected)
    {
        Convert(input, expected);
    }

    [TestCase(Visibility.Visible, false)]
    [TestCase(Visibility.Collapsed, true)]
    [TestCase(14.5, false)]
    [TestCase(-5, false)]
    [TestCase("Dummy", false)]
    [TestCase(null, false)]
    public void ConvertBack_CalledWithExpectedFormats_Expects(object input, object expected)
    {
        ConvertBack(input, expected);
    }
}