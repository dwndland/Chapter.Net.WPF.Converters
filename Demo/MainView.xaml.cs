﻿// -----------------------------------------------------------------------------------------------------------------
// <copyright file="MainView.xaml.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

namespace Demo;

public partial class MainView
{
    public MainView()
    {
        InitializeComponent();

        DataContext = new MainViewModel();
    }
}