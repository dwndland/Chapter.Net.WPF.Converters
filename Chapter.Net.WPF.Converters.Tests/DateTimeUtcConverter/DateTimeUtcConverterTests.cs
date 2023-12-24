// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeUtcConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class DateTimeUtcConverterTests : ConverterTester<DateTimeUtcConverter>
{
    [TestCase(13)]
    [TestCase("Anything")]
    [TestCase(null)]
    public void Convert_WithAnythingButDateOnly_ReturnsDefault(object input)
    {
        Convert(input, default(DateTime));
    }

    [Test]
    public void Convert_WithAnythingButDateOnly_ReturnsEmpty()
    {
        Convert(new DateOnly(2023, 12, 6), default(DateTime));
    }

    [TestCase(true)]
    [TestCase(false)]
    public void Convert_WithFormat_FormatsCorrectly(bool toUniversalTime)
    {
        _target.ToUniversalTime = toUniversalTime;

        var dateTime = DateTime.Now;
        var expectation = toUniversalTime ? dateTime.ToUniversalTime() : dateTime.ToLocalTime();

        Convert(dateTime, expectation);
    }

    [TestCase(13)]
    [TestCase("Anything")]
    [TestCase(null)]
    public void ConvertBack_WithAnythingButDateOnly_ReturnsEmpty(object input)
    {
        ConvertBack(input, default(DateTime));
    }

    [TestCase(true)]
    [TestCase(false)]
    public void ConvertBack_WithFormat_FormatsCorrectly(bool toUniversalTime)
    {
        _target.ToUniversalTime = toUniversalTime;

        var dateTime = DateTime.Now;
        var expectation = toUniversalTime ? dateTime.ToLocalTime() : dateTime.ToUniversalTime();

        ConvertBack(dateTime, expectation);
    }
}