// -----------------------------------------------------------------------------------------------------------------
// <copyright file="SingleAndMultiValueConverterTester.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Linq;
using System.Windows.Data;
using NUnit.Framework;

namespace Chapter.Net.WPF.Converters.Tests;

public class SingleAndMultiValueConverterTester<T> : ConverterTester<T> where T : IValueConverter, IMultiValueConverter, new()
{
    protected void Convert(object value, object expectedResult)
    {
        var result = _target.Convert(value, expectedResult?.GetType(), null, CultureInfo.CurrentCulture);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    protected void MultiConvert(object[] values, object expectedResult)
    {
        var result = _target.Convert(values, expectedResult?.GetType(), null, CultureInfo.CurrentCulture);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    protected void ConvertBack(object value, object expectedResult)
    {
        var result = _target.ConvertBack(value, expectedResult?.GetType(), null, CultureInfo.CurrentCulture);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    protected void MultiConvertBack(object value, object[] expectedResults)
    {
        var result = _target.ConvertBack(value, expectedResults.Select(x => x.GetType()).ToArray(), null, CultureInfo.CurrentCulture);

        Assert.That(result, Is.EqualTo(expectedResults));
    }
}