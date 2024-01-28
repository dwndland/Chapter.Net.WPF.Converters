// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IsNullToBooleanConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class IsNullToBooleanConverterTests : SingleAndMultiValueConverterTester<IsNullToBooleanConverter>
{
    [TestCase(true, false, null, true)]
    [TestCase(false, true, null, false)]
    [TestCase(null, true, null, null)]
    [TestCase(true, false, "", false)]
    [TestCase(false, true, "", true)]
    [TestCase(false, null, "", null)]
    public void Convert_Called_Converts(bool? nullIs, bool? notNullIs, object input, bool? result)
    {
        _target.NullIs = nullIs;
        _target.NotNullIs = notNullIs;

        Convert(input, result);
    }

    [TestCase(true, false, null, true, null, null, null)]
    [TestCase(false, true, null, false, null, null, null)]
    [TestCase(null, true, null, null, null, null, null)]
    [TestCase(true, false, null, false, "", "", "")]
    [TestCase(false, true, null, true, "", "", "")]
    [TestCase(false, null, null, null, "", "", "")]
    [TestCase(true, false, null, null, "", null, "")]
    [TestCase(true, false, true, true, "", null, "")]
    [TestCase(true, false, false, false, "", null, "")]
    public void MultiConvert_Called_Converts(bool? nullIs, bool? notNullIs, bool? mixedIs, bool? result, params object[] input)
    {
        _target.NullIs = nullIs;
        _target.NotNullIs = notNullIs;
        _target.MixedIs = mixedIs;

        MultiConvert(input, result);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, null), Throws.TypeOf<NotImplementedException>());
    }

    [Test]
    public void MultiConvertBack_Called_RaisesException()
    {
        Assert.That(() => MultiConvertBack(null, Array.Empty<object>()), Throws.TypeOf<NotImplementedException>());
    }
}