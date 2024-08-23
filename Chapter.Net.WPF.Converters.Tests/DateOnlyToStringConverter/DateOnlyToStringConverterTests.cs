// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DateOnlyToStringConverterTests.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class DateOnlyToStringConverterTests : ValueConverterTester<DateOnlyToStringConverter>
{
    [TestCase(13)]
    [TestCase("Anything")]
    [TestCase(null)]
    public void Convert_WithAnythingButDateOnly_ReturnsEmpty(object input)
    {
        Convert(input, string.Empty);
    }

    [Test]
    public void Convert_WithAnythingButDateOnly_ReturnsEmpty()
    {
        Convert(DateTime.Now, string.Empty);
    }

    [Test]
    [TestCase("d")]
    [TestCase("D")]
    [TestCase("")]
    public void Convert_WithFormatterLowerD_FormatsCorrectly(string format)
    {
        _target.Format = DateOnlyFormat.Formatter;
        _target.Formatter = format;

        var date = new DateOnly(2023, 12, 06);

        CultureInfo.CurrentCulture = new CultureInfo("de-DE");
        Convert(date, date.ToString(format, new CultureInfo("de-DE")));

        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        Convert(date, date.ToString(format, new CultureInfo("en-US")));
    }

    [Test]
    public void Convert_WithInvalidDateOnlyFormat_ThrowsException()
    {
        _target.Format = DateOnlyFormat.Formatter;
        _target.Formatter = "f";

        var date = new DateOnly(2023, 12, 06);

        Assert.That(() => Convert(date, null), Throws.TypeOf<FormatException>());
    }

    [Test]
    public void Convert_WithShortDateString_FormatsCorrectly()
    {
        _target.Format = DateOnlyFormat.ShortDateString;

        var date = new DateOnly(2023, 12, 06);

        CultureInfo.CurrentCulture = new CultureInfo("de-DE");
        Convert(date, date.ToShortDateString());

        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        Convert(date, date.ToShortDateString());
    }

    [Test]
    public void Convert_WithLongDateString_FormatsCorrectly()
    {
        _target.Format = DateOnlyFormat.LongDateString;

        var date = new DateOnly(2023, 12, 06);

        CultureInfo.CurrentCulture = new CultureInfo("de-DE");
        Convert(date, date.ToLongDateString());

        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        Convert(date, date.ToLongDateString());
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, null), Throws.TypeOf<NotImplementedException>());
    }
}