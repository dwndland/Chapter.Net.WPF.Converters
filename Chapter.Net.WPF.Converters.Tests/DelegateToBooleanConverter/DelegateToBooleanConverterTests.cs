// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DelegateToBooleanConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class DelegateToBooleanConverterTests : SingleAndMultiValueConverterTester<DelegateToBooleanConverter>
{
    [Test]
    public void Convert_Called_UsesDelegate()
    {
        _target.ConvertDelegate = input =>
        {
            Assert.That(input, Is.EqualTo(13));
            return true;
        };

        Convert(13, true);
    }

    [Test]
    public void ConvertBack_Called_UsesDelegate()
    {
        _target.ConvertBackDelegate = input =>
        {
            Assert.That(input, Is.EqualTo(true));
            return 13;
        };

        ConvertBack(true, 13);
    }

    [Test]
    public void MultiConvert_Called_UsesDelegate()
    {
        _target.MultiConvertDelegate = input =>
        {
            Assert.That(input, Is.EqualTo(new object[] { 13, 14 }));
            return true;
        };

        MultiConvert([13, 14], true);
    }

    [Test]
    public void MultiConvertBack_Called_UsesDelegate()
    {
        _target.MultiConvertBackDelegate = input =>
        {
            Assert.That(input, Is.EqualTo(true));
            return [13, 14];
        };

        MultiConvertBack(true, [13, 14]);
    }
}