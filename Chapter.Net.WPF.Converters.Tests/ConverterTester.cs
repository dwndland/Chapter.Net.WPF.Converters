// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterTester.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Windows.Data;
using NUnit.Framework;

namespace Chapter.Net.WPF.Converters.Tests;

public class ConverterTester<T> : TesterBase<T> where T : IValueConverter, new()
{
    protected void Convert(object value, object expectedResult)
    {
        Convert(value, null, expectedResult);
    }

    protected void Convert(object value, object parameter, object expectedResult)
    {
        var result = _target.Convert(value, expectedResult?.GetType(), parameter, CultureInfo.CurrentCulture);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    protected void ConvertBack(object value, object expectedResult)
    {
        ConvertBack(value, null, expectedResult);
    }

    protected void ConvertBack(object value, object parameter, object expectedResult)
    {
        var result = _target.ConvertBack(value, expectedResult?.GetType(), parameter, CultureInfo.CurrentCulture);

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}