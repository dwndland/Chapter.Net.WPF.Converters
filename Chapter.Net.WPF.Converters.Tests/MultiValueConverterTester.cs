// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MultiValueConverterTester.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Linq;
using System.Windows.Data;
using NUnit.Framework;

namespace Chapter.Net.WPF.Converters.Tests;

public class MultiValueConverterTester<T> : ConverterTester<T> where T : IMultiValueConverter, new()
{
    protected void Convert(object[] values, object expectedResult)
    {
        Convert(values, null, expectedResult);
    }

    protected void Convert(object[] values, object parameter, object expectedResult)
    {
        var result = _target.Convert(values, expectedResult?.GetType(), parameter, CultureInfo.CurrentCulture);

        Assert.That(result, Is.EqualTo(expectedResult));
    }

    protected void ConvertBack(object value, object[] expectedResults)
    {
        ConvertBack(value, null, expectedResults);
    }

    protected void ConvertBack(object value, object parameter, object[] expectedResults)
    {
        var result = _target.ConvertBack(value, expectedResults.Select(x => x.GetType()).ToArray(), parameter, CultureInfo.CurrentCulture);

        Assert.That(result, Is.EqualTo(expectedResults));
    }
}