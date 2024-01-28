// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DelegateConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class DelegateConverterTests : SingleAndMultiValueConverterTester<DelegateConverter>
{
    [Test]
    public void Convert_Called_UsesDelegate()
    {
        _target.ConvertDelegate = input =>
        {
            Assert.That(input, Is.EqualTo(13));
            return "abc";
        };

        Convert(13, "abc");
    }

    [Test]
    public void ConvertBack_Called_UsesDelegate()
    {
        _target.ConvertBackDelegate = input =>
        {
            Assert.That(input, Is.EqualTo("abc"));
            return 13;
        };

        ConvertBack("abc", 13);
    }

    [Test]
    public void MultiConvert_Called_UsesDelegate()
    {
        _target.MultiConvertDelegate = input =>
        {
            Assert.That(input, Is.EqualTo(new object[] { 13, 14 }));
            return "abc";
        };

        MultiConvert([13, 14], "abc");
    }

    [Test]
    public void MultiConvertBack_Called_UsesDelegate()
    {
        _target.MultiConvertBackDelegate = input =>
        {
            Assert.That(input, Is.EqualTo("abc"));
            return [13, 14];
        };

        MultiConvertBack("abc", [13, 14]);
    }
}