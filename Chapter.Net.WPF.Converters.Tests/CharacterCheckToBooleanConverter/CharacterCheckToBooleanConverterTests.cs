// -----------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterCheckToBooleanConverterTests.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class CharacterCheckToBooleanConverterTests : SingleAndMultiValueConverterTester<CharacterCheckToBooleanConverter>
{
    [TestCase(CharacterCheckType.IsDigit, true, false, '0', true)]
    [TestCase(CharacterCheckType.IsDigit, false, true, '0', false)]
    [TestCase(CharacterCheckType.IsDigit, null, false, '0', null)]
    [TestCase(CharacterCheckType.IsDigit, true, false, 'a', false)]
    [TestCase(CharacterCheckType.IsDigit, false, true, 'a', true)]
    [TestCase(CharacterCheckType.IsDigit, true, null, 'a', null)]
    [TestCase(CharacterCheckType.IsLetter, true, false, 'a', true)]
    [TestCase(CharacterCheckType.IsLetter, false, true, 'a', false)]
    [TestCase(CharacterCheckType.IsLetter, null, false, 'a', null)]
    [TestCase(CharacterCheckType.IsLetter, true, false, '0', false)]
    [TestCase(CharacterCheckType.IsLetter, false, true, '0', true)]
    [TestCase(CharacterCheckType.IsLetter, true, null, '0', null)]
    [TestCase(CharacterCheckType.IsUpper, true, false, 'A', true)]
    [TestCase(CharacterCheckType.IsUpper, false, true, 'A', false)]
    [TestCase(CharacterCheckType.IsUpper, null, false, 'A', null)]
    [TestCase(CharacterCheckType.IsUpper, true, false, 'a', false)]
    [TestCase(CharacterCheckType.IsUpper, false, true, 'a', true)]
    [TestCase(CharacterCheckType.IsUpper, true, null, 'a', null)]
    [TestCase(CharacterCheckType.IsLower, true, false, 'a', true)]
    [TestCase(CharacterCheckType.IsLower, false, true, 'a', false)]
    [TestCase(CharacterCheckType.IsLower, null, false, 'a', null)]
    [TestCase(CharacterCheckType.IsLower, true, false, 'A', false)]
    [TestCase(CharacterCheckType.IsLower, false, true, 'A', true)]
    [TestCase(CharacterCheckType.IsLower, true, null, 'A', null)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, true, false, 'a', true)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, false, true, 'a', false)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, null, false, 'a', null)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, true, false, '0', true)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, false, true, '0', false)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, null, false, '0', null)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, true, false, '-', false)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, false, true, '-', true)]
    [TestCase(CharacterCheckType.IsLetterOrDigit, true, null, '-', null)]
    public void Convert_Called_Converts(CharacterCheckType checkType, bool? trueIs, bool? falseIs, object input, bool? result)
    {
        _target.CheckType = checkType;
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;

        Convert(input, result);
    }

    [TestCase(CharacterCheckType.IsDigit, true, false, null, true, '0', '1', '2')]
    [TestCase(CharacterCheckType.IsDigit, false, true, null, false, '0', '1', '2')]
    [TestCase(CharacterCheckType.IsDigit, null, false, null, null, '0', '1', '2')]
    [TestCase(CharacterCheckType.IsDigit, true, false, null, false, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsDigit, true, true, null, true, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsDigit, true, null, null, null, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsDigit, true, false, null, null, '0', 'a', '2')]
    [TestCase(CharacterCheckType.IsLetter, true, false, null, true, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLetter, false, true, null, false, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLetter, null, false, null, null, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLetter, true, false, null, false, '0', '0', '0')]
    [TestCase(CharacterCheckType.IsLetter, true, true, null, true, '0', '0', '0')]
    [TestCase(CharacterCheckType.IsLetter, true, null, null, null, '0', '0', '0')]
    [TestCase(CharacterCheckType.IsLetter, true, false, null, null, 'a', '0', 'a')]
    [TestCase(CharacterCheckType.IsUpper, true, false, null, true, 'A', 'A', 'A')]
    [TestCase(CharacterCheckType.IsUpper, false, true, null, false, 'A', 'A', 'A')]
    [TestCase(CharacterCheckType.IsUpper, null, false, null, null, 'A', 'A', 'A')]
    [TestCase(CharacterCheckType.IsUpper, true, false, null, false, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsUpper, true, true, null, true, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsUpper, true, null, null, null, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsUpper, true, false, null, null, 'A', 'a', 'A')]
    [TestCase(CharacterCheckType.IsLower, true, false, null, true, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLower, false, true, null, false, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLower, null, false, null, null, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLower, true, false, null, false, 'A', 'A', 'A')]
    [TestCase(CharacterCheckType.IsLower, true, true, null, true, 'A', 'A', 'A')]
    [TestCase(CharacterCheckType.IsLower, true, null, null, null, 'A', 'A', 'A')]
    [TestCase(CharacterCheckType.IsLower, true, false, null, null, 'a', 'A', 'a')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, true, false, null, true, '0', '1', '2')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, false, true, null, false, '0', '1', '2')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, null, false, null, null, '0', '1', '2')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, true, false, null, true, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, false, true, null, false, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, null, false, null, null, 'a', 'a', 'a')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, true, false, null, true, 'a', '1', 'b')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, false, true, null, false, 'a', '1', 'b')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, null, false, null, null, 'a', '1', 'b')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, true, false, null, false, '-', '-', '-')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, true, true, null, true, '-', '-', '-')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, true, null, null, null, '-', '-', '-')]
    [TestCase(CharacterCheckType.IsLetterOrDigit, true, false, null, null, '0', '-', '2')]
    public void MultiConvert_Called_Converts(CharacterCheckType checkType, bool? trueIs, bool? falseIs, bool? mixedIs, bool? result, params object[] input)
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