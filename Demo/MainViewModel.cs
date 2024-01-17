// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Chapter.Net;

namespace Demo;

public class MainViewModel : ObservableObject
{
    private double _double1;
    private double _double2;
    private double _double3;
    private double _double4;
    private double _double5;
    private int _integer1;
    private int _integer2;
    private int _integer3;
    private string _text1;
    private string _text2;
    private string _text3;
    private string _text4;
    private string _text5;
    private string _text6;
    private string _text7;
    private string _text8;
    private string _text9;

    public MainViewModel()
    {
        var now = DateTime.Now;
        DateOnly1 = new DateOnly(now.Year, now.Month, now.Day);
        DateTime1 = now;
        TimeOnly1 = new TimeOnly(now.Hour, now.Minute, now.Second);
        Text1 = "demo";
        Text2 = "demo";
        Text3 = "first";
        Text4 = "second";
        Text5 = "third";
        Text6 = @"C:\Directory\Sub\File.txt";
        Text7 = @"aaa";
        Text8 = @"bbb";
        Text9 = @"ccc";

        Integers = new List<IntegerItem> { new(1), new(2), new(3) };
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

    public DateOnly DateOnly1 { get; }
    public DateTime DateTime1 { get; }
    public TimeOnly TimeOnly1 { get; }

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

    public double Double4
    {
        get => _double4;
        set => NotifyAndSetIfChanged(ref _double4, value);
    }

    public double Double5
    {
        get => _double5;
        set => NotifyAndSetIfChanged(ref _double5, value);
    }

    public string Text1
    {
        get => _text1;
        set => NotifyAndSetIfChanged(ref _text1, value);
    }

    public string Text2
    {
        get => _text2;
        set => NotifyAndSetIfChanged(ref _text2, value);
    }

    public string Text3
    {
        get => _text3;
        set => NotifyAndSetIfChanged(ref _text3, value);
    }

    public string Text4
    {
        get => _text4;
        set => NotifyAndSetIfChanged(ref _text4, value);
    }

    public string Text5
    {
        get => _text5;
        set => NotifyAndSetIfChanged(ref _text5, value);
    }

    public string Text6
    {
        get => _text6;
        set => NotifyAndSetIfChanged(ref _text6, value);
    }

    public string Text7
    {
        get => _text7;
        set => NotifyAndSetIfChanged(ref _text7, value);
    }

    public string Text8
    {
        get => _text8;
        set => NotifyAndSetIfChanged(ref _text8, value);
    }

    public string Text9
    {
        get => _text9;
        set => NotifyAndSetIfChanged(ref _text9, value);
    }

    public int Integer3
    {
        get => _integer3;
        set => NotifyAndSetIfChanged(ref _integer3, value);
    }

    public List<IntegerItem> Integers { get; }
}