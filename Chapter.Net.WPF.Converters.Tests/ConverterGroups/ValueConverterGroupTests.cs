// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ValueConverterGroupTests.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class ValueConverterGroupTests
{
    [TestCase(2, 2, 2, "04")]
    [TestCase(10, 2, 2, "12")]
    public void Convert_Called_FormatsCorrectly(int variable, int digits, int input, string expectation)
    {
        var target = CreateTarget(variable, digits);

        var result = target.Convert(input, typeof(string), null, CultureInfo.InvariantCulture);

        Assert.That(result, Is.EqualTo(expectation));
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        var target = CreateTarget(2, 2);
        Assert.That(() => target.ConvertBack(1, typeof(object), null, CultureInfo.CurrentCulture), Throws.TypeOf<NotImplementedException>());
    }

    private ValueConverterGroup CreateTarget(int variable, int digits)
    {
        return
        [
            new IntegerMathConverter { Calculation = Calculation.Addition, Variable = variable },
            new IntegerToStringConverter { Digits = digits }
        ];
    }
}