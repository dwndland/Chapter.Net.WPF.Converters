// -----------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterCheckToVisibilityConverterTests.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class CharacterCheckToVisibilityConverterTests : SingleAndMultiValueConverterTester<CharacterCheckToVisibilityConverter>
{
    [TestCase(CharacterCheckType.IsDigit, Visibility.Visible, Visibility.Collapsed, '0', Visibility.Visible)]
    [TestCase(CharacterCheckType.IsDigit, Visibility.Collapsed, Visibility.Visible, '0', Visibility.Collapsed)]
    [TestCase(CharacterCheckType.IsDigit, Visibility.Hidden, Visibility.Collapsed, '0', Visibility.Hidden)]
    [TestCase(CharacterCheckType.IsDigit, Visibility.Visible, Visibility.Collapsed, 'a', Visibility.Collapsed)]
    [TestCase(CharacterCheckType.IsDigit, Visibility.Collapsed, Visibility.Visible, 'a', Visibility.Visible)]
    [TestCase(CharacterCheckType.IsDigit, Visibility.Visible, Visibility.Hidden, 'a', Visibility.Hidden)]
    [TestCase(CharacterCheckType.IsLetter, Visibility.Visible, Visibility.Collapsed, 'a', Visibility.Visible)]
    [TestCase(CharacterCheckType.IsLetter, Visibility.Collapsed, Visibility.Visible, 'a', Visibility.Collapsed)]
    [TestCase(CharacterCheckType.IsLetter, Visibility.Hidden, Visibility.Collapsed, 'a', Visibility.Hidden)]
    [TestCase(CharacterCheckType.IsLetter, Visibility.Visible, Visibility.Collapsed, '0', Visibility.Collapsed)]
    [TestCase(CharacterCheckType.IsLetter, Visibility.Collapsed, Visibility.Visible, '0', Visibility.Visible)]
    [TestCase(CharacterCheckType.IsLetter, Visibility.Visible, Visibility.Hidden, '0', Visibility.Hidden)]
    [TestCase(CharacterCheckType.IsUpper, Visibility.Visible, Visibility.Collapsed, 'A', Visibility.Visible)]
    [TestCase(CharacterCheckType.IsUpper, Visibility.Collapsed, Visibility.Visible, 'A', Visibility.Collapsed)]
    [TestCase(CharacterCheckType.IsUpper, Visibility.Hidden, Visibility.Collapsed, 'A', Visibility.Hidden)]
    [TestCase(CharacterCheckType.IsUpper, Visibility.Visible, Visibility.Collapsed, 'a', Visibility.Collapsed)]
    [TestCase(CharacterCheckType.IsUpper, Visibility.Collapsed, Visibility.Visible, 'a', Visibility.Visible)]
    [TestCase(CharacterCheckType.IsUpper, Visibility.Visible, Visibility.Hidden, 'a', Visibility.Hidden)]
    [TestCase(CharacterCheckType.IsLower, Visibility.Visible, Visibility.Collapsed, 'a', Visibility.Visible)]
    [TestCase(CharacterCheckType.IsLower, Visibility.Collapsed, Visibility.Visible, 'a', Visibility.Collapsed)]
    [TestCase(CharacterCheckType.IsLower, Visibility.Hidden, Visibility.Collapsed, 'a', Visibility.Hidden)]
    [TestCase(CharacterCheckType.IsLower, Visibility.Visible, Visibility.Collapsed, 'A', Visibility.Collapsed)]
    [TestCase(CharacterCheckType.IsLower, Visibility.Collapsed, Visibility.Visible, 'A', Visibility.Visible)]
    [TestCase(CharacterCheckType.IsLower, Visibility.Visible, Visibility.Hidden, 'A', Visibility.Hidden)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Visible, Visibility.Collapsed, 'a', Visibility.Visible)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Collapsed, Visibility.Visible, 'a', Visibility.Collapsed)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Hidden, Visibility.Collapsed, 'a', Visibility.Hidden)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Visible, Visibility.Collapsed, '0', Visibility.Visible)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Collapsed, Visibility.Visible, '0', Visibility.Collapsed)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Hidden, Visibility.Collapsed, '0', Visibility.Hidden)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Visible, Visibility.Collapsed, '-', Visibility.Collapsed)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Collapsed, Visibility.Visible, '-', Visibility.Visible)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Visible, Visibility.Hidden, '-', Visibility.Hidden)]
    public void Convert_Called_Converts(CharacterCheckType checkType, Visibility trueIs, Visibility falseIs, object input, Visibility result)
    {
        _target.CheckType = checkType;
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;

        Convert(input, result);
    }

    [TestCase(CharacterCheckType.IsDigit, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Visible, '0', '1', '2')]
    [TestCase(CharacterCheckType.IsDigit, Visibility.Collapsed, Visibility.Visible, Visibility.Hidden, Visibility.Collapsed, '0', '1', '2')]
    [TestCase(CharacterCheckType.IsDigit, Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, '0', '1', '2')]
    [TestCase(CharacterCheckType.IsDigit, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Collapsed, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsDigit, Visibility.Visible, Visibility.Visible, Visibility.Hidden, Visibility.Visible, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsDigit, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsDigit, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, '0', 'a', '2')]
    [TestCase(CharacterCheckType.IsLetter, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Visible, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLetter, Visibility.Collapsed, Visibility.Visible, Visibility.Hidden, Visibility.Collapsed, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLetter, Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLetter, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Collapsed, '0', '0', '0')]
    [TestCase(CharacterCheckType.IsLetter, Visibility.Visible, Visibility.Visible, Visibility.Hidden, Visibility.Visible, '0', '0', '0')]
    [TestCase(CharacterCheckType.IsLetter, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, '0', '0', '0')]
    [TestCase(CharacterCheckType.IsLetter, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, 'a', '0', 'a')]
    [TestCase(CharacterCheckType.IsUpper, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Visible, 'A', 'A', 'A')]
    [TestCase(CharacterCheckType.IsUpper, Visibility.Collapsed, Visibility.Visible, Visibility.Hidden, Visibility.Collapsed, 'A', 'A', 'A')]
    [TestCase(CharacterCheckType.IsUpper, Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, 'A', 'A', 'A')]
    [TestCase(CharacterCheckType.IsUpper, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Collapsed, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsUpper, Visibility.Visible, Visibility.Visible, Visibility.Hidden, Visibility.Visible, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsUpper, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsUpper, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, 'A', 'a', 'A')]
    [TestCase(CharacterCheckType.IsLower, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Visible, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLower, Visibility.Collapsed, Visibility.Visible, Visibility.Hidden, Visibility.Collapsed, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLower, Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLower, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Collapsed, 'A', 'A', 'A')]
    [TestCase(CharacterCheckType.IsLower, Visibility.Visible, Visibility.Visible, Visibility.Hidden, Visibility.Visible, 'A', 'A', 'A')]
    [TestCase(CharacterCheckType.IsLower, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, 'A', 'A', 'A')]
    [TestCase(CharacterCheckType.IsLower, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, 'a', 'A', 'a')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Visible, '0', '1', '2')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Collapsed, Visibility.Visible, Visibility.Hidden, Visibility.Collapsed, '0', '1', '2')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, '0', '1', '2')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Visible, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Collapsed, Visibility.Visible, Visibility.Hidden, Visibility.Collapsed, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Visible, 'a', '1', 'b')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Collapsed, Visibility.Visible, Visibility.Hidden, Visibility.Collapsed, 'a', '1', 'b')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Hidden, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, 'a', '1', 'b')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Collapsed, '-', '-', '-')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Visible, Visibility.Visible, Visibility.Hidden, Visibility.Visible, '-', '-', '-')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Visible, Visibility.Hidden, Visibility.Hidden, Visibility.Hidden, '-', '-', '-')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, Visibility.Visible, Visibility.Collapsed, Visibility.Hidden, Visibility.Hidden, '0', '-', '2')]
    public void MultiConvert_Called_Converts(CharacterCheckType checkType, Visibility trueIs, Visibility falseIs, Visibility mixedIs, Visibility result, params object[] input)
    {
        _target.CheckType = checkType;
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;
        _target.MixedIs = mixedIs;

        MultiConvert(input, result);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, ""), Throws.TypeOf<NotImplementedException>());
    }

    [Test]
    public void MultiConvertBack_Called_RaisesException()
    {
        Assert.That(() => MultiConvertBack(null, []), Throws.TypeOf<NotImplementedException>());
    }
}