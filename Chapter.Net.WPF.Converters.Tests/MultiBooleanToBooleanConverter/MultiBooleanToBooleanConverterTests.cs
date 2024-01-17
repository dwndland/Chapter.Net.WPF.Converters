// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MultiBooleanToBooleanConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class MultiBooleanToBooleanConverterTests : MultiConverterTester<MultiBooleanToBooleanConverter>
{
    [TestCase(true, false, false, true, true, "", true)]
    [TestCase(false, false, false, false, true, "", true)]
    [TestCase(null, false, false, null, true, "", true)]
    [TestCase(false, true, false, true, false, "", false)]
    [TestCase(false, false, false, false, false, "", false)]
    [TestCase(false, null, false, null, false, "", false)]
    [TestCase(false, false, true, true, true, "", false)]
    [TestCase(false, false, false, false, true, "", false)]
    [TestCase(false, false, null, null, true, "", false)]
    [TestCase(null, null, null, false, null, null)]
    public void Convert_Called_Converts(bool? allTrueIs, bool? allFalseIs, bool? mixedIs, bool? expected, params object[] values)
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