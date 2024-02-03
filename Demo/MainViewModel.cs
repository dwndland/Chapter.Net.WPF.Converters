// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Windows.Forms.VisualStyles;
using Chapter.Net;
using static Demo.PropertyViewModel;

namespace Demo;

public class MainViewModel : ObservableObject
{
    public PropertyViewModel SingleBooleanToBooleanConverter { get; set; } = new();
    public PropertyViewModel MultiBooleanToBooleanConverter { get; set; } = new(true, true, true);
    public PropertyViewModel SingleBooleanToIntegerConverter { get; set; } = new(true, true, true);
    public PropertyViewModel MultiBooleanToIntegerConverter { get; set; } = new(true, true, true);
    public PropertyViewModel SingleBooleanToVisibilityConverter { get; set; } = new(true, true, true);
    public PropertyViewModel MultiBooleanToVisibilityConverter { get; set; } = new(true, true, true);
    public PropertyViewModel SingleCharacterCheckToBooleanConverter { get; set; } = new('a', '0', 'c');
    public PropertyViewModel MultiCharacterCheckToBooleanConverter { get; set; } = new('a', '0', 'c');
    public PropertyViewModel SingleCharacterCheckToVisibilityConverter { get; set; } = new('a', '0', 'c');
    public PropertyViewModel MultiCharacterCheckToVisibilityConverter { get; set; } = new('a', '0', 'c');
    public PropertyViewModel ConcatenateStringConverter { get; set; } = new("First", "Second", "Third");
    public PropertyViewModel DateOnlyToStringConverter { get; set; } = new(new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
    public PropertyViewModel DateTimeToStringConverter { get; set; } = new(DateTime.Now);
    public PropertyViewModel DateTimeUtcConverter { get; set; } = new(DateTime.Now);
    public PropertyViewModel SingleDoubleComparisonToBooleanConverter { get; set; } = new(6d, 6d, 6d);
    public PropertyViewModel MultiDoubleComparisonToBooleanConverter { get; set; } = new(6d, 6d, 6d);
    public PropertyViewModel SingleDoubleComparisonToVisibilityConverter { get; set; } = new(6d, 6d, 6d);
    public PropertyViewModel MultiDoubleComparisonToVisibilityConverter { get; set; } = new(6d, 6d, 6d);
    public PropertyViewModel DoubleMathConverter { get; set; } = new(1d, 1d, 1d);
    public PropertyViewModel DoubleToStringConverter { get; set; } = new(1d, 1d, 1d);
    public PropertyViewModel SingleDoubleToThicknessConverter { get; set; } = new(2d, 2d, 2d);
    public PropertyViewModel MultiDoubleToThicknessConverter { get; set; } = new(2d, 2d, 2d);
    public PropertyViewModel SingleEqualsToBooleanConverter { get; set; } = new(2d, 2d, 2d);
    public PropertyViewModel MultiEqualsToBooleanConverter { get; set; } = new(2d, 2d, 2d);
    public PropertyViewModel SingleEqualsToVisibilityConverter { get; set; } = new(5d, 5d, 5d);
    public PropertyViewModel MultiEqualsToVisibilityConverter { get; set; } = new(2d, 2d, 2d);
    public PropertyViewModel SingleIntegerComparisonToBooleanConverter { get; set; } = new(6, 6, 6);
    public PropertyViewModel MultiIntegerComparisonToBooleanConverter { get; set; } = new(6, 6, 6);
    public PropertyViewModel SingleIntegerComparisonToVisibilityConverter { get; set; } = new(6, 6, 6);
    public PropertyViewModel MultiIntegerComparisonToVisibilityConverter { get; set; } = new(6, 6, 6);
    public PropertyViewModel IntegerMathConverter { get; set; } = new(1, 1, 1);
    public PropertyViewModel SingleIntegerToBooleanConverter { get; set; } = new(0, 0, 0);
    public PropertyViewModel MultiIntegerToBooleanConverter { get; set; } = new(0, 0, 0);
    public PropertyViewModel IntegerToStringConverter { get; set; } = new(1, 1, 1);
    public PropertyViewModel IsLastItemInListConverter { get; set; } = new([new Integer(10), new Integer(20), new Integer(30)]);
    public PropertyViewModel SingleIsNullToBooleanConverter { get; set; } = new(true, true, true);
    public PropertyViewModel MultiIsNullToBooleanConverter { get; set; } = new(true, true, true);
    public PropertyViewModel SingleIsNullToVisibilityConverter { get; set; } = new(true, true, true);
    public PropertyViewModel MultiIsNullToVisibilityConverter { get; set; } = new(true, true, true);
    public PropertyViewModel SingleNumberCheckToBooleanConverter { get; set; } = new(6d, 6d, 6d);
    public PropertyViewModel MultiNumberCheckToBooleanConverter { get; set; } = new(6d, 6d, 6d);
    public PropertyViewModel SingleNumberCheckToVisibilityConverter { get; set; } = new(6d, 6d, 6d);
    public PropertyViewModel MultiNumberCheckToVisibilityConverter { get; set; } = new(6d, 6d, 6d);
    public PropertyViewModel ObjectToTypeConverter { get; set; } = new(true, true, true);
    public PropertyViewModel PathToStringConverter { get; set; } = new("C:\\Folder\\File.txt", string.Empty, string.Empty);
    public PropertyViewModel RoundingConverter { get; set; } = new(12.158, 0d, 0d);
    public PropertyViewModel SingleStringCheckToBooleanConverter { get; set; } = new(" ", " ", " ");
    public PropertyViewModel MultiStringCheckToBooleanConverter { get; set; } = new(" ", " ", " ");
    public PropertyViewModel SingleStringCheckToVisibilityConverter { get; set; } = new(" ", " ", " ");
    public PropertyViewModel MultiStringCheckToVisibilityConverter { get; set; } = new(" ", " ", " ");
    public PropertyViewModel StringToLowerConverter { get; set; } = new("SAY HELLO", string.Empty, string.Empty);
    public PropertyViewModel StringToUpperConverter { get; set; } = new("say hello", string.Empty, string.Empty);
    public PropertyViewModel TimeOnlyToStringConverter { get; set; } = new(new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute));
    public PropertyViewModel ValueToPathConverter { get; set; } = new("C:", "Folder", "File.txt");
}