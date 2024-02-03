// -----------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyViewModel.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Chapter.Net;

namespace Demo;

public class PropertyViewModel : ObservableObject
{
    private char _character1;
    private char _character2;
    private char _character3;
    private DateOnly _dateOnly;
    private DateTime _dateTime;
    private double _double1;
    private double _double2;
    private double _double3;
    private int _integer1;
    private int _integer2;
    private int _integer3;
    private bool? _isChecked1;
    private bool? _isChecked2;
    private bool? _isChecked3;
    private string _string1;
    private string _string2;
    private string _string3;

    public PropertyViewModel()
    {
    }

    public PropertyViewModel(char character1, char character2, char character3)
    {
        _character1 = character1;
        _character2 = character2;
        _character3 = character3;
    }

    public PropertyViewModel(DateOnly dateOnly)
    {
        DateOnly = dateOnly;
    }

    public PropertyViewModel(DateTime dateTime)
    {
        _dateTime = dateTime;
    }

    public PropertyViewModel(double double1, double double2, double double3)
    {
        _double1 = double1;
        _double2 = double2;
        _double3 = double3;
    }

    public PropertyViewModel(int integer1, int integer2, int integer3)
    {
        _integer1 = integer1;
        _integer2 = integer2;
        _integer3 = integer3;
    }

    public PropertyViewModel(bool? isChecked1, bool? isChecked2, bool? isChecked3)
    {
        _isChecked1 = isChecked1;
        _isChecked2 = isChecked2;
        _isChecked3 = isChecked3;
    }

    public PropertyViewModel(string string1, string string2, string string3)
    {
        _string1 = string1;
        _string2 = string2;
        _string3 = string3;
    }

    public PropertyViewModel(List<Integer> integers)
    {
        Integers = integers;
    }

    public PropertyViewModel(TimeOnly timeOnly)
    {
        TimeOnly = timeOnly;
    }

    public char Character1
    {
        get => _character1;
        set => NotifyAndSetIfChanged(ref _character1, value);
    }

    public char Character2
    {
        get => _character2;
        set => NotifyAndSetIfChanged(ref _character2, value);
    }

    public char Character3
    {
        get => _character3;
        set => NotifyAndSetIfChanged(ref _character3, value);
    }

    public DateOnly DateOnly { get; set; }

    public DateTime DateTime { get; set; }

    public double Double1
    {
        get => _double1;
        set => NotifyAndSetIfChanged(ref _double1, value);
    }

    public double Double2
    {
        get => _double2;
        set => NotifyAndSetIfChanged(ref _double2, value);
    }

    public double Double3
    {
        get => _double3;
        set => NotifyAndSetIfChanged(ref _double3, value);
    }

    public int Integer1
    {
        get => _integer1;
        set => NotifyAndSetIfChanged(ref _integer1, value);
    }

    public int Integer2
    {
        get => _integer2;
        set => NotifyAndSetIfChanged(ref _integer2, value);
    }

    public int Integer3
    {
        get => _integer3;
        set => NotifyAndSetIfChanged(ref _integer3, value);
    }

    public bool? IsChecked1
    {
        get => _isChecked1;
        set => NotifyAndSetIfChanged(ref _isChecked1, value);
    }

    public bool? IsChecked2
    {
        get => _isChecked2;
        set => NotifyAndSetIfChanged(ref _isChecked2, value);
    }

    public bool? IsChecked3
    {
        get => _isChecked3;
        set => NotifyAndSetIfChanged(ref _isChecked3, value);
    }

    public string String1
    {
        get => _string1;
        set => NotifyAndSetIfChanged(ref _string1, value);
    }

    public string String2
    {
        get => _string2;
        set => NotifyAndSetIfChanged(ref _string2, value);
    }

    public string String3
    {
        get => _string3;
        set => NotifyAndSetIfChanged(ref _string3, value);
    }

    public List<Integer> Integers { get; set; }

    public TimeOnly TimeOnly { get; set; }

    public class Integer
    {
        public Integer(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}