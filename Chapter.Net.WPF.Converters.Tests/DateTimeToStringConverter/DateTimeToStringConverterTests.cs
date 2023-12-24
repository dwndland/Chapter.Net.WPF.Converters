// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeToStringConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class DateTimeToStringConverterTests : ConverterTester<DateTimeToStringConverter>
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
        Convert(new DateOnly(2023, 12, 6), string.Empty);
    }

    [TestCase("d")]
    [TestCase("D")]
    [TestCase("f")]
    [TestCase("F")]
    [TestCase("g")]
    [TestCase("G")]
    [TestCase("m")]
    [TestCase("o")]
    [TestCase("R")]
    [TestCase("s")]
    [TestCase("t")]
    [TestCase("T")]
    [TestCase("u")]
    [TestCase("U")]
    [TestCase("y")]
    [TestCase("yyyy-MM-dd HH:mm:ss")]
    [TestCase("")]
    public void Convert_WithFormatterLowerD_FormatsCorrectly(string format)
    {
        _target.Format = DateTimeFormat.Formatter;
        _target.Formatter = format;

        var dateTime = DateTime.Now;

        CultureInfo.CurrentCulture = new CultureInfo("de-DE");
        Convert(dateTime, dateTime.ToString(format, new CultureInfo("de-DE")));

        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        Convert(dateTime, dateTime.ToString(format, new CultureInfo("en-US")));
    }

    [Test]
    public void Convert_WithInvalidDateOnlyFormat_ThrowsException()
    {
        _target.Format = DateTimeFormat.Formatter;
        _target.Formatter = "z";

        var dateTime = DateTime.Now;

        Assert.That(() => Convert(dateTime, null), Throws.TypeOf<FormatException>());
    }

    [TestCase(true, false, DateTimeFormat.ShortTimePattern)]
    [TestCase(true, false, DateTimeFormat.LongTimePattern)]
    [TestCase(true, false, DateTimeFormat.ShortDatePattern)]
    [TestCase(true, false, DateTimeFormat.LongDatePattern)]
    [TestCase(true, false, DateTimeFormat.FullDateTimePattern)]
    [TestCase(true, false, DateTimeFormat.ShortDateString)]
    [TestCase(true, false, DateTimeFormat.LongDateString)]
    [TestCase(true, false, DateTimeFormat.ShortTimeString)]
    [TestCase(true, false, DateTimeFormat.LongTimeString)]
    [TestCase(false, true, DateTimeFormat.ShortTimePattern)]
    [TestCase(false, true, DateTimeFormat.LongTimePattern)]
    [TestCase(false, true, DateTimeFormat.ShortDatePattern)]
    [TestCase(false, true, DateTimeFormat.LongDatePattern)]
    [TestCase(false, true, DateTimeFormat.FullDateTimePattern)]
    [TestCase(false, true, DateTimeFormat.ShortDateString)]
    [TestCase(false, true, DateTimeFormat.LongDateString)]
    [TestCase(false, true, DateTimeFormat.ShortTimeString)]
    [TestCase(false, true, DateTimeFormat.LongTimeString)]
    public void Convert_WithFormat_FormatsCorrectly(bool toLocalTime, bool toUniversalTime, DateTimeFormat format)
    {
        _target.Format = format;
        _target.ToLocalTime = toLocalTime;
        _target.ToUniversalTime = toUniversalTime;

        var dateTime = DateTime.Now;

        CultureInfo.CurrentCulture = new CultureInfo("de-DE");
        var expectation = CreateExpectation(dateTime, toLocalTime, toUniversalTime, format);
        Convert(dateTime, expectation);

        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        expectation = CreateExpectation(dateTime, toLocalTime, toUniversalTime, format);
        Convert(dateTime, expectation);
    }

    private string CreateExpectation(DateTime dateTime, bool toLocalTime, bool toUniversalTime, DateTimeFormat format)
    {
        if (toLocalTime)
            dateTime = dateTime.ToLocalTime();
        else if (toUniversalTime)
            dateTime = dateTime.ToUniversalTime();

        return format switch
        {
            DateTimeFormat.ShortTimePattern => dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern, CultureInfo.CurrentCulture),
            DateTimeFormat.LongTimePattern => dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern, CultureInfo.CurrentCulture),
            DateTimeFormat.ShortDatePattern => dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern, CultureInfo.CurrentCulture),
            DateTimeFormat.LongDatePattern => dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern, CultureInfo.CurrentCulture),
            DateTimeFormat.FullDateTimePattern => dateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern, CultureInfo.CurrentCulture),
            DateTimeFormat.ShortDateString => dateTime.ToShortDateString(),
            DateTimeFormat.LongDateString => dateTime.ToLongDateString(),
            DateTimeFormat.ShortTimeString => dateTime.ToShortTimeString(),
            DateTimeFormat.LongTimeString => dateTime.ToLongTimeString(),
            _ => dateTime.ToString(CultureInfo.CurrentCulture)
        };
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, null), Throws.TypeOf<NotImplementedException>());
    }
}