# Chapter.Net.WPF.Converters Library

## Overview
Chapter.Net.WPF.Converters provides a bunch of useful converters to be used in XAMLs.

## Features
- **Override** Override any converter to change their behavior.
- **BooleanToBooleanConverter** Converts a single boolean or a list of booleans to another single boolean representation.
- **BooleanToIntegerConverter** Converts a single boolean or a list of booleans to an integer representation.
- **BooleanToVisibilityConverter** Converts a single boolean or a list of booleans into a Visibility representation.
- **CharacterCheckToBooleanConverter** Executes a check on a single character or list of characters and returns a boolean representation of that result.
- **CharacterCheckToVisibilityConverter** Executes a check on a single character or list of characters and returns a Visibility representation of that result.
- **ConcatenateStringConverter** Concatenates all given values to a single string with an optional configurable separator.
- **DateOnlyToStringConverter** Formats a single DateOnly to a string.
- **DateTimeToStringConverter** Formats a single DateTime to a string.
- **DateTimeUtcConverter** Converts the given date time to universal or local time.
- **DoubleComparisonToBooleanConverter** Executes a comparison on a single double or list of doubles to a boolean representation.
- **DoubleComparisonToVisibilityConverter** Executes a comparison on a single Visibility or list of Visibilities to a boolean representation.
- **DoubleMathConverter** Does a simple calculation with the given value as double.
- **DoubleToStringConverter** Formats a double to string.
- **DoubleToThicknessConverter** to build a Thickness object by a given single double value.
- **EqualsToBooleanConverter** Compares a single value to a variable or a list of values to each other and returns its boolean representation.
- **EqualsToVisibilityConverter** Compares a single value to a variable or a list of values to each other and returns its Visibility representation.
- **IntegerComparisonToBooleanConverter** Executes a comparison on a single integer or list of integers to a boolean representation.
- **IntegerComparisonToVisibilityConverter** Executes a comparison on a single integer or list of integers to a Visibility representation.
- **IntegerMathConverter** Does a simple calculation with the given value as integer.
- **IntegerToBooleanConverter** Converts a single integer or a list of integers to a boolean representation.
- **IntegerToStringConverter** Formats an integer to string.
- **IsLastItemInListConverter** Checks if the given item container is the last in the list.
- **IsNullToBooleanConverter** Checks if a single object or a list of objects is null and returns a boolean representation.
- **IsNullToVisibilityConverter** Checks if a single object or a list of objects is null and returns a Visibility representation.
- **NumberCheckToBooleanConverter** Executes a check on a single number or list of numbers and returns a boolean representation of that result.
- **NumberCheckToVisibilityConverter** Executes a check on a single number or list of numbers and returns a Visibility representation of that result.
- **ObjectToTypeConverter** Returns the type of the given object.
- **PathToStringConverter** Reads out part of a given path.
- **RoundingConverter** Rounds the given value as double.
- **StringCheckToBooleanConverter** Executes a check on a single string or list of strings and returns a boolean representation of that result.
- **StringCheckToVisibilityConverter** Executes a check on a single string or list of strings and returns a Visibility representation of that result.
- **StringToLowerConverter** Converts the given value as string to lower.
- **StringToUpperConverter** Converts the given value as string to upper.
- **TimeOnlyToStringConverter** Formats a single TimeOnly to a string.
- **ValueToPathConverter** Combines all given strings into a path.

## Getting Started

1. **Installation:**
    - Install the Chapter.Net.WPF.Converters library via NuGet Package Manager:
    ```bash
    dotnet add package Chapter.Net.WPF.Converters
    ```

2. **Override:**
    - Override any converter to change their behavior.
    ```csharp
    public class MyConcatenateStringConverter : ConcatenateStringConverter
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            values = values.Distinct().ToArray();
            var converted = base.Convert(values, targetType, parameter, culture);
            return "Result: " + converted;
        }
    }
    ```

3. **BooleanToBooleanConverter**
    - Converts a single boolean or a list of booleans to another single boolean representation.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleBooleanToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:BooleanToBooleanConverter x:Key="SingleBooleanToBooleanConverter"
                                                  FalseIs="True"
                                                  TrueIs="False" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="BooleanToBooleanConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <CheckBox Content="Check Me" IsChecked="{Binding IsChecked1}" />
                <TextBlock Margin="10,0" Text="&lt;-&gt;" />
                <CheckBox Content="Check Me" IsChecked="{Binding IsChecked1, Converter={StaticResource SingleBooleanToBooleanConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multiple -->
    <Border DataContext="{Binding MultiBooleanToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:BooleanToBooleanConverter x:Key="MultiBooleanToBooleanConverter"
                                                  FalseIs="False"
                                                  MixedIs="{x:Null}"
                                                  TrueIs="True" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="BooleanToBooleanConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <CheckBox Content="Check Me" IsChecked="{Binding IsChecked1}" />
                    <CheckBox Content="Check Me" IsChecked="{Binding IsChecked2}" />
                    <CheckBox Content="Check Me" IsChecked="{Binding IsChecked3}" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="&lt;-&gt;" />
                <CheckBox VerticalAlignment="Center"
                          Content="See Me"
                          IsEnabled="False">
                    <CheckBox.IsChecked>
                        <MultiBinding Converter="{StaticResource MultiBooleanToBooleanConverter}">
                            <Binding Path="IsChecked1" />
                            <Binding Path="IsChecked2" />
                            <Binding Path="IsChecked3" />
                        </MultiBinding>
                    </CheckBox.IsChecked>
                </CheckBox>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

4. **BooleanToIntegerConverter**
    - Converts a single boolean or a list of booleans to an integer representation.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleBooleanToIntegerConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:BooleanToIntegerConverter x:Key="SingleBooleanToIntegerConverter" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="BooleanToIntegerConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <CheckBox Content="Check Me" IsChecked="{Binding IsChecked1}" />
                <TextBlock Margin="10,0" Text="&lt;-&gt;" />
                <TextBlock Text="{Binding IsChecked1, Converter={StaticResource SingleBooleanToIntegerConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiBooleanToIntegerConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:BooleanToIntegerConverter x:Key="MultiBooleanToIntegerConverter" MixedIs="-1" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="BooleanToIntegerConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <CheckBox Content="Check Me" IsChecked="{Binding IsChecked1}" />
                    <CheckBox Content="Check Me" IsChecked="{Binding IsChecked2}" />
                    <CheckBox Content="Check Me" IsChecked="{Binding IsChecked3}" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="&lt;-&gt;" />
                <ContentControl VerticalAlignment="Center">
                    <ContentControl.Content>
                        <MultiBinding Converter="{StaticResource MultiBooleanToIntegerConverter}">
                            <Binding Path="IsChecked1" />
                            <Binding Path="IsChecked2" />
                            <Binding Path="IsChecked3" />
                        </MultiBinding>
                    </ContentControl.Content>
                </ContentControl>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

5. **BooleanToVisibilityConverter**
    - Converts a single boolean or a list of booleans into a Visibility representation.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleBooleanToVisibilityConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:BooleanToVisibilityConverter x:Key="SingleBooleanToVisibilityConverter"
                                                     FalseIs="Visible"
                                                     TrueIs="Collapsed" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="BooleanToVisibilityConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <CheckBox Content="Check Me" IsChecked="{Binding IsChecked1}" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <Border Width="50"
                        Height="10"
                        Background="Gray"
                        Visibility="{Binding IsChecked1, Converter={StaticResource SingleBooleanToVisibilityConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiBooleanToVisibilityConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:BooleanToVisibilityConverter x:Key="MultiBooleanToVisibilityConverter"
                                                     FalseIs="Collapsed"
                                                     MixedIs="Hidden"
                                                     TrueIs="Visible" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="BooleanToVisibilityConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <CheckBox Content="Check Me" IsChecked="{Binding IsChecked1}" />
                    <CheckBox Content="Check Me" IsChecked="{Binding IsChecked2}" />
                    <CheckBox Content="Check Me" IsChecked="{Binding IsChecked3}" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <Border VerticalAlignment="Center"
                        BorderBrush="Gray"
                        BorderThickness="1">
                    <Border Width="50"
                            Height="10"
                            Background="Gray">
                        <Border.Visibility>
                            <MultiBinding Converter="{StaticResource MultiBooleanToVisibilityConverter}">
                                <Binding Path="IsChecked1" />
                                <Binding Path="IsChecked2" />
                                <Binding Path="IsChecked3" />
                            </MultiBinding>
                        </Border.Visibility>
                    </Border>
                </Border>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

6. **CharacterCheckToBooleanConverter**
    - Executes a check on a single character or list of characters and returns a boolean representation of that result.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleCharacterCheckToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:CharacterCheckToBooleanConverter x:Key="SingleCharacterCheckToBooleanConverter1" CheckType="IsLetter" />
            <converters:CharacterCheckToBooleanConverter x:Key="SingleCharacterCheckToBooleanConverter2" CheckType="IsDigit" />
            <converters:CharacterCheckToBooleanConverter x:Key="SingleCharacterCheckToBooleanConverter3" CheckType="IsLetterOrDigit" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="CharacterCheckToBooleanConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <ContentControl Content="{Binding Character1}" />
                    <ContentControl Content="{Binding Character2}" />
                    <ContentControl Content="{Binding Character3}" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <StackPanel>
                    <CheckBox Content="See Me"
                              IsChecked="{Binding Character1, Converter={StaticResource SingleCharacterCheckToBooleanConverter1}}"
                              IsEnabled="False" />
                    <CheckBox Content="See Me"
                              IsChecked="{Binding Character2, Converter={StaticResource SingleCharacterCheckToBooleanConverter2}}"
                              IsEnabled="False" />
                    <CheckBox Content="See Me"
                              IsChecked="{Binding Character3, Converter={StaticResource SingleCharacterCheckToBooleanConverter3}}"
                              IsEnabled="False" />
                </StackPanel>
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiCharacterCheckToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:CharacterCheckToBooleanConverter x:Key="MultiCharacterCheckToBooleanConverter" CheckType="IsLetterOrDigit" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="CharacterCheckToBooleanConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <ContentControl Content="{Binding Character1}" />
                    <ContentControl Content="{Binding Character2}" />
                    <ContentControl Content="{Binding Character3}" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <CheckBox VerticalAlignment="Center"
                          VerticalContentAlignment="Center"
                          Content="See Me"
                          IsEnabled="False">
                    <CheckBox.IsChecked>
                        <MultiBinding Converter="{StaticResource MultiCharacterCheckToBooleanConverter}">
                            <Binding Path="Character1" />
                            <Binding Path="Character2" />
                            <Binding Path="Character3" />
                        </MultiBinding>
                    </CheckBox.IsChecked>
                </CheckBox>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

7. **CharacterCheckToVisibilityConverter**
    - Executes a check on a single character or list of characters and returns a Visibility representation of that result.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleCharacterCheckToVisibilityConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:CharacterCheckToVisibilityConverter x:Key="SingleCharacterCheckToVisibilityConverter" CheckType="IsLetterOrDigit" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="CharacterCheckToVisibilityConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <ContentControl Content="{Binding Character1}" />
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <Border Width="50"
                        Height="10"
                        VerticalAlignment="Center"
                        Background="Gray"
                        Visibility="{Binding Character1, Converter={StaticResource SingleCharacterCheckToVisibilityConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiCharacterCheckToVisibilityConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:CharacterCheckToVisibilityConverter x:Key="MultiCharacterCheckToVisibilityConverter" CheckType="IsLetterOrDigit" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="CharacterCheckToVisibilityConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <ContentControl Content="{Binding Character1}" />
                    <ContentControl Content="{Binding Character2}" />
                    <ContentControl Content="{Binding Character3}" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <Border Width="50"
                        Height="10"
                        VerticalAlignment="Center"
                        Background="Gray">
                    <Border.Visibility>
                        <MultiBinding Converter="{StaticResource MultiCharacterCheckToVisibilityConverter}">
                            <Binding Path="Character1" />
                            <Binding Path="Character2" />
                            <Binding Path="Character3" />
                        </MultiBinding>
                    </Border.Visibility>
                </Border>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

8. **ConcatenateStringConverter**
    - Concatenates all given values to a single string with an optional configurable separator.
    ```xaml
    <Border DataContext="{Binding ConcatenateStringConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:ConcatenateStringConverter x:Key="ConcatenateStringConverter" Separator="-" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="ConcatenateStringConverter" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <TextBox Width="100" Text="{Binding String1, UpdateSourceTrigger=PropertyChanged}" />
                    <TextBox Width="100" Text="{Binding String2, UpdateSourceTrigger=PropertyChanged}" />
                    <TextBox Width="100" Text="{Binding String3, UpdateSourceTrigger=PropertyChanged}" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <TextBlock VerticalAlignment="Center">
                    <TextBlock.Text>
                        <MultiBinding Converter="{StaticResource ConcatenateStringConverter}">
                            <Binding Path="String1" />
                            <Binding Path="String2" />
                            <Binding Path="String3" />
                        </MultiBinding>
                    </TextBlock.Text>
                </TextBlock>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

9. **DateOnlyToStringConverter**
    - Formats a single DateOnly to a string.
    ```xaml
    <Border DataContext="{Binding DateOnlyToStringConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:DateOnlyToStringConverter x:Key="DateOnlyToStringConverter1" Format="LongDateString" />
            <converters:DateOnlyToStringConverter x:Key="DateOnlyToStringConverter2" Format="ShortDateString" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="DateOnlyToStringConverter" />
            <StackPanel Orientation="Horizontal">
                <TextBlock Text="{Binding DateOnly, Converter={StaticResource DateOnlyToStringConverter1}}" />
                <TextBlock Margin="10,0" Text="|" />
                <TextBlock Text="{Binding DateOnly, Converter={StaticResource DateOnlyToStringConverter2}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```

10. **DateTimeToStringConverter**
    - Formats a single DateTime to a string.
    ```xaml
    <Border DataContext="{Binding DateTimeToStringConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:DateTimeToStringConverter x:Key="DateTimeToStringConverter1" Format="FullDateTimePattern" />
            <converters:DateTimeToStringConverter x:Key="DateTimeToStringConverter2" Format="ShortDateString" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="DateTimeToStringConverter" />
            <StackPanel Orientation="Horizontal">
                <TextBlock Text="{Binding DateTime, Converter={StaticResource DateTimeToStringConverter1}}" />
                <TextBlock Margin="10,0" Text="|" />
                <TextBlock Text="{Binding DateTime, Converter={StaticResource DateTimeToStringConverter2}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```

11. **DateTimeUtcConverter**
    - Converts the given date time to universal or local time.
    ```xaml
    <Border DataContext="{Binding DateTimeUtcConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:DateTimeUtcConverter x:Key="DateTimeUtcConverter1" ToUniversalTime="False" />
            <converters:DateTimeUtcConverter x:Key="DateTimeUtcConverter2" ToUniversalTime="True" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="DateTimeUtcConverter" />
            <StackPanel Orientation="Horizontal">
                <TextBlock Text="{Binding DateTime, Converter={StaticResource DateTimeUtcConverter1}}" />
                <TextBlock Margin="10,0" Text="|" />
                <TextBlock Text="{Binding DateTime, Converter={StaticResource DateTimeUtcConverter2}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```

12. **DoubleComparisonToBooleanConverter**
    - Executes a comparison on a single double or list of doubles to a boolean representation.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleDoubleComparisonToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:DoubleComparisonToBooleanConverter x:Key="SingleDoubleComparisonToBooleanConverter"
                                                           ComparisonType="BiggerThan"
                                                           Variable="5" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="DoubleComparisonToBooleanConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <controls:NumberBox Width="40"
                                    Number="{Binding Double1}"
                                    NumberType="Double"
                                    UpDownBehavior="ArrowsAndButtons" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <CheckBox Content="See Me"
                          IsChecked="{Binding Double1, Converter={StaticResource SingleDoubleComparisonToBooleanConverter}}"
                          IsEnabled="False" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiDoubleComparisonToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:DoubleComparisonToBooleanConverter x:Key="MultiDoubleComparisonToBooleanConverter"
                                                           ComparisonType="BiggerThan"
                                                           Variable="5" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="DoubleComparisonToBooleanConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double1}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double2}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double3}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <CheckBox VerticalAlignment="Center"
                          Content="See Me"
                          IsEnabled="False">
                    <CheckBox.IsChecked>
                        <MultiBinding Converter="{StaticResource MultiDoubleComparisonToBooleanConverter}">
                            <Binding Path="Double1" />
                            <Binding Path="Double2" />
                            <Binding Path="Double3" />
                        </MultiBinding>
                    </CheckBox.IsChecked>
                </CheckBox>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

13. **DoubleComparisonToVisibilityConverter**
    - Executes a comparison on a single Visibility or list of Visibilities to a boolean representation.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleDoubleComparisonToVisibilityConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:DoubleComparisonToVisibilityConverter x:Key="SingleDoubleComparisonToVisibilityConverter"
                                                              ComparisonType="BiggerThan"
                                                              Variable="5" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="DoubleComparisonToVisibilityConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <controls:NumberBox Width="40"
                                    Number="{Binding Double1}"
                                    NumberType="Double"
                                    UpDownBehavior="ArrowsAndButtons" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <Border Width="50"
                        Height="10"
                        Background="Gray"
                        Visibility="{Binding Double1, Converter={StaticResource SingleDoubleComparisonToVisibilityConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiDoubleComparisonToVisibilityConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:DoubleComparisonToVisibilityConverter x:Key="MultiDoubleComparisonToVisibilityConverter"
                                                              ComparisonType="BiggerThan"
                                                              Variable="5" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="DoubleComparisonToVisibilityConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double1}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double2}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double3}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <Border VerticalAlignment="Center"
                        BorderBrush="Gray"
                        BorderThickness="1">
                    <Border Width="50"
                            Height="10"
                            Background="Gray">
                        <Border.Visibility>
                            <MultiBinding Converter="{StaticResource MultiDoubleComparisonToVisibilityConverter}">
                                <Binding Path="Double1" />
                                <Binding Path="Double2" />
                                <Binding Path="Double3" />
                            </MultiBinding>
                        </Border.Visibility>
                    </Border>
                </Border>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

14. **DoubleMathConverter**
    - Does a simple calculation with the given value as double.
    ```xaml
    <Border DataContext="{Binding DoubleMathConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:DoubleMathConverter x:Key="DoubleMathConverter"
                                            Calculation="Multiplication"
                                            Variable="2" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="DoubleMathConverter" />
            <StackPanel Orientation="Horizontal">
                <controls:NumberBox Width="40"
                                    Number="{Binding Double1}"
                                    NumberType="Double"
                                    UpDownBehavior="ArrowsAndButtons" />
                <TextBlock Margin="10,0" Text="&lt;-&gt;" />
                <controls:NumberBox Width="40"
                                    Number="{Binding Double1, Converter={StaticResource DoubleMathConverter}}"
                                    NumberType="Double"
                                    UpDownBehavior="ArrowsAndButtons" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```

15. **DoubleToStringConverter**
    - Formats a double to string.
    ```xaml
    <Border DataContext="{Binding DoubleToStringConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:DoubleToStringConverter x:Key="DoubleToStringConverter"
                                                DecimalCount="2"
                                                Digits="3" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="DoubleToStringConverter" />
            <StackPanel Orientation="Horizontal">
                <controls:NumberBox Width="40"
                                    Number="{Binding Double1}"
                                    NumberType="Double"
                                    UpDownBehavior="ArrowsAndButtons" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <ContentControl Content="{Binding Double1, Converter={StaticResource DoubleToStringConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```

16. **DoubleToThicknessConverter**
    - Builds a Thickness object by a given single double value.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleDoubleToThicknessConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:DoubleToThicknessConverter x:Key="SingleDoubleToThicknessConverter" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="DoubleToThicknessConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <controls:NumberBox Width="40"
                                    Number="{Binding Double1}"
                                    NumberType="Double"
                                    UpDownBehavior="ArrowsAndButtons" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <Border VerticalAlignment="Center"
                        BorderBrush="Gray"
                        BorderThickness="1">
                    <Border Width="50"
                            Height="10"
                            Margin="{Binding Double1, Converter={StaticResource SingleDoubleToThicknessConverter}}"
                            Background="Gray" />
                </Border>
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiDoubleToThicknessConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:DoubleToThicknessConverter x:Key="MultiDoubleToThicknessConverter" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="DoubleToThicknessConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double1}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double2}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <Border VerticalAlignment="Center"
                        BorderBrush="Gray"
                        BorderThickness="1">
                    <Border Width="50"
                            Height="10"
                            Background="Gray">
                        <Border.Margin>
                            <MultiBinding Converter="{StaticResource MultiDoubleToThicknessConverter}">
                                <Binding Path="Double1" />
                                <Binding Path="Double2" />
                            </MultiBinding>
                        </Border.Margin>
                    </Border>
                </Border>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

17. **EqualsToBooleanConverter**
    - Compares a single value to a variable or a list of values to each other and returns its boolean representation.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleEqualsToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:EqualsToBooleanConverter x:Key="SingleEqualsToBooleanConverter">
                <converters:EqualsToBooleanConverter.CompareWith>
                    <system:Double>5</system:Double>
                </converters:EqualsToBooleanConverter.CompareWith>
            </converters:EqualsToBooleanConverter>
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="EqualsToBooleanConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <controls:NumberBox Width="40"
                                    Number="{Binding Double1}"
                                    NumberType="Double"
                                    UpDownBehavior="ArrowsAndButtons" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <CheckBox VerticalAlignment="Center"
                          Content="See Me"
                          IsChecked="{Binding Double1, Converter={StaticResource SingleEqualsToBooleanConverter}}"
                          IsEnabled="False" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiEqualsToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:EqualsToBooleanConverter x:Key="MultiEqualsToBooleanConverter" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="EqualsToBooleanConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double1}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double2}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double3}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <CheckBox VerticalAlignment="Center"
                            Content="See Me"
                            IsEnabled="False">
                    <CheckBox.IsChecked>
                        <MultiBinding Converter="{StaticResource MultiEqualsToBooleanConverter}">
                            <Binding Path="Double1" />
                            <Binding Path="Double2" />
                            <Binding Path="Double3" />
                        </MultiBinding>
                    </CheckBox.IsChecked>
                </CheckBox>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

18. **EqualsToVisibilityConverter**
    - Compares a single value to a variable or a list of values to each other and returns its Visibility representation.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleEqualsToVisibilityConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:EqualsToVisibilityConverter x:Key="SingleEqualsToVisibilityConverter">
                <converters:EqualsToVisibilityConverter.CompareWith>
                    <system:Double>5</system:Double>
                </converters:EqualsToVisibilityConverter.CompareWith>
            </converters:EqualsToVisibilityConverter>
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="EqualsToVisibilityConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <controls:NumberBox Width="40"
                                    Number="{Binding Double1}"
                                    NumberType="Double"
                                    UpDownBehavior="ArrowsAndButtons" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <Border Width="50"
                        Height="10"
                        Background="Gray"
                        Visibility="{Binding Double1, Converter={StaticResource SingleEqualsToVisibilityConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiEqualsToVisibilityConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:EqualsToVisibilityConverter x:Key="MultiEqualsToVisibilityConverter" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="EqualsToVisibilityConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double1}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double2}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double3}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <Border Width="50"
                        Height="10"
                        Background="Gray">
                    <Border.Visibility>
                        <MultiBinding Converter="{StaticResource MultiEqualsToVisibilityConverter}">
                            <Binding Path="Double1" />
                            <Binding Path="Double2" />
                            <Binding Path="Double3" />
                        </MultiBinding>
                    </Border.Visibility>
                </Border>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

19. **IntegerComparisonToBooleanConverter**
    - Executes a comparison on a single integer or list of integers to a boolean representation.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleIntegerComparisonToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:IntegerComparisonToBooleanConverter x:Key="SingleIntegerComparisonToBooleanConverter"
                                                            ComparisonType="BiggerThan"
                                                            Variable="5" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="IntegerComparisonToBooleanConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <controls:NumberBox Width="40"
                                    Number="{Binding Integer1}"
                                    NumberType="Int"
                                    UpDownBehavior="ArrowsAndButtons" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <CheckBox Content="See Me"
                          IsChecked="{Binding Integer1, Converter={StaticResource SingleIntegerComparisonToBooleanConverter}}"
                          IsEnabled="False" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiIntegerComparisonToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:IntegerComparisonToBooleanConverter x:Key="MultiIntegerComparisonToBooleanConverter"
                                                            ComparisonType="BiggerThan"
                                                            Variable="5" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="IntegerComparisonToBooleanConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <controls:NumberBox Width="40"
                                        Number="{Binding Integer1}"
                                        NumberType="Int"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Integer2}"
                                        NumberType="Int"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Integer3}"
                                        NumberType="Int"
                                        UpDownBehavior="ArrowsAndButtons" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <CheckBox VerticalAlignment="Center"
                          Content="See Me"
                          IsEnabled="False">
                    <CheckBox.IsChecked>
                        <MultiBinding Converter="{StaticResource MultiIntegerComparisonToBooleanConverter}">
                            <Binding Path="Integer1" />
                            <Binding Path="Integer2" />
                            <Binding Path="Integer3" />
                        </MultiBinding>
                    </CheckBox.IsChecked>
                </CheckBox>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

20. **IntegerComparisonToVisibilityConverter**
    - Executes a comparison on a single integer or list of integers to a Visibility representation.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleIntegerComparisonToVisibilityConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:IntegerComparisonToVisibilityConverter x:Key="SingleIntegerComparisonToVisibilityConverter"
                                                               ComparisonType="BiggerThan"
                                                               Variable="5" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="IntegerComparisonToVisibilityConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <controls:NumberBox Width="40"
                                    Number="{Binding Integer1}"
                                    NumberType="Int"
                                    UpDownBehavior="ArrowsAndButtons" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <Border Width="50"
                        Height="10"
                        Background="Gray"
                        Visibility="{Binding Integer1, Converter={StaticResource SingleIntegerComparisonToVisibilityConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiIntegerComparisonToVisibilityConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:IntegerComparisonToVisibilityConverter x:Key="MultiIntegerComparisonToVisibilityConverter"
                                                               ComparisonType="BiggerThan"
                                                               Variable="5" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="IntegerComparisonToVisibilityConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <controls:NumberBox Width="40"
                                        Number="{Binding Integer1}"
                                        NumberType="Int"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Integer2}"
                                        NumberType="Int"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Integer3}"
                                        NumberType="Int"
                                        UpDownBehavior="ArrowsAndButtons" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <Border VerticalAlignment="Center"
                        BorderBrush="Gray"
                        BorderThickness="1">
                    <Border Width="50"
                            Height="10"
                            Background="Gray">
                        <Border.Visibility>
                            <MultiBinding Converter="{StaticResource MultiIntegerComparisonToVisibilityConverter}">
                                <Binding Path="Integer1" />
                                <Binding Path="Integer2" />
                                <Binding Path="Integer3" />
                            </MultiBinding>
                        </Border.Visibility>
                    </Border>
                </Border>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

21. **IntegerMathConverter**
    - Does a simple calculation with the given value as integer.
    ```xaml
    <Border DataContext="{Binding IntegerMathConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:IntegerMathConverter x:Key="IntegerMathConverter"
                                             Calculation="Addition"
                                             Variable="2" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="IntegerMathConverter" />
            <StackPanel Orientation="Horizontal">
                <controls:NumberBox Width="40"
                                    Number="{Binding Double1}"
                                    NumberType="Double"
                                    UpDownBehavior="ArrowsAndButtons" />
                <TextBlock Margin="10,0" Text="&lt;-&gt;" />
                <controls:NumberBox Width="40"
                                    Number="{Binding Double1, Converter={StaticResource IntegerMathConverter}}"
                                    NumberType="Double"
                                    UpDownBehavior="ArrowsAndButtons" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```

22. **IntegerToBooleanConverter**
    - Converts a single integer or a list of integers to a boolean representation.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleIntegerToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:IntegerToBooleanConverter x:Key="SingleIntegerToBooleanConverter" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="IntegerToBooleanConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <controls:NumberBox Width="40"
                                    Number="{Binding Integer1}"
                                    NumberType="int"
                                    UpDownBehavior="ArrowsAndButtons" />
                <TextBlock Margin="10,0" Text="&lt;-&gt;" />
                <CheckBox VerticalAlignment="Center"
                          Content="Check Me"
                          IsChecked="{Binding Integer1, Converter={StaticResource SingleIntegerToBooleanConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiIntegerToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:IntegerToBooleanConverter x:Key="MultiIntegerToBooleanConverter" MixedIs="{x:Null}" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="IntegerToBooleanConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <controls:NumberBox Width="40"
                                        Number="{Binding Integer1}"
                                        NumberType="int"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Integer2}"
                                        NumberType="int"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Integer3}"
                                        NumberType="int"
                                        UpDownBehavior="ArrowsAndButtons" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <CheckBox VerticalAlignment="Center"
                          Content="See Me"
                          IsEnabled="False">
                    <CheckBox.IsChecked>
                        <MultiBinding Converter="{StaticResource MultiIntegerToBooleanConverter}">
                            <Binding Path="Integer1" />
                            <Binding Path="Integer2" />
                            <Binding Path="Integer3" />
                        </MultiBinding>
                    </CheckBox.IsChecked>
                </CheckBox>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

23. **IntegerToStringConverter**
    - Formats an integer to string.
    ```xaml
    <Border DataContext="{Binding IntegerToStringConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:IntegerToStringConverter x:Key="IntegerToStringConverter" Digits="3" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="IntegerToStringConverter" />
            <StackPanel Orientation="Horizontal">
                <controls:NumberBox Width="40"
                                    Number="{Binding Integer1}"
                                    NumberType="Int"
                                    UpDownBehavior="ArrowsAndButtons" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <ContentControl Content="{Binding Integer1, Converter={StaticResource IntegerToStringConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```

24. **IsLastItemInListConverter**
    - Checks if the given item container is the last in the list.
    ```xaml
    <Border DataContext="{Binding IsLastItemInListConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:IsLastItemInListConverter x:Key="IsLastItemInListConverter" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="IsLastItemInListConverter" />
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
                                            <Setter Property="Background" Value="Gray" />
                                            <Setter Property="Foreground" Value="White" />
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
        </StackPanel>
    </Border>
    ```

25. **IsNullToBooleanConverter**
    - Checks if a single object or a list of objects is null and returns a boolean representation.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleIsNullToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:IsNullToBooleanConverter x:Key="SingleIsNullToBooleanConverter" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="IsNullToBooleanConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <CheckBox Content="Check Me"
                          IsChecked="{Binding IsChecked1}"
                          IsThreeState="True" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <CheckBox Content="See Me"
                          IsChecked="{Binding IsChecked1, Converter={StaticResource SingleIsNullToBooleanConverter}}"
                          IsEnabled="False" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiIsNullToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:IsNullToBooleanConverter x:Key="MultiIsNullToBooleanConverter" MixedIs="{x:Null}" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="IsNullToBooleanConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <CheckBox Content="Check Me"
                              IsChecked="{Binding IsChecked1}"
                              IsThreeState="True" />
                    <CheckBox Content="Check Me"
                              IsChecked="{Binding IsChecked2}"
                              IsThreeState="True" />
                    <CheckBox Content="Check Me"
                              IsChecked="{Binding IsChecked3}"
                              IsThreeState="True" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <CheckBox VerticalAlignment="Center"
                          Content="See Me"
                          IsEnabled="False">
                    <CheckBox.IsChecked>
                        <MultiBinding Converter="{StaticResource MultiIsNullToBooleanConverter}">
                            <Binding Path="IsChecked1" />
                            <Binding Path="IsChecked2" />
                            <Binding Path="IsChecked3" />
                        </MultiBinding>
                    </CheckBox.IsChecked>
                </CheckBox>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

26. **IsNullToVisibilityConverter**
    - Checks if a single object or a list of objects is null and returns a Visibility representation.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleIsNullToVisibilityConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:IsNullToVisibilityConverter x:Key="SingleIsNullToVisibilityConverter" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="IsNullToVisibilityConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <CheckBox Content="Check Me"
                          IsChecked="{Binding IsChecked1}"
                          IsThreeState="True" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <Border Width="50"
                        Height="10"
                        Background="Gray"
                        Visibility="{Binding IsChecked1, Converter={StaticResource SingleIsNullToVisibilityConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiIsNullToVisibilityConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:IsNullToVisibilityConverter x:Key="MultiIsNullToVisibilityConverter" MixedIs="{x:Null}" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="IsNullToVisibilityConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <CheckBox Content="Check Me"
                              IsChecked="{Binding IsChecked1}"
                              IsThreeState="True" />
                    <CheckBox Content="Check Me"
                              IsChecked="{Binding IsChecked2}"
                              IsThreeState="True" />
                    <CheckBox Content="Check Me"
                              IsChecked="{Binding IsChecked3}"
                              IsThreeState="True" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <Border VerticalAlignment="Center"
                        BorderBrush="Gray"
                        BorderThickness="1">
                    <Border Width="50"
                            Height="10"
                            Background="Gray">
                        <Border.Visibility>
                            <MultiBinding Converter="{StaticResource MultiIsNullToVisibilityConverter}">
                                <Binding Path="IsChecked1" />
                                <Binding Path="IsChecked2" />
                                <Binding Path="IsChecked3" />
                            </MultiBinding>
                        </Border.Visibility>
                    </Border>
                </Border>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

27. **NumberCheckToBooleanConverter**
    - Executes a check on a single number or list of numbers and returns a boolean representation of that result.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleNumberCheckToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:NumberCheckToBooleanConverter x:Key="SingleNumberCheckToBooleanConverter" CheckType="IsEven" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="NumberCheckToBooleanConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <controls:NumberBox Width="40"
                                    Number="{Binding Double1}"
                                    NumberType="Double"
                                    UpDownBehavior="ArrowsAndButtons" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <CheckBox Content="See Me"
                          IsChecked="{Binding Double1, Converter={StaticResource SingleNumberCheckToBooleanConverter}}"
                          IsEnabled="False" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiNumberCheckToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:NumberCheckToBooleanConverter x:Key="MultiNumberCheckToBooleanConverter" CheckType="IsEven" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="NumberCheckToBooleanConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double1}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double2}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double3}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <CheckBox VerticalAlignment="Center"
                          Content="See Me"
                          IsEnabled="False">
                    <CheckBox.IsChecked>
                        <MultiBinding Converter="{StaticResource MultiNumberCheckToBooleanConverter}">
                            <Binding Path="Double1" />
                            <Binding Path="Double2" />
                            <Binding Path="Double3" />
                        </MultiBinding>
                    </CheckBox.IsChecked>
                </CheckBox>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

28. **NumberCheckToVisibilityConverter**
    - Executes a check on a single number or list of numbers and returns a Visibility representation of that result.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleNumberCheckToVisibilityConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:NumberCheckToVisibilityConverter x:Key="SingleNumberCheckToVisibilityConverter" CheckType="IsEven" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="NumberCheckToVisibilityConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <controls:NumberBox Width="40"
                                    Number="{Binding Double1}"
                                    NumberType="Double"
                                    UpDownBehavior="ArrowsAndButtons" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <Border Width="50"
                        Height="10"
                        Background="Gray"
                        Visibility="{Binding Double1, Converter={StaticResource SingleNumberCheckToVisibilityConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiNumberCheckToVisibilityConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:NumberCheckToVisibilityConverter x:Key="MultiNumberCheckToVisibilityConverter" CheckType="IsEven" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="NumberCheckToVisibilityConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double1}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double2}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                    <controls:NumberBox Width="40"
                                        Number="{Binding Double3}"
                                        NumberType="Double"
                                        UpDownBehavior="ArrowsAndButtons" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <Border VerticalAlignment="Center"
                        BorderBrush="Gray"
                        BorderThickness="1">
                    <Border Width="50"
                            Height="10"
                            Background="Gray">
                        <Border.Visibility>
                            <MultiBinding Converter="{StaticResource MultiNumberCheckToVisibilityConverter}">
                                <Binding Path="Double1" />
                                <Binding Path="Double2" />
                                <Binding Path="Double3" />
                            </MultiBinding>
                        </Border.Visibility>
                    </Border>
                </Border>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

29. **ObjectToTypeConverter**
    - Returns the type of the given object.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding ObjectToTypeConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:ObjectToTypeConverter x:Key="ObjectToTypeConverter" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="ObjectToTypeConverter" />
            <StackPanel Orientation="Horizontal">
                <CheckBox Content="Check Me"
                          IsChecked="{Binding IsChecked1}"
                          IsThreeState="True" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <TextBlock Text="{Binding IsChecked1, Converter={StaticResource ObjectToTypeConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```

30. **PathToStringConverter**
    - Reads out part of a given path.
    ```xaml
    <Border DataContext="{Binding PathToStringConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:PathToStringConverter x:Key="PathToStringConverter" Section="Directory" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="PathToStringConverter" />
            <StackPanel Orientation="Horizontal">
                <TextBox Width="150" Text="{Binding String1, UpdateSourceTrigger=PropertyChanged}" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <TextBlock Text="{Binding String1, Converter={StaticResource PathToStringConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```

31. **RoundingConverter**
    - Rounds the given value as double.
    ```xaml
    <Border DataContext="{Binding RoundingConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:RoundingConverter x:Key="RoundingConverter"
                                          DecimalPlaces="2"
                                          Mode="RoundWithDecimals" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="RoundingConverter" />
            <StackPanel Orientation="Horizontal">
                <controls:NumberBox Width="80"
                                    Number="{Binding Double1}"
                                    NumberType="Double"
                                    Step="0,001"
                                    UpDownBehavior="ArrowsAndButtons" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <TextBlock Text="{Binding Double1, Converter={StaticResource RoundingConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```

32. **StringCheckToBooleanConverter**
    - Executes a check on a single string or list of strings and returns a boolean representation of that result.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleStringCheckToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:StringCheckToBooleanConverter x:Key="SingleStringCheckToBooleanConverter" CheckType="IsWhitespace" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="StringCheckToBooleanConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <TextBox Width="80" Text="{Binding String1, UpdateSourceTrigger=PropertyChanged}" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <CheckBox Content="See Me"
                          IsChecked="{Binding String1, Converter={StaticResource SingleStringCheckToBooleanConverter}}"
                          IsEnabled="False" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiStringCheckToBooleanConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:StringCheckToBooleanConverter x:Key="MultiStringCheckToBooleanConverter"
                                                      CheckType="IsWhitespace"
                                                      MixedIs="{x:Null}" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="StringCheckToBooleanConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <TextBox Width="80" Text="{Binding String1, UpdateSourceTrigger=PropertyChanged}" />
                    <TextBox Width="80" Text="{Binding String2, UpdateSourceTrigger=PropertyChanged}" />
                    <TextBox Width="80" Text="{Binding String3, UpdateSourceTrigger=PropertyChanged}" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <CheckBox VerticalAlignment="Center"
                          Content="See Me"
                          IsEnabled="False">
                    <CheckBox.IsChecked>
                        <MultiBinding Converter="{StaticResource MultiStringCheckToBooleanConverter}">
                            <Binding Path="String1" />
                            <Binding Path="String2" />
                            <Binding Path="String3" />
                        </MultiBinding>
                    </CheckBox.IsChecked>
                </CheckBox>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

33. **StringCheckToVisibilityConverter**
    - Executes a check on a single string or list of strings and returns a Visibility representation of that result.
    ```xaml
    <!-- Single -->
    <Border DataContext="{Binding SingleStringCheckToVisibilityConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:StringCheckToVisibilityConverter x:Key="SingleStringCheckToVisibilityConverter" CheckType="IsWhitespace" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="StringCheckToVisibilityConverter (Single)" />
            <StackPanel Orientation="Horizontal">
                <TextBox Width="80" Text="{Binding String1, UpdateSourceTrigger=PropertyChanged}" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <Border Width="50"
                        Height="10"
                        VerticalAlignment="Center"
                        Background="Gray"
                        Visibility="{Binding String1, Converter={StaticResource SingleStringCheckToVisibilityConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```
    ```xaml
    <!-- Multi -->
    <Border DataContext="{Binding MultiStringCheckToVisibilityConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:StringCheckToVisibilityConverter x:Key="MultiStringCheckToVisibilityConverter"
                                                         CheckType="IsWhitespace"
                                                         MixedIs="Hidden" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="StringCheckToVisibilityConverter (Multi)" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <TextBox Width="80" Text="{Binding String1, UpdateSourceTrigger=PropertyChanged}" />
                    <TextBox Width="80" Text="{Binding String2, UpdateSourceTrigger=PropertyChanged}" />
                    <TextBox Width="80" Text="{Binding String3, UpdateSourceTrigger=PropertyChanged}" />
                </StackPanel>
                <TextBlock Margin="10,0"
                           VerticalAlignment="Center"
                           Text="-&gt;" />
                <Border VerticalAlignment="Center"
                        BorderBrush="Gray"
                        BorderThickness="1">
                    <Border Width="50"
                            Height="10"
                            Background="Gray">
                        <Border.Visibility>
                            <MultiBinding Converter="{StaticResource MultiStringCheckToVisibilityConverter}">
                                <Binding Path="String1" />
                                <Binding Path="String2" />
                                <Binding Path="String3" />
                            </MultiBinding>
                        </Border.Visibility>
                    </Border>
                </Border>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

34. **StringToLowerConverter**
    - Converts the given value as string to lower.
    ```xaml
    <Border DataContext="{Binding StringToLowerConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:StringToLowerConverter x:Key="StringToLowerConverter" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="StringToLowerConverter" />
            <StackPanel Orientation="Horizontal">
                <TextBox Width="120" Text="{Binding String1, UpdateSourceTrigger=PropertyChanged}" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <TextBlock Text="{Binding String1, Converter={StaticResource StringToLowerConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```

35. **StringToUpperConverter**
    - Converts the given value as string to upper.
    ```xaml
    <Border DataContext="{Binding StringToUpperConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:StringToUpperConverter x:Key="StringToUpperConverter" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="StringToUpperConverter" />
            <StackPanel Orientation="Horizontal">
                <TextBox Width="120" Text="{Binding String1, UpdateSourceTrigger=PropertyChanged}" />
                <TextBlock Margin="10,0" Text="-&gt;" />
                <TextBlock Text="{Binding String1, Converter={StaticResource StringToUpperConverter}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```

36. **TimeOnlyToStringConverter**
    - Formats a single TimeOnly to a string.
    ```xaml
    <Border DataContext="{Binding TimeOnlyToStringConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:TimeOnlyToStringConverter x:Key="TimeOnlyToStringConverter1" Format="ToLongTimeString" />
            <converters:TimeOnlyToStringConverter x:Key="TimeOnlyToStringConverter2" Format="ToShortTimeString" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="TimeOnlyToStringConverter" />
            <StackPanel Orientation="Horizontal">
                <TextBlock Text="{Binding TimeOnly, Converter={StaticResource TimeOnlyToStringConverter1}}" />
                <TextBlock Margin="10,0" Text="|" />
                <TextBlock Text="{Binding TimeOnly, Converter={StaticResource TimeOnlyToStringConverter2}}" />
            </StackPanel>
        </StackPanel>
    </Border>
    ```

37. **ValueToPathConverter**
    - Combines all given strings into a path.
    ```xaml
    <Border DataContext="{Binding ValueToPathConverter}" Style="{StaticResource Frame}">
        <Border.Resources>
            <converters:ValueToPathConverter x:Key="ValueToPathConverter" />
        </Border.Resources>
        <StackPanel>
            <TextBlock Style="{StaticResource Caption}" Text="ValueToPathConverter" />
            <StackPanel Orientation="Horizontal">
                <StackPanel>
                    <TextBox Width="100" Text="{Binding String1, UpdateSourceTrigger=PropertyChanged}" />
                    <TextBox Width="100" Text="{Binding String2, UpdateSourceTrigger=PropertyChanged}" />
                    <TextBox Width="100" Text="{Binding String3, UpdateSourceTrigger=PropertyChanged}" />
                </StackPanel>
                <TextBlock Margin="10,0"
                            VerticalAlignment="Center"
                            Text="-&gt;" />
                <TextBlock VerticalAlignment="Center">
                    <TextBlock.Text>
                        <MultiBinding Converter="{StaticResource ValueToPathConverter}">
                            <Binding Path="String1" />
                            <Binding Path="String2" />
                            <Binding Path="String3" />
                        </MultiBinding>
                    </TextBlock.Text>
                </TextBlock>
            </StackPanel>
        </StackPanel>
    </Border>
    ```

## Links
* [NuGet](https://www.nuget.org/packages/Chapter.Net.WPF.Converters)
* [GitHub](https://github.com/dwndland/Chapter.Net.WPF.Converters)

## License
Copyright (c) David Wendland. All rights reserved.
Licensed under the MIT License. See LICENSE file in the project root for full license information.
