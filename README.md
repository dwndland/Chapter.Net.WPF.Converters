# Chapter.Net.WPF.Converters Library

## Overview
Chapter.Net.WPF.Converters provides a bunch of useful converters to be used in XAMLs.

## Features
- **BooleanToIntegerConverter:** Converts an boolean to its integer representation and back.
- **BooleanToVisibilityInvertedConverter:** Converts true to Visible false to Collapsed. (The opposite of BooleanToVisibilityConverter).
- **CountToBooleanConverter:** Converts a count to its boolean representation.
- **CountToVisibilityConverter:** Converts a count to its visibility representation.
- **DateOnlyToStringConverter:** Converts the given date only to a string by Format.
- **DateTimeToStringConverter:** Converts the given date time to a string by Format.
- **DateTimeUtcConverter:** Converts the given date time to universal or local time.
- **DoubleValueToThicknessConverter:** Converts a value to a thickness by telling for what that value it.
- **EqualsToBooleanConverter:** Equals two values and returns its result.
- **EqualsToVisibilityConverter:** Equals two values and returns its visibility representation.
- **IntegerToBooleanConverter:** Converts an integer to its boolean representation and back.
- **InverseBooleanConverter:** Converts a boolean to is opposite.
- **IsLastItemInListConverter:** Checks if the given item container is the last in the list.
- **MultiEqualsToBooleanConverter:** Equals multiple values and returns its result.
- **MultiEqualsToVisibilityConverter:** Equals multiple values and returns its visibility representation.
- **MultiValueToPathConverter:** Combines all given strings into a path.
- **MultiValueToThicknessConverter:** Creates a new thickness object by the given values.
- **NullToBooleanConverter:** Converts the null or not null value to bool with an optional direction parameter.
- **NullToVisibilityConverter:** Converts the null or not null value to Visibility with an optional direction parameter.
- **PathToStringConverter:** Converts a full path to a section from it.
- **TimeOnlyToStringConverter:** Converts the given time only to a string by Format.

## Getting Started

1. **Installation:**
    - Install the Chapter.Net.WPF.Converters library via NuGet Package Manager:
    ```bash
    dotnet add package Chapter.Net.WPF.Converters
    ```

2. **BooleanToIntegerConverter:**
    - Usage
    ```xaml
    <converters:BooleanToIntegerConverter x:Key="BooleanToIntegerConverter" />

    <controls:TitledItem Title="BooleanToIntegerConverter">
        <StackPanel Orientation="Horizontal">
            <CheckBox x:Name="checked1" Content="Checked" />
            <TextBlock Margin="10,0" Text="-&gt;" />
            <TextBlock Text="{Binding IsChecked, ElementName=checked1, Converter={StaticResource BooleanToIntegerConverter}}" />
        </StackPanel>
    </controls:TitledItem>
    ```

3. **BooleanToVisibilityInvertedConverter:**
    - Usage
    ```xaml
    <converters:BooleanToVisibilityInvertedConverter x:Key="BooleanToVisibilityInvertedConverter" />

    <controls:TitledItem Title="BooleanToVisibilityInvertedConverter">
        <StackPanel Orientation="Horizontal">
            <CheckBox x:Name="checked2" Content="Checked" />
            <TextBlock Margin="10,0" Text="-&gt;" />
            <TextBlock Text="{Binding IsChecked, ElementName=checked2, Converter={StaticResource BooleanToVisibilityInvertedConverter}}" />
        </StackPanel>
    </controls:TitledItem>
    ```

4. **CountToBooleanConverter:**
    - Usage
    ```xaml
    <converters:CountToBooleanConverter x:Key="CountToBooleanConverter" />

    <controls:TitledItem Title="CountToBooleanConverter">
        <StackPanel Orientation="Horizontal">
            <TextBox Width="30" Text="{Binding Integer1, UpdateSourceTrigger=PropertyChanged}" />
            <TextBlock Margin="10,0" Text="-&gt;" />
            <TextBlock Text="{Binding Integer1, Converter={StaticResource CountToBooleanConverter}}" />
        </StackPanel>
    </controls:TitledItem>
    ```

5. **CountToVisibilityConverter:**
    - Usage
    ```xaml
    <converters:CountToVisibilityConverter x:Key="CountToVisibilityConverter" />

    <controls:TitledItem Title="CountToVisibilityConverter">
        <StackPanel Orientation="Horizontal">
            <TextBox Width="30" Text="{Binding Integer2, UpdateSourceTrigger=PropertyChanged}" />
            <TextBlock Margin="10,0" Text="-&gt;" />
            <TextBlock Text="{Binding Integer2, Converter={StaticResource CountToVisibilityConverter}}" />
        </StackPanel>
    </controls:TitledItem>
    ```

6. **DateOnlyToStringConverter:**
    - Usage
    ```xaml
    <converters:DateOnlyToStringConverter x:Key="DateOnlyToStringConverter" Format="LongDateString" />

    <controls:TitledItem Title="DateOnlyToStringConverter">
        <StackPanel Orientation="Horizontal">
            <TextBlock Text="LongDateString" />
            <TextBlock Margin="10,0" Text="-&gt;" />
            <TextBlock Text="{Binding DateOnly1, Converter={StaticResource DateOnlyToStringConverter}}" />
        </StackPanel>
    </controls:TitledItem>
    ```

7. **DateTimeToStringConverter:**
    - Usage
    ```xaml
    <converters:DateTimeToStringConverter x:Key="DateTimeToStringConverter" Format="FullDateTimePattern" />

    <controls:TitledItem Title="DateTimeToStringConverter">
        <StackPanel Orientation="Horizontal">
            <TextBlock Text="FullDateTimePattern" />
            <TextBlock Margin="10,0" Text="-&gt;" />
            <TextBlock Text="{Binding DateTime1, Converter={StaticResource DateTimeToStringConverter}}" />
        </StackPanel>
    </controls:TitledItem>
    ```

8. **DateTimeUtcConverter:**
    - Usage
    ```xaml
    <converters:DateTimeUtcConverter x:Key="DateTimeUtcConverter" ToUniversalTime="True" />

    <controls:TitledItem Title="DateTimeUtcConverter">
        <StackPanel Orientation="Horizontal">
            <TextBlock Text="ToUniversalTime" />
            <TextBlock Margin="10,0" Text="-&gt;" />
            <TextBlock Text="{Binding DateTime1, Converter={StaticResource DateTimeUtcConverter}}" />
        </StackPanel>
    </controls:TitledItem>
    ```

9. **DoubleValueToThicknessConverter:**
    - Usage
    ```xaml
    <converters:DoubleValueToThicknessConverter x:Key="DoubleValueToThicknessConverter" Position="LeftRight" />

    <controls:TitledItem Title="DoubleValueToThicknessConverter">
        <StackPanel Orientation="Horizontal">
            <TextBox Width="30" Text="{Binding Double1, UpdateSourceTrigger=PropertyChanged}" />
            <TextBlock Margin="10,0" Text="-&gt;" />
            <TextBlock Text="{Binding Double1, Converter={StaticResource DoubleValueToThicknessConverter}}" />
        </StackPanel>
    </controls:TitledItem>
    ```

10. **EqualsToBooleanConverter:**
    - Usage
    ```xaml
    <converters:EqualsToBooleanConverter x:Key="EqualsToBooleanConverter" />

    <controls:TitledItem Title="EqualsToBooleanConverter">
        <StackPanel Orientation="Horizontal">
            <TextBox Width="50" Text="{Binding Text1, UpdateSourceTrigger=PropertyChanged}" />
            <TextBlock Margin="10,0" Text="-&gt;" />
            <TextBlock Text="{Binding Text1, ConverterParameter=demo, Converter={StaticResource EqualsToBooleanConverter}}" />
        </StackPanel>
    </controls:TitledItem>
    ```

11. **EqualsToVisibilityConverter:**
    - Usage
    ```xaml
    <converters:EqualsToVisibilityConverter x:Key="EqualsToVisibilityConverter" />

    <controls:TitledItem Title="EqualsToVisibilityConverter">
        <StackPanel Orientation="Horizontal">
            <TextBox Width="50" Text="{Binding Text2, UpdateSourceTrigger=PropertyChanged}" />
            <TextBlock Margin="10,0" Text="-&gt;" />
            <TextBlock Text="{Binding Text2, ConverterParameter=demo, Converter={StaticResource EqualsToVisibilityConverter}}" />
        </StackPanel>
    </controls:TitledItem>
    ```

12. **IntegerToBooleanConverter:**
    - Usage
    ```xaml
    <converters:IntegerToBooleanConverter x:Key="IntegerToBooleanConverter" />

    <controls:TitledItem Title="IntegerToBooleanConverter">
        <StackPanel Orientation="Horizontal">
            <TextBox Width="30" Text="{Binding Integer3, UpdateSourceTrigger=PropertyChanged}" />
            <TextBlock Margin="10,0" Text="-&gt;" />
            <TextBlock Text="{Binding Integer3, Converter={StaticResource IntegerToBooleanConverter}}" />
        </StackPanel>
    </controls:TitledItem>
    ```

13. **InverseBooleanConverter:**
    - Usage
    ```xaml
    <converters:InverseBooleanConverter x:Key="InverseBooleanConverter" />

    <controls:TitledItem Title="InverseBooleanConverter">
        <StackPanel Orientation="Horizontal">
            <CheckBox x:Name="checked3" Content="Checked" />
            <TextBlock Margin="10,0" Text="-&gt;" />
            <TextBlock Text="{Binding IsChecked, ElementName=checked3, Converter={StaticResource InverseBooleanConverter}}" />
        </StackPanel>
    </controls:TitledItem>
    ```

14. **IsLastItemInListConverter:**
    - Usage
    ```xaml
    <converters:IsLastItemInListConverter x:Key="IsLastItemInListConverter" />

    <controls:TitledItem Title="IsLastItemInListConverter">
        <DataGrid HorizontalAlignment="Left"
                  AutoGenerateColumns="False"
                  CanUserAddRows="False"
                  HeadersVisibility="Column"
                  ItemsSource="{Binding Integers}">
            <DataGrid.ItemContainerStyle>
                <Style TargetType="{x:Type DataGridRow}">
                    <Setter Property="Background" Value="White" />
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type DataGridRow}">
                                <Border Background="{TemplateBinding Background}">
                                    <DataGridCellsPresenter />
                                </Border>
                                <ControlTemplate.Triggers>
                                    <DataTrigger Binding="{Binding RelativeSource={RelativeSource Self}, Converter={StaticResource IsLastItemInListConverter}}" Value="True">
                                        <Setter Property="Background" Value="Yellow" />
                                    </DataTrigger>
                                </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </DataGrid.ItemContainerStyle>
            <DataGrid.Columns>
                <DataGridTextColumn Width="100"
                                    Binding="{Binding Value}"
                                    Header="Value"
                                    SortMemberPath="Value" />
            </DataGrid.Columns>
        </DataGrid>
    </controls:TitledItem>
    ```

15. **MultiEqualsToBooleanConverter:**
    - Usage
    ```xaml
    <converters:MultiEqualsToBooleanConverter x:Key="MultiEqualsToBooleanConverter" />

    <controls:TitledItem Title="MultiEqualsToBooleanConverter">
        <StackPanel Orientation="Horizontal">
            <StackPanel>
                <CheckBox x:Name="checked4" Content="Checked" />
                <CheckBox x:Name="checked5" Content="Checked" />
                <CheckBox x:Name="checked6" Content="Checked" />
            </StackPanel>
            <TextBlock Margin="10,0"
                       VerticalAlignment="Center"
                       Text="-&gt;" />
            <CheckBox VerticalAlignment="Center"
                      Content="Are Equal"
                      IsEnabled="False">
                <CheckBox.IsChecked>
                    <MultiBinding Converter="{StaticResource MultiEqualsToBooleanConverter}">
                        <Binding ElementName="checked4" Path="IsChecked" />
                        <Binding ElementName="checked5" Path="IsChecked" />
                        <Binding ElementName="checked6" Path="IsChecked" />
                    </MultiBinding>
                </CheckBox.IsChecked>
            </CheckBox>
        </StackPanel>
    </controls:TitledItem>
    ```

16. **MultiEqualsToVisibilityConverter:**
    - Usage
    ```xaml
    <converters:MultiEqualsToVisibilityConverter x:Key="MultiEqualsToVisibilityConverter" />

    <controls:TitledItem Title="MultiEqualsToVisibilityConverter">
        <StackPanel Orientation="Horizontal">
            <StackPanel>
                <CheckBox x:Name="checked7" Content="Checked" />
                <CheckBox x:Name="checked8" Content="Checked" />
                <CheckBox x:Name="checked9" Content="Checked" />
            </StackPanel>
            <TextBlock Margin="10,0"
                       VerticalAlignment="Center"
                       Text="-&gt;" />
            <TextBlock VerticalAlignment="Center" Text="IsVisible">
                <TextBlock.Visibility>
                    <MultiBinding Converter="{StaticResource MultiEqualsToVisibilityConverter}">
                        <Binding ElementName="checked7" Path="IsChecked" />
                        <Binding ElementName="checked8" Path="IsChecked" />
                        <Binding ElementName="checked9" Path="IsChecked" />
                    </MultiBinding>
                </TextBlock.Visibility>
            </TextBlock>
        </StackPanel>
    </controls:TitledItem>
    ```

17. **MultiValueToPathConverter:**
    - Usage
    ```xaml
    <converters:MultiValueToPathConverter x:Key="MultiValueToPathConverter" />

    <controls:TitledItem Title="MultiValueToPathConverter">
        <StackPanel Orientation="Horizontal">
            <StackPanel>
                <TextBox Width="100" Text="{Binding Text3, UpdateSourceTrigger=PropertyChanged}" />
                <TextBox Width="100" Text="{Binding Text4, UpdateSourceTrigger=PropertyChanged}" />
                <TextBox Width="100" Text="{Binding Text5, UpdateSourceTrigger=PropertyChanged}" />
            </StackPanel>
            <TextBlock Margin="10,0"
                       VerticalAlignment="Center"
                       Text="-&gt;" />
            <TextBlock VerticalAlignment="Center">
                <TextBlock.Text>
                    <MultiBinding Converter="{StaticResource MultiValueToPathConverter}">
                        <Binding Path="Text3" />
                        <Binding Path="Text4" />
                        <Binding Path="Text5" />
                    </MultiBinding>
                </TextBlock.Text>
            </TextBlock>
        </StackPanel>
    </controls:TitledItem>
    ```

18. **MultiValueToThicknessConverter:**
    - Usage
    ```xaml
    <converters:MultiValueToThicknessConverter x:Key="MultiValueToThicknessConverter" />

    <controls:TitledItem Title="MultiValueToThicknessConverter">
        <StackPanel Orientation="Horizontal">
            <StackPanel>
                <TextBox Width="30" Text="{Binding Double2, UpdateSourceTrigger=PropertyChanged}" />
                <TextBox Width="30" Text="{Binding Double3, UpdateSourceTrigger=PropertyChanged}" />
                <TextBox Width="30" Text="{Binding Double4, UpdateSourceTrigger=PropertyChanged}" />
                <TextBox Width="30" Text="{Binding Double5, UpdateSourceTrigger=PropertyChanged}" />
            </StackPanel>
            <TextBlock Margin="10,0"
                       VerticalAlignment="Center"
                       Text="-&gt;" />
            <Border VerticalAlignment="Center"
                    BorderBrush="Gray"
                    BorderThickness="1">
                <TextBlock Text="Margin">
                    <TextBlock.Margin>
                        <MultiBinding Converter="{StaticResource MultiValueToThicknessConverter}">
                            <Binding Path="Double2" />
                            <Binding Path="Double3" />
                            <Binding Path="Double4" />
                            <Binding Path="Double5" />
                        </MultiBinding>
                    </TextBlock.Margin>
                </TextBlock>
            </Border>
        </StackPanel>
    </controls:TitledItem>
    ```

19. **NullToBooleanConverter:**
    - Usage
    ```xaml
    <converters:NullToBooleanConverter x:Key="NullToBooleanConverter" Direction="NullIsTrue" />

    <controls:TitledItem Title="NullToBooleanConverter">
        <StackPanel Orientation="Horizontal">
            <CheckBox x:Name="checked10"
                      Content="Checked"
                      IsThreeState="True" />
            <TextBlock Margin="10,0" Text="-&gt;" />
            <TextBlock Text="{Binding IsChecked, ElementName=checked10, Converter={StaticResource NullToBooleanConverter}}" />
        </StackPanel>
    </controls:TitledItem>
    ```

20. **NullToVisibilityConverter:**
    - Usage
    ```xaml
    <converters:NullToVisibilityConverter x:Key="NullToVisibilityConverter" Direction="NullIsVisible" />

    <controls:TitledItem Title="NullToVisibilityConverter">
        <StackPanel Orientation="Horizontal">
            <CheckBox x:Name="checked11"
                      Content="Checked"
                      IsThreeState="True" />
            <TextBlock Margin="10,0" Text="-&gt;" />
            <TextBlock Text="{Binding IsChecked, ElementName=checked11, Converter={StaticResource NullToVisibilityConverter}}" />
        </StackPanel>
    </controls:TitledItem>
    ```

21. **PathToStringConverter:**
    - Usage
    ```xaml
    <converters:PathToStringConverter x:Key="PathToStringConverter" Section="Directory" />

    <controls:TitledItem Title="PathToStringConverter">
        <StackPanel Orientation="Horizontal">
            <TextBox Width="200" Text="{Binding Text6, UpdateSourceTrigger=PropertyChanged}" />
            <TextBlock Margin="10,0" Text="-&gt;" />
            <TextBlock Text="{Binding Text6, ConverterParameter=demo, Converter={StaticResource PathToStringConverter}}" />
        </StackPanel>
    </controls:TitledItem>
    ```

22. **TimeOnlyToStringConverter:**
    - Usage
    ```xaml
    <converters:TimeOnlyToStringConverter x:Key="TimeOnlyToStringConverter" Format="ToLongTimeString" />

    <controls:TitledItem Title="TimeOnlyToStringConverter">
        <StackPanel Orientation="Horizontal">
            <TextBlock Text="ToLongTimeString" />
            <TextBlock Margin="10,0" Text="-&gt;" />
            <TextBlock Text="{Binding TimeOnly1, Converter={StaticResource TimeOnlyToStringConverter}}" />
        </StackPanel>
    </controls:TitledItem>
    ```

## Links
* [NuGet](https://www.nuget.org/packages/Chapter.Net.WPF.Converters)
* [GitHub](https://github.com/dwndland/Chapter.Net.WPF.Converters)

## License
Copyright (c) David Wendland. All rights reserved.
Licensed under the MIT License. See LICENSE file in the project root for full license information.
