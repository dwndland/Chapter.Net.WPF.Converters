// -----------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleMathConverterTests.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters.Tests;

public class DoubleMathConverterTests : ValueConverterTester<DoubleMathConverter>
{
    [TestCase(false, Calculation.Addition, 2, 2d, 4d)]
    [TestCase(false, Calculation.Addition, 2d, 2d, 4d)]
    [TestCase(false, Calculation.Addition, (ushort)2, 2d, 4d)]
    [TestCase(false, Calculation.Addition, null, 2d, 0d)]
    [TestCase(false, Calculation.Subtraction, 4, 2d, 2d)]
    [TestCase(false, Calculation.Subtraction, 4d, 2d, 2d)]
    [TestCase(false, Calculation.Subtraction, (ushort)4, 2d, 2d)]
    [TestCase(false, Calculation.Subtraction, null, 2d, 0d)]
    [TestCase(false, Calculation.Multiplication, 3, 3d, 9d)]
    [TestCase(false, Calculation.Multiplication, 3d, 3d, 9d)]
    [TestCase(false, Calculation.Multiplication, (ushort)3, 3d, 9d)]
    [TestCase(false, Calculation.Multiplication, null, 3d, 0d)]
    [TestCase(false, Calculation.Division, 15, 3d, 5d)]
    [TestCase(false, Calculation.Division, 15d, 3d, 5d)]
    [TestCase(false, Calculation.Division, (ushort)15, 3d, 5d)]
    [TestCase(false, Calculation.Division, null, 3d, 0d)]
    [TestCase(true, Calculation.Addition, 2, 2d, 4d)]
    [TestCase(true, Calculation.Addition, 2d, 2d, 4d)]
    [TestCase(true, Calculation.Addition, (ushort)2, 2d, 4d)]
    [TestCase(true, Calculation.Addition, null, 2d, 0d)]
    [TestCase(true, Calculation.Subtraction, 4, 2d, -2d)]
    [TestCase(true, Calculation.Subtraction, 4d, 2d, -2d)]
    [TestCase(true, Calculation.Subtraction, (ushort)4, 2d, -2d)]
    [TestCase(true, Calculation.Subtraction, null, 2d, 0d)]
    [TestCase(true, Calculation.Multiplication, 3, 3d, 9d)]
    [TestCase(true, Calculation.Multiplication, 3d, 3d, 9d)]
    [TestCase(true, Calculation.Multiplication, (ushort)3, 3d, 9d)]
    [TestCase(true, Calculation.Multiplication, null, 3d, 0d)]
    [TestCase(true, Calculation.Division, 15, 3d, 0.2d)]
    [TestCase(true, Calculation.Division, 15d, 3d, 0.2d)]
    [TestCase(true, Calculation.Division, (ushort)15, 3d, 0.2d)]
    [TestCase(true, Calculation.Division, null, 3d, 0d)]
    public void Convert_Called_Calculates(bool backwards, Calculation calculation, object input, double variable, double expectation)
    {
        _target.Backwards = backwards;
        _target.Calculation = calculation;
        _target.Variable = variable;

        Convert(input, expectation);
    }

    [TestCase(false, Calculation.Addition, 4, 2d, 2d)]
    [TestCase(false, Calculation.Addition, 4d, 2d, 2d)]
    [TestCase(false, Calculation.Addition, (ushort)2, 2d, 0d)]
    [TestCase(false, Calculation.Addition, null, 2d, 0d)]
    [TestCase(false, Calculation.Subtraction, 2, 2d, 4d)]
    [TestCase(false, Calculation.Subtraction, 2d, 2d, 4d)]
    [TestCase(false, Calculation.Subtraction, (ushort)2, 2d, 4d)]
    [TestCase(false, Calculation.Subtraction, null, 2d, 0d)]
    [TestCase(false, Calculation.Multiplication, 9, 3d, 3d)]
    [TestCase(false, Calculation.Multiplication, 9d, 3d, 3d)]
    [TestCase(false, Calculation.Multiplication, (ushort)9, 3d, 3d)]
    [TestCase(false, Calculation.Multiplication, null, 3d, 0d)]
    [TestCase(false, Calculation.Division, 5, 3d, 15d)]
    [TestCase(false, Calculation.Division, 5d, 3d, 15d)]
    [TestCase(false, Calculation.Division, (ushort)5, 3d, 15d)]
    [TestCase(false, Calculation.Division, null, 3d, 0d)]
    [TestCase(true, Calculation.Addition, 4, 2d, -2d)]
    [TestCase(true, Calculation.Addition, 4d, 2d, -2d)]
    [TestCase(true, Calculation.Addition, (ushort)2, 2d, 0d)]
    [TestCase(true, Calculation.Addition, null, 2d, 0d)]
    [TestCase(true, Calculation.Subtraction, 2, 2d, 4d)]
    [TestCase(true, Calculation.Subtraction, 2d, 2d, 4d)]
    [TestCase(true, Calculation.Subtraction, (ushort)2, 2d, 4d)]
    [TestCase(true, Calculation.Subtraction, null, 2d, 0d)]
    [TestCase(true, Calculation.Multiplication, 9, 3d, 0.33333333333333331d)]
    [TestCase(true, Calculation.Multiplication, 9d, 3d, 0.33333333333333331d)]
    [TestCase(true, Calculation.Multiplication, (ushort)9, 3d, 0.33333333333333331d)]
    [TestCase(true, Calculation.Multiplication, null, 3d, 0d)]
    [TestCase(true, Calculation.Division, 5, 3d, 15d)]
    [TestCase(true, Calculation.Division, 5d, 3d, 15d)]
    [TestCase(true, Calculation.Division, (ushort)5, 3d, 15d)]
    [TestCase(true, Calculation.Division, null, 3d, 0d)]
    public void ConvertBack_Called_Calculates(bool backwards, Calculation calculation, object input, double variable, double expectation)
    {
        _target.Backwards = backwards;
        _target.Calculation = calculation;
        _target.Variable = variable;

        ConvertBack(input, expectation);
    }
}