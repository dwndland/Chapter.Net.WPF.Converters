// 
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 

namespace Demo;

public partial class MainView
{
    public MainView()
    {
        InitializeComponent();

        DataContext = new MainViewModel();
    }
}