// -----------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToBooleanConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class BooleanToBooleanConverterTests : SingleAndMultiValueConverterTester<BooleanToBooleanConverter>
{
    [TestCase(true, true, true, true)]
    [TestCase(false, true, true, false)]
    [TestCase(null, true, true, null)]
    [TestCase(true, true, false, true)]
    [TestCase(true, false, false, false)]
    [TestCase(true, null, false, null)]
    [TestCase(true, true, "", true)]
    [TestCase(true, true, 15, true)]
    [TestCase(true, true, null, true)]
    [TestCase(true, false, "", false)]
    [TestCase(true, false, 15, false)]
    [TestCase(true, false, null, false)]
    [TestCase(true, null, "", null)]
    [TestCase(true, null, 15, null)]
    [TestCase(true, null, null, null)]
    public void Convert_Called_Converts(bool? trueIs, bool? falseIs, object input, bool? expectation)
    {
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;

        Convert(input, expectation);
    }

    [TestCase(true, true, true, true, true, true, true)]
    [TestCase(false, true, true, false, true, true, true)]
    [TestCase(null, true, true, null, true, true, true)]
    [TestCase(true, true, true, true, false, false, false)]
    [TestCase(true, false, true, false, false, false, false)]
    [TestCase(true, null, true, null, false, false, false)]
    [TestCase(true, true, true, true, false, true, false)]
    [TestCase(true, true, false, false, false, true, false)]
    [TestCase(true, true, null, null, false, true, false)]
    [TestCase(true, false, null, true, true, "", true)]
    [TestCase(true, false, null, false, false, "", false)]
    [TestCase(true, false, null, null, true, "", false)]
    public void MultiConvert_Called_Converts(bool? trueIs, bool? falseIs, bool? mixedIs, bool? expectation, params object[] input)
    {
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;
        _target.MixedIs = mixedIs;

        MultiConvert(input, expectation);
    }
}