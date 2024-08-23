// -----------------------------------------------------------------------------------------------------------------
// <copyright file="TimeOnlyToStringConverterTests.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class TimeOnlyToStringConverterTests : ValueConverterTester<TimeOnlyToStringConverter>
{
    [TestCase(13)]
    [TestCase("Anything")]
    [TestCase(null)]
    public void Convert_WithAnythingButTimeOnly_ReturnsEmpty(object input)
    {
        Convert(input, string.Empty);
    }

    [Test]
    public void Convert_WithAnythingButTimeOnly_ReturnsEmpty()
    {
        Convert(DateTime.Now, string.Empty);
    }

    [Test]
    [TestCase("t")]
    [TestCase("T")]
    [TestCase("")]
    public void Convert_WithFormatterLowerD_FormatsCorrectly(string format)
    {
        _target.Format = TimeOnlyFormat.Formatter;
        _target.Formatter = format;

        var time = new TimeOnly(20, 39, 45);

        CultureInfo.CurrentCulture = new CultureInfo("de-DE");
        Convert(time, time.ToString(format, new CultureInfo("de-DE")));

        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        Convert(time, time.ToString(format, new CultureInfo("en-US")));
    }

    [Test]
    public void Convert_WithInvalidTimeOnlyFormat_ThrowsException()
    {
        _target.Format = TimeOnlyFormat.Formatter;
        _target.Formatter = "f";

        var time = new TimeOnly(20, 39, 45);

        Assert.That(() => Convert(time, null), Throws.TypeOf<FormatException>());
    }

    [Test]
    public void Convert_WithShortTimeString_FormatsCorrectly()
    {
        _target.Format = TimeOnlyFormat.ToShortTimeString;

        var time = new TimeOnly(20, 39, 45);

        CultureInfo.CurrentCulture = new CultureInfo("de-DE");
        Convert(time, time.ToShortTimeString());

        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        Convert(time, time.ToShortTimeString());
    }

    [Test]
    public void Convert_WithLongTimeString_FormatsCorrectly()
    {
        _target.Format = TimeOnlyFormat.ToLongTimeString;

        var time = new TimeOnly(20, 39, 45);

        CultureInfo.CurrentCulture = new CultureInfo("de-DE");
        Convert(time, time.ToLongTimeString());

        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        Convert(time, time.ToLongTimeString());
    }


    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, null), Throws.TypeOf<NotImplementedException>());
    }
}