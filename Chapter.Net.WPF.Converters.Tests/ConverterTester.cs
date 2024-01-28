// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterTester.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.Globalization;
using NUnit.Framework;

namespace Chapter.Net.WPF.Converters.Tests;

public class ConverterTester<T> where T : new()
{
    private CultureInfo _originalCulture;
    protected T _target;

    [SetUp]
    public void Setup()
    {
        _target = new T();
    }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _originalCulture = CultureInfo.CurrentCulture;
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        CultureInfo.CurrentCulture = _originalCulture;
    }
}