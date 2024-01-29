﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="StringCheckToBooleanConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class StringCheckToBooleanConverterTests : SingleAndMultiValueConverterTester<StringCheckToBooleanConverter>
{
    [TestCase(StringCheckType.IsNullOrWhitespace, true, false, 0, null, true)]
    [TestCase(StringCheckType.IsNullOrWhitespace, false, false, 0, null, false)]
    [TestCase(StringCheckType.IsNullOrWhitespace, null, false, 0, null, null)]
    [TestCase(StringCheckType.IsNullOrWhitespace, true, false, 0, "", true)]
    [TestCase(StringCheckType.IsNullOrWhitespace, false, false, 0, "", false)]
    [TestCase(StringCheckType.IsNullOrWhitespace, null, false, 0, "", null)]
    [TestCase(StringCheckType.IsNullOrWhitespace, true, false, 0, "  ", true)]
    [TestCase(StringCheckType.IsNullOrWhitespace, false, false, 0, "  ", false)]
    [TestCase(StringCheckType.IsNullOrWhitespace, null, false, 0, "  ", null)]
    [TestCase(StringCheckType.IsNullOrWhitespace, true, false, 0, "a", false)]
    [TestCase(StringCheckType.IsNullOrWhitespace, true, true, 0, "a", true)]
    [TestCase(StringCheckType.IsNullOrWhitespace, true, null, 0, "a", null)]
    [TestCase(StringCheckType.IsNullOrEmpty, true, false, 0, null, true)]
    [TestCase(StringCheckType.IsNullOrEmpty, false, false, 0, null, false)]
    [TestCase(StringCheckType.IsNullOrEmpty, null, false, 0, null, null)]
    [TestCase(StringCheckType.IsNullOrEmpty, true, false, 0, "", true)]
    [TestCase(StringCheckType.IsNullOrEmpty, false, false, 0, "", false)]
    [TestCase(StringCheckType.IsNullOrEmpty, null, false, 0, "", null)]
    [TestCase(StringCheckType.IsNullOrEmpty, true, false, 0, "  ", false)]
    [TestCase(StringCheckType.IsNullOrEmpty, true, true, 0, "  ", true)]
    [TestCase(StringCheckType.IsNullOrEmpty, true, null, 0, "  ", null)]
    [TestCase(StringCheckType.IsNullOrEmpty, true, false, 0, "a", false)]
    [TestCase(StringCheckType.IsNullOrEmpty, true, true, 0, "a", true)]
    [TestCase(StringCheckType.IsNullOrEmpty, true, null, 0, "a", null)]
    [TestCase(StringCheckType.IsNull, true, false, 0, null, true)]
    [TestCase(StringCheckType.IsNull, false, false, 0, null, false)]
    [TestCase(StringCheckType.IsNull, null, false, 0, null, null)]
    [TestCase(StringCheckType.IsNull, true, false, 0, "", false)]
    [TestCase(StringCheckType.IsNull, true, true, 0, "", true)]
    [TestCase(StringCheckType.IsNull, true, null, 0, "", null)]
    [TestCase(StringCheckType.IsNull, true, false, 0, "  ", false)]
    [TestCase(StringCheckType.IsNull, true, true, 0, "  ", true)]
    [TestCase(StringCheckType.IsNull, true, null, 0, "  ", null)]
    [TestCase(StringCheckType.IsNull, true, false, 0, "a", false)]
    [TestCase(StringCheckType.IsNull, true, true, 0, "a", true)]
    [TestCase(StringCheckType.IsNull, true, null, 0, "a", null)]
    [TestCase(StringCheckType.IsEmpty, true, false, 0, null, false)]
    [TestCase(StringCheckType.IsEmpty, true, true, 0, null, true)]
    [TestCase(StringCheckType.IsEmpty, true, null, 0, null, null)]
    [TestCase(StringCheckType.IsEmpty, true, false, 0, "", true)]
    [TestCase(StringCheckType.IsEmpty, false, false, 0, "", false)]
    [TestCase(StringCheckType.IsEmpty, null, false, 0, "", null)]
    [TestCase(StringCheckType.IsEmpty, true, false, 0, "  ", false)]
    [TestCase(StringCheckType.IsEmpty, true, true, 0, "  ", true)]
    [TestCase(StringCheckType.IsEmpty, true, null, 0, "  ", null)]
    [TestCase(StringCheckType.IsEmpty, true, false, 0, "a", false)]
    [TestCase(StringCheckType.IsEmpty, true, true, 0, "a", true)]
    [TestCase(StringCheckType.IsEmpty, true, null, 0, "a", null)]
    [TestCase(StringCheckType.IsWhitespace, true, false, 0, null, false)]
    [TestCase(StringCheckType.IsWhitespace, true, true, 0, null, true)]
    [TestCase(StringCheckType.IsWhitespace, true, null, 0, null, null)]
    [TestCase(StringCheckType.IsWhitespace, true, false, 0, "", false)]
    [TestCase(StringCheckType.IsWhitespace, true, true, 0, "", true)]
    [TestCase(StringCheckType.IsWhitespace, true, null, 0, "", null)]
    [TestCase(StringCheckType.IsWhitespace, true, false, 0, "  ", true)]
    [TestCase(StringCheckType.IsWhitespace, false, false, 0, "  ", false)]
    [TestCase(StringCheckType.IsWhitespace, null, false, 0, "  ", null)]
    [TestCase(StringCheckType.IsWhitespace, true, false, 0, "a", false)]
    [TestCase(StringCheckType.IsWhitespace, true, true, 0, "a", true)]
    [TestCase(StringCheckType.IsWhitespace, true, null, 0, "a", null)]
    [TestCase(StringCheckType.IsUpper, true, false, 0, "a", false)]
    [TestCase(StringCheckType.IsUpper, true, true, 0, "a", true)]
    [TestCase(StringCheckType.IsUpper, true, null, 0, "a", null)]
    [TestCase(StringCheckType.IsUpper, true, false, 0, "A", true)]
    [TestCase(StringCheckType.IsUpper, false, false, 0, "A", false)]
    [TestCase(StringCheckType.IsUpper, null, false, 0, "A", null)]
    [TestCase(StringCheckType.IsLower, true, false, 0, "a", true)]
    [TestCase(StringCheckType.IsLower, false, false, 0, "a", false)]
    [TestCase(StringCheckType.IsLower, null, false, 0, "a", null)]
    [TestCase(StringCheckType.IsLower, true, false, 0, "A", false)]
    [TestCase(StringCheckType.IsLower, true, true, 0, "A", true)]
    [TestCase(StringCheckType.IsLower, true, null, 0, "A", null)]
    [TestCase(StringCheckType.IsShorterThan, true, false, 4, "aaa", true)]
    [TestCase(StringCheckType.IsShorterThan, false, false, 4, "aaa", false)]
    [TestCase(StringCheckType.IsShorterThan, null, false, 4, "aaa", null)]
    [TestCase(StringCheckType.IsShorterThan, true, false, 4, "aaaa", false)]
    [TestCase(StringCheckType.IsShorterThan, true, true, 4, "aaaa", true)]
    [TestCase(StringCheckType.IsShorterThan, true, null, 4, "aaaa", null)]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, true, false, 4, "aaa", true)]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, false, false, 4, "aaa", false)]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, null, false, 4, "aaa", null)]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, true, false, 4, "aaaa", true)]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, false, false, 4, "aaaa", false)]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, null, false, 4, "aaaa", null)]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, true, false, 4, "aaaaa", false)]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, true, true, 4, "aaaaa", true)]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, true, null, 4, "aaaaa", null)]
    [TestCase(StringCheckType.IsLongerThan, true, false, 4, "aaaaa", true)]
    [TestCase(StringCheckType.IsLongerThan, false, false, 4, "aaaaa", false)]
    [TestCase(StringCheckType.IsLongerThan, null, false, 4, "aaaaa", null)]
    [TestCase(StringCheckType.IsLongerThan, true, false, 4, "aaa", false)]
    [TestCase(StringCheckType.IsLongerThan, true, true, 4, "aaa", true)]
    [TestCase(StringCheckType.IsLongerThan, true, null, 4, "aaa", null)]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, true, false, 4, "aaaaa", true)]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, false, false, 4, "aaaaa", false)]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, null, false, 4, "aaaaa", null)]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, true, false, 4, "aaaa", true)]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, false, false, 4, "aaaa", false)]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, null, false, 4, "aaaa", null)]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, true, false, 4, "aaa", false)]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, true, true, 4, "aaa", true)]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, true, null, 4, "aaa", null)]
    [TestCase(StringCheckType.IsExactLength, true, false, 4, "aaaa", true)]
    [TestCase(StringCheckType.IsExactLength, false, false, 4, "aaaa", false)]
    [TestCase(StringCheckType.IsExactLength, null, false, 4, "aaaa", null)]
    [TestCase(StringCheckType.IsExactLength, true, false, 4, "aaa", false)]
    [TestCase(StringCheckType.IsExactLength, true, true, 4, "aaa", true)]
    [TestCase(StringCheckType.IsExactLength, true, null, 4, "aaa", null)]
    [TestCase(StringCheckType.IsExactLength, true, false, 4, "aaaaa", false)]
    [TestCase(StringCheckType.IsExactLength, true, true, 4, "aaaaa", true)]
    [TestCase(StringCheckType.IsExactLength, true, null, 4, "aaaaa", null)]
    public void Convert_Called_Converts(StringCheckType checkType, bool? trueIs, bool? falseIs, int variable, object input, bool? expectation)
    {
        _target.CheckType = checkType;
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;
        _target.Variable = variable;

        Convert(input, expectation);
    }

    [TestCase(StringCheckType.IsNullOrWhitespace, true, false, null, 0, true, null, "", "")]
    [TestCase(StringCheckType.IsNullOrWhitespace, false, false, null, 0, false, null, "", "")]
    [TestCase(StringCheckType.IsNullOrWhitespace, null, false, null, 0, null, null, "", "")]
    [TestCase(StringCheckType.IsNullOrWhitespace, true, false, null, 0, true, "", " ", " ")]
    [TestCase(StringCheckType.IsNullOrWhitespace, false, false, null, 0, false, "", " ", " ")]
    [TestCase(StringCheckType.IsNullOrWhitespace, null, false, null, 0, null, "", " ", " ")]
    [TestCase(StringCheckType.IsNullOrWhitespace, true, false, null, 0, true, "  ", " ", "   ")]
    [TestCase(StringCheckType.IsNullOrWhitespace, false, false, null, 0, false, "  ", " ", "   ")]
    [TestCase(StringCheckType.IsNullOrWhitespace, null, false, null, 0, null, "  ", " ", "   ")]
    [TestCase(StringCheckType.IsNullOrWhitespace, true, false, null, 0, false, "a", "a", "a")]
    [TestCase(StringCheckType.IsNullOrWhitespace, true, true, null, 0, true, "a", "a", "a")]
    [TestCase(StringCheckType.IsNullOrWhitespace, true, null, null, 0, null, "a", "a", "a")]
    [TestCase(StringCheckType.IsNullOrWhitespace, true, false, null, 0, null, "a", "", "")]
    [TestCase(StringCheckType.IsNullOrWhitespace, true, false, true, 0, true, "a", "", "")]
    [TestCase(StringCheckType.IsNullOrWhitespace, true, false, false, 0, false, "a", "", "")]
    [TestCase(StringCheckType.IsNullOrEmpty, true, false, null, 0, true, null, "", "")]
    [TestCase(StringCheckType.IsNullOrEmpty, false, false, null, 0, false, null, "", "")]
    [TestCase(StringCheckType.IsNullOrEmpty, null, false, null, 0, null, null, "", "")]
    [TestCase(StringCheckType.IsNullOrEmpty, true, false, null, 0, true, "", "", "")]
    [TestCase(StringCheckType.IsNullOrEmpty, false, false, null, 0, false, "", "", "")]
    [TestCase(StringCheckType.IsNullOrEmpty, null, false, null, 0, null, "", "", "")]
    [TestCase(StringCheckType.IsNullOrEmpty, true, false, null, 0, false, "  ", " ", "   ")]
    [TestCase(StringCheckType.IsNullOrEmpty, true, true, null, 0, true, "  ", " ", "   ")]
    [TestCase(StringCheckType.IsNullOrEmpty, true, null, null, 0, null, "  ", " ", "   ")]
    [TestCase(StringCheckType.IsNullOrEmpty, true, false, null, 0, false, "a", "a", "a")]
    [TestCase(StringCheckType.IsNullOrEmpty, true, true, null, 0, true, "a", "a", "a")]
    [TestCase(StringCheckType.IsNullOrEmpty, true, null, null, 0, null, "a", "a", "a")]
    [TestCase(StringCheckType.IsNullOrEmpty, true, false, null, 0, null, "a", "", "")]
    [TestCase(StringCheckType.IsNullOrEmpty, true, false, true, 0, true, "a", "", "")]
    [TestCase(StringCheckType.IsNullOrEmpty, true, false, false, 0, false, "a", "", "")]
    [TestCase(StringCheckType.IsNull, true, false, null, 0, true, null, null, null)]
    [TestCase(StringCheckType.IsNull, false, false, null, 0, false, null, null, null)]
    [TestCase(StringCheckType.IsNull, null, false, null, 0, null, null, null, null)]
    [TestCase(StringCheckType.IsNull, true, false, null, 0, false, "", "", "")]
    [TestCase(StringCheckType.IsNull, true, true, null, 0, true, "", "", "")]
    [TestCase(StringCheckType.IsNull, true, null, null, 0, null, "", "", "")]
    [TestCase(StringCheckType.IsNull, true, false, null, 0, false, "  ", " ", "   ")]
    [TestCase(StringCheckType.IsNull, true, true, null, 0, true, "  ", " ", "   ")]
    [TestCase(StringCheckType.IsNull, true, null, null, 0, null, "  ", " ", "   ")]
    [TestCase(StringCheckType.IsNull, true, false, null, 0, false, "a", "a", "a")]
    [TestCase(StringCheckType.IsNull, true, true, null, 0, true, "a", "a", "a")]
    [TestCase(StringCheckType.IsNull, true, null, null, 0, null, "a", "a", "a")]
    [TestCase(StringCheckType.IsNull, true, false, null, 0, null, null, "", "")]
    [TestCase(StringCheckType.IsNull, true, false, true, 0, true, null, "", "")]
    [TestCase(StringCheckType.IsNull, true, false, false, 0, false, null, "", "")]
    [TestCase(StringCheckType.IsNull, true, false, null, 0, true, null, null, null)]
    [TestCase(StringCheckType.IsNull, false, false, null, 0, false, null, null, null)]
    [TestCase(StringCheckType.IsNull, null, false, null, 0, null, null, null, null)]
    [TestCase(StringCheckType.IsNull, true, false, null, 0, false, "  ", " ", "   ")]
    [TestCase(StringCheckType.IsNull, true, true, null, 0, true, "  ", " ", "   ")]
    [TestCase(StringCheckType.IsNull, true, null, null, 0, null, "  ", " ", "   ")]
    [TestCase(StringCheckType.IsNull, true, false, null, 0, false, "a", "a", "a")]
    [TestCase(StringCheckType.IsNull, true, true, null, 0, true, "a", "a", "a")]
    [TestCase(StringCheckType.IsNull, true, null, null, 0, null, "a", "a", "a")]
    [TestCase(StringCheckType.IsNull, true, false, null, 0, null, null, null, "")]
    [TestCase(StringCheckType.IsNull, true, false, true, 0, true, null, null, "")]
    [TestCase(StringCheckType.IsNull, true, false, false, 0, false, null, null, "")]
    [TestCase(StringCheckType.IsEmpty, true, false, null, 0, false, null, null, null)]
    [TestCase(StringCheckType.IsEmpty, true, true, null, 0, true, null, null, null)]
    [TestCase(StringCheckType.IsEmpty, true, null, null, 0, null, null, null, null)]
    [TestCase(StringCheckType.IsEmpty, true, false, null, 0, true, "", "", "")]
    [TestCase(StringCheckType.IsEmpty, false, false, null, 0, false, "", "", "")]
    [TestCase(StringCheckType.IsEmpty, null, false, null, 0, null, "", "", "")]
    [TestCase(StringCheckType.IsEmpty, true, false, null, 0, false, "a", "a", "a")]
    [TestCase(StringCheckType.IsEmpty, true, true, null, 0, true, "a", "a", "a")]
    [TestCase(StringCheckType.IsEmpty, true, null, null, 0, null, "a", "a", "a")]
    [TestCase(StringCheckType.IsEmpty, true, false, null, 0, null, null, null, "")]
    [TestCase(StringCheckType.IsEmpty, true, false, true, 0, true, null, null, "")]
    [TestCase(StringCheckType.IsEmpty, true, false, false, 0, false, null, null, "")]
    [TestCase(StringCheckType.IsWhitespace, true, false, null, 0, false, null, null, null)]
    [TestCase(StringCheckType.IsWhitespace, true, true, null, 0, true, null, null, null)]
    [TestCase(StringCheckType.IsWhitespace, true, null, null, 0, null, null, null, null)]
    [TestCase(StringCheckType.IsWhitespace, true, false, null, 0, true, "  ", " ", "   ")]
    [TestCase(StringCheckType.IsWhitespace, false, false, null, 0, false, "  ", " ", "   ")]
    [TestCase(StringCheckType.IsWhitespace, null, false, null, 0, null, "  ", " ", "   ")]
    [TestCase(StringCheckType.IsWhitespace, true, false, null, 0, false, "a", "a", "a")]
    [TestCase(StringCheckType.IsWhitespace, true, true, null, 0, true, "a", "a", "a")]
    [TestCase(StringCheckType.IsWhitespace, true, null, null, 0, null, "a", "a", "a")]
    [TestCase(StringCheckType.IsWhitespace, true, false, null, 0, null, null, null, "  ")]
    [TestCase(StringCheckType.IsWhitespace, true, false, true, 0, true, null, null, "  ")]
    [TestCase(StringCheckType.IsWhitespace, true, false, false, 0, false, null, null, "  ")]
    [TestCase(StringCheckType.IsUpper, true, false, null, 0, false, "a", "a", "a")]
    [TestCase(StringCheckType.IsUpper, true, true, null, 0, true, "a", "a", "a")]
    [TestCase(StringCheckType.IsUpper, true, null, null, 0, null, "a", "a", "a")]
    [TestCase(StringCheckType.IsUpper, true, false, null, 0, true, "A", "A", "A")]
    [TestCase(StringCheckType.IsUpper, false, false, null, 0, false, "A", "A", "A")]
    [TestCase(StringCheckType.IsUpper, null, false, null, 0, null, "A", "A", "A")]
    [TestCase(StringCheckType.IsUpper, true, false, null, 0, null, "a", "a", "A")]
    [TestCase(StringCheckType.IsUpper, true, false, true, 0, true, "a", "a", "A")]
    [TestCase(StringCheckType.IsUpper, true, false, false, 0, false, "a", "a", "A")]
    [TestCase(StringCheckType.IsLower, true, false, null, 0, false, "A", "A", "A")]
    [TestCase(StringCheckType.IsLower, true, true, null, 0, true, "A", "A", "A")]
    [TestCase(StringCheckType.IsLower, true, null, null, 0, null, "A", "A", "A")]
    [TestCase(StringCheckType.IsLower, true, false, null, 0, true, "a", "a", "a")]
    [TestCase(StringCheckType.IsLower, false, false, null, 0, false, "a", "a", "a")]
    [TestCase(StringCheckType.IsLower, null, false, null, 0, null, "a", "a", "a")]
    [TestCase(StringCheckType.IsLower, true, false, null, 0, null, "A", "A", "a")]
    [TestCase(StringCheckType.IsLower, true, false, true, 0, true, "A", "A", "a")]
    [TestCase(StringCheckType.IsLower, true, false, false, 0, false, "A", "A", "a")]
    [TestCase(StringCheckType.IsShorterThan, true, false, null, 4, true, "aaa", "aa", "a")]
    [TestCase(StringCheckType.IsShorterThan, false, false, null, 4, false, "aaa", "aa", "a")]
    [TestCase(StringCheckType.IsShorterThan, null, false, null, 4, null, "aaa", "aa", "a")]
    [TestCase(StringCheckType.IsShorterThan, true, false, null, 4, false, "aaaa", "aaaaaa", "aaaaaaa")]
    [TestCase(StringCheckType.IsShorterThan, true, true, null, 4, true, "aaaa", "aaaaaa", "aaaaaaa")]
    [TestCase(StringCheckType.IsShorterThan, true, null, null, 4, null, "aaaa", "aaaaaa", "aaaaaaa")]
    [TestCase(StringCheckType.IsShorterThan, true, false, null, 4, null, "aaaa", "aa", "aaaaaaa")]
    [TestCase(StringCheckType.IsShorterThan, true, false, true, 4, true, "aaaa", "aa", "aaaaaaa")]
    [TestCase(StringCheckType.IsShorterThan, true, false, false, 4, false, "aaaa", "aa", "aaaaaaa")]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, true, false, null, 4, true, "aaa", "aa", "a")]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, false, false, null, 4, false, "aaa", "aa", "a")]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, null, false, null, 4, null, "aaa", "aa", "a")]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, true, false, null, 4, true, "aaaa", "aa", "a")]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, false, false, null, 4, false, "aaaa", "aa", "a")]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, null, false, null, 4, null, "aaaa", "aa", "a")]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, true, false, null, 4, false, "aaaaa", "aaaaaa", "aaaaaaa")]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, true, true, null, 4, true, "aaaaa", "aaaaaa", "aaaaaaa")]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, true, null, null, 4, null, "aaaaa", "aaaaaa", "aaaaaaa")]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, true, false, null, 4, null, "aaaaa", "aa", "aaaaaaa")]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, true, false, true, 4, true, "aaaaa", "aa", "aaaaaaa")]
    [TestCase(StringCheckType.IsShorterThanOrEqualTo, true, false, false, 4, false, "aaaaa", "aa", "aaaaaaa")]
    [TestCase(StringCheckType.IsLongerThan, true, false, null, 4, true, "aaaaa", "aaaaaa", "aaaaaaa")]
    [TestCase(StringCheckType.IsLongerThan, false, false, null, 4, false, "aaaaa", "aaaaaa", "aaaaaaa")]
    [TestCase(StringCheckType.IsLongerThan, null, false, null, 4, null, "aaaaa", "aaaaaa", "aaaaaaa")]
    [TestCase(StringCheckType.IsLongerThan, true, false, null, 4, false, "aaa", "aa", "a")]
    [TestCase(StringCheckType.IsLongerThan, true, true, null, 4, true, "aaa", "aa", "a")]
    [TestCase(StringCheckType.IsLongerThan, true, null, null, 4, null, "aaa", "aa", "a")]
    [TestCase(StringCheckType.IsLongerThan, true, false, null, 4, null, "aaaaa", "aa", "aaaaaaa")]
    [TestCase(StringCheckType.IsLongerThan, true, false, true, 4, true, "aaaaa", "aa", "aaaaaaa")]
    [TestCase(StringCheckType.IsLongerThan, true, false, false, 4, false, "aaaaa", "aa", "aaaaaaa")]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, true, false, null, 4, true, "aaaaa", "aaaaaa", "aaaaaaa")]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, false, false, null, 4, false, "aaaaa", "aaaaaa", "aaaaaaa")]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, null, false, null, 4, null, "aaaaa", "aaaaaa", "aaaaaaa")]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, true, false, null, 4, true, "aaaa", "aaaaa", "aaaaaa")]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, false, false, null, 4, false, "aaaa", "aaaaa", "aaaaaa")]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, null, false, null, 4, null, "aaaa", "aaaaa", "aaaaaa")]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, true, false, null, 4, false, "aaa", "aa", "a")]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, true, true, null, 4, true, "aaa", "aa", "a")]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, true, null, null, 4, null, "aaa", "aa", "a")]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, true, false, null, 4, null, "aaaa", "aa", "aaaaaaa")]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, true, false, true, 4, true, "aaaa", "aa", "aaaaaaa")]
    [TestCase(StringCheckType.IsLongerThanOrEqualTo, true, false, false, 4, false, "aaaa", "aa", "aaaaaaa")]
    [TestCase(StringCheckType.IsExactLength, true, false, null, 4, true, "aaaa", "aaaa", "aaaa")]
    [TestCase(StringCheckType.IsExactLength, false, false, null, 4, false, "aaaa", "aaaa", "aaaa")]
    [TestCase(StringCheckType.IsExactLength, null, false, null, 4, null, "aaaa", "aaaa", "aaaa")]
    [TestCase(StringCheckType.IsExactLength, true, false, null, 4, false, "aaa", "aaa", "aaa")]
    [TestCase(StringCheckType.IsExactLength, true, true, null, 4, true, "aaa", "aaa", "aaa")]
    [TestCase(StringCheckType.IsExactLength, true, null, null, 4, null, "aaa", "aaa", "aaa")]
    [TestCase(StringCheckType.IsExactLength, true, false, null, 4, false, "aaaaa", "aaaaa", "aaaaa")]
    [TestCase(StringCheckType.IsExactLength, true, true, null, 4, true, "aaaaa", "aaaaa", "aaaaa")]
    [TestCase(StringCheckType.IsExactLength, true, null, null, 4, null, "aaaaa", "aaaaa", "aaaaa")]
    [TestCase(StringCheckType.IsExactLength, true, false, null, 4, null, "aaaa", "aa", "aaaa")]
    [TestCase(StringCheckType.IsExactLength, true, false, true, 4, true, "aaaa", "aa", "aaaa")]
    [TestCase(StringCheckType.IsExactLength, true, false, false, 4, false, "aaaa", "aa", "aaaa")]
    public void MultiConvert_Called_Converts(StringCheckType checkType, bool? trueIs, bool? falseIs, bool? mixedIs, int variable, bool? expectation, params object[] input)
    {
        _target.CheckType = checkType;
        _target.TrueIs = trueIs;
        _target.FalseIs = falseIs;
        _target.MixedIs = mixedIs;
        _target.Variable = variable;

        MultiConvert(input, expectation);
    }

    [Test]
    public void ConvertBack_Called_RaisesException()
    {
        Assert.That(() => ConvertBack(null, null), Throws.TypeOf<NotImplementedException>());
    }

    [Test]
    public void MultiConvertBack_Called_RaisesException()
    {
        Assert.That(() => MultiConvertBack(null, []), Throws.TypeOf<NotImplementedException>());
    }
}