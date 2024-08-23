// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IntegerMathConverterTests.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class IntegerMathConverterTests : ValueConverterTester<IntegerMathConverter>
{
    [TestCase(false, Calculation.Addition, 2, 2, 4)]
    [TestCase(false, Calculation.Addition, 2, 2, 4)]
    [TestCase(false, Calculation.Addition, (ushort)2, 2, 4)]
    [TestCase(false, Calculation.Addition, null, 2, 0)]
    [TestCase(false, Calculation.Subtraction, 4, 2, 2)]
    [TestCase(false, Calculation.Subtraction, 4, 2, 2)]
    [TestCase(false, Calculation.Subtraction, (ushort)4, 2, 2)]
    [TestCase(false, Calculation.Subtraction, null, 2, 0)]
    [TestCase(false, Calculation.Multiplication, 3, 3, 9)]
    [TestCase(false, Calculation.Multiplication, 3, 3, 9)]
    [TestCase(false, Calculation.Multiplication, (ushort)3, 3, 9)]
    [TestCase(false, Calculation.Multiplication, null, 3, 0)]
    [TestCase(false, Calculation.Division, 15, 3, 5)]
    [TestCase(false, Calculation.Division, 15, 3, 5)]
    [TestCase(false, Calculation.Division, (ushort)15, 3, 5)]
    [TestCase(false, Calculation.Division, null, 3, 0)]
    [TestCase(true, Calculation.Addition, 2, 2, 4)]
    [TestCase(true, Calculation.Addition, 2, 2, 4)]
    [TestCase(true, Calculation.Addition, (ushort)2, 2, 4)]
    [TestCase(true, Calculation.Addition, null, 2, 0)]
    [TestCase(true, Calculation.Subtraction, 4, 2, -2)]
    [TestCase(true, Calculation.Subtraction, 4, 2, -2)]
    [TestCase(true, Calculation.Subtraction, (ushort)4, 2, -2)]
    [TestCase(true, Calculation.Subtraction, null, 2, 0)]
    [TestCase(true, Calculation.Multiplication, 3, 3, 9)]
    [TestCase(true, Calculation.Multiplication, 3, 3, 9)]
    [TestCase(true, Calculation.Multiplication, (ushort)3, 3, 9)]
    [TestCase(true, Calculation.Multiplication, null, 3, 0)]
    [TestCase(true, Calculation.Division, 3, 15, 5)]
    [TestCase(true, Calculation.Division, 3, 15, 5)]
    [TestCase(true, Calculation.Division, (ushort)3, 15, 5)]
    [TestCase(true, Calculation.Division, null, 3, 0)]
    public void Convert_Called_Calculates(bool backwards, Calculation calculation, object input, int variable, int expectation)
    {
        _target.Backwards = backwards;
        _target.Calculation = calculation;
        _target.Variable = variable;

        Convert(input, expectation);
    }

    [TestCase(false, Calculation.Addition, 4, 2, 2)]
    [TestCase(false, Calculation.Addition, 4, 2, 2)]
    [TestCase(false, Calculation.Addition, (ushort)2, 2, 0)]
    [TestCase(false, Calculation.Addition, null, 2, 0)]
    [TestCase(false, Calculation.Subtraction, 2, 2, 4)]
    [TestCase(false, Calculation.Subtraction, 2, 2, 4)]
    [TestCase(false, Calculation.Subtraction, (ushort)2, 2, 4)]
    [TestCase(false, Calculation.Subtraction, null, 2, 0)]
    [TestCase(false, Calculation.Multiplication, 9, 3, 3)]
    [TestCase(false, Calculation.Multiplication, 9, 3, 3)]
    [TestCase(false, Calculation.Multiplication, (ushort)9, 3, 3)]
    [TestCase(false, Calculation.Multiplication, null, 3, 0)]
    [TestCase(false, Calculation.Division, 5, 3, 15)]
    [TestCase(false, Calculation.Division, 5, 3, 15)]
    [TestCase(false, Calculation.Division, (ushort)5, 3, 15)]
    [TestCase(false, Calculation.Division, null, 3, 0)]
    [TestCase(true, Calculation.Addition, 4, 2, -2)]
    [TestCase(true, Calculation.Addition, 4, 2, -2)]
    [TestCase(true, Calculation.Addition, (ushort)2, 2, 0)]
    [TestCase(true, Calculation.Addition, null, 2, 0)]
    [TestCase(true, Calculation.Subtraction, 2, 2, 4)]
    [TestCase(true, Calculation.Subtraction, 2, 2, 4)]
    [TestCase(true, Calculation.Subtraction, (ushort)2, 2, 4)]
    [TestCase(true, Calculation.Subtraction, null, 2, 0)]
    [TestCase(true, Calculation.Multiplication, 3, 9, 3)]
    [TestCase(true, Calculation.Multiplication, 3, 9, 3)]
    [TestCase(true, Calculation.Multiplication, (ushort)3, 9, 3)]
    [TestCase(true, Calculation.Multiplication, null, 3, 0)]
    [TestCase(true, Calculation.Division, 5, 3, 15)]
    [TestCase(true, Calculation.Division, 5, 3, 15)]
    [TestCase(true, Calculation.Division, (ushort)5, 3, 15)]
    [TestCase(true, Calculation.Division, null, 3, 0)]
    public void ConvertBack_Called_Calculates(bool backwards, Calculation calculation, object input, int variable, int expectation)
    {
        _target.Backwards = backwards;
        _target.Calculation = calculation;
        _target.Variable = variable;

        ConvertBack(input, expectation);
    }
}