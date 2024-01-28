// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ValueConverterTester.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Windows.Data;
using NUnit.Framework;

namespace Chapter.Net.WPF.Converters.Tests;

public class ValueConverterTester<T> : ConverterTester<T> where T : IValueConverter, new()
{
    protected void Convert(object value, object expectedResult)
    {
        var result = _target.Convert(value, expectedResult?.GetType(), null, CultureInfo.CurrentCulture);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    protected void ConvertBack(object value, object expectedResult)
    {
        var result = _target.ConvertBack(value, expectedResult?.GetType(), null, CultureInfo.CurrentCulture);

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}