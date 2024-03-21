// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MultiValueConverterGroupTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class MultiValueConverterGroupTests
{
    [Test]
    public void Convert_CalledWithNullValues_ReturnsNull()
    {
        var target = CreateTarget("-", 20);

        var result = target.Convert(null, null, null, CultureInfo.CurrentCulture);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void Convert_CalledButEntryConverterIsNull_ThrowsException()
    {
        var target = CreateTarget("-", 20);
        target.EntryConverter = null;

        Assert.That(() => target.Convert(["1", "2"], typeof(bool), null, CultureInfo.CurrentCulture), Throws.TypeOf<InvalidOperationException>());
    }

    [TestCase("-", 10, false, "12345", "678")]
    [TestCase("-", 10, false, "12345", "6789")]
    [TestCase("-", 10, true, "12345", "67890")]
    [TestCase("--", 10, true, "12345", "67890")]
    public void Convert_Called_FormatsCorrectly(string separator, int length, bool expectation, params object[] input)
    {
        var target = CreateTarget(separator, length);

        var result = target.Convert(input, typeof(bool), null, CultureInfo.InvariantCulture);

        Assert.That(result, Is.EqualTo(expectation));
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        var target = CreateTarget("-", 20);
        Assert.That(() => target.ConvertBack(1, null, null, CultureInfo.CurrentCulture), Throws.TypeOf<NotImplementedException>());
    }

    private MultiValueConverterGroup CreateTarget(string separator, int length)
    {
        var group = new MultiValueConverterGroup
        {
            EntryConverter = new ConcatenateStringConverter { Separator = separator }
        };
        group.Add(new StringCheckToBooleanConverter { CheckType = StringCheckType.IsLongerThan, Variable = length });
        return group;
    }
}