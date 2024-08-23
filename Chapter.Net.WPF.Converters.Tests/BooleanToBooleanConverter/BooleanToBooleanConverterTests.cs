// -----------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToBooleanConverterTests.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class BooleanToBooleanConverterTests : SingleAndMultiValueConverterTester<BooleanToBooleanConverter>
{
    [TestCase(true, true, null, true, true)]
    [TestCase(false, true, null, true, false)]
    [TestCase(null, true, null, true, null)]
    [TestCase(true, true, null, false, true)]
    [TestCase(true, false, null, false, false)]
    [TestCase(true, null, null, false, null)]
    [TestCase(true, false, true, null, true)]
    [TestCase(true, false, false, null, false)]
    [TestCase(true, false, null, null, null)]
    [TestCase(true, true, null, "", true)]
    [TestCase(true, false, null, "", false)]
    [TestCase(true, null, null, "", null)]
    [TestCase(true, true, null, 15, true)]
    [TestCase(true, false, null, 15, false)]
    [TestCase(true, null, null, 15, null)]
    public void Convert_Called_Converts(bool? trueIs, bool? falseIs, bool? nullIs, object input, bool? expectation)
    {
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;
        _target.NullIs = nullIs;

        Convert(input, expectation);
    }

    [TestCase(true, true, null, true, true)]
    [TestCase(false, true, null, true, false)]
    [TestCase(null, true, null, true, null)]
    [TestCase(true, true, null, false, true)]
    [TestCase(true, false, null, false, false)]
    [TestCase(true, null, null, false, null)]
    [TestCase(true, false, true, null, true)]
    [TestCase(true, false, false, null, false)]
    [TestCase(true, false, null, null, null)]
    [TestCase(true, true, null, "", true)]
    [TestCase(true, false, null, "", false)]
    [TestCase(true, null, null, "", null)]
    [TestCase(true, true, null, 15, true)]
    [TestCase(true, false, null, 15, false)]
    [TestCase(true, null, null, 15, null)]
    public void ConvertBack_Called_Converts(bool? trueIs, bool? falseIs, bool? nullIs, object input, bool? expectation)
    {
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;
        _target.NullIs = nullIs;

        ConvertBack(input, expectation);
    }

    [TestCase(true, true, null, false, true, true, true, true)]
    [TestCase(false, true, null, false, false, true, true, true)]
    [TestCase(null, true, null, false, null, true, true, true)]
    [TestCase(true, true, null, false, true, false, false, false)]
    [TestCase(true, false, null, false, false, false, false, false)]
    [TestCase(true, null, null, false, null, false, false, false)]
    [TestCase(true, false, true, false, true, null, null, null)]
    [TestCase(true, false, false, false, false, null, null, null)]
    [TestCase(true, false, null, false, null, null, null, null)]
    [TestCase(true, false, null, true, true, false, true, null)]
    [TestCase(true, false, null, false, false, false, true, null)]
    [TestCase(true, false, null, null, null, false, true, null)]
    [TestCase(true, false, null, true, true, true, "", true)]
    [TestCase(true, false, null, false, false, false, "", false)]
    [TestCase(true, false, null, null, null, true, "", false)]
    public void MultiConvert_Called_Converts(bool? trueIs, bool? falseIs, bool? nullIs, bool? mixedIs, bool? expectation, params object[] input)
    {
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;
        _target.NullIs = nullIs;
        _target.MixedIs = mixedIs;

        MultiConvert(input, expectation);
    }

    [Test]
    public void MultiConvertBack_Called_RaisesException()
    {
        Assert.That(() => MultiConvertBack(null, []), Throws.TypeOf<NotImplementedException>());
    }
}