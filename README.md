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
    ```

4. **BooleanToIntegerConverter**
    - Converts a single boolean or a list of booleans to an integer representation.
    ```xaml
    ```

5. **BooleanToVisibilityConverter**
    - Converts a single boolean or a list of booleans into a Visibility representation.
    ```xaml
    ```

6. **CharacterCheckToBooleanConverter**
    - Executes a check on a single character or list of characters and returns a boolean representation of that result.
    ```xaml
    ```

7. **CharacterCheckToVisibilityConverter**
    - Executes a check on a single character or list of characters and returns a Visibility representation of that result.
    ```xaml
    ```

8. **ConcatenateStringConverter**
    - Concatenates all given values to a single string with an optional configurable separator.
    ```xaml
    ```

9. **DateOnlyToStringConverter**
    - Formats a single DateOnly to a string.
    ```xaml
    ```

10. **DateTimeToStringConverter**
    - Formats a single DateTime to a string.
    ```xaml
    ```

11. **DateTimeUtcConverter**
    - Converts the given date time to universal or local time.
    ```xaml
    ```

12. **DelegateConverter**
    - Provides a delegate to convert a single value or a list of values.
    ```xaml
    ```

13. **DelegateToBooleanConverter**
    - Provides a delegate to convert a single value or a list of values to boolean.
    ```xaml
    ```

14. **DelegateToVisibilityConverter**
    - Provides a delegate to convert a single value or a list of values to Visibility.
    ```xaml
    ```

15. **DoubleComparisonToBooleanConverter**
    - Executes a comparison on a single double or list of doubles to a boolean representation.
    ```xaml
    ```

16. **DoubleComparisonToVisibilityConverter**
    - Executes a comparison on a single Visibility or list of Visibilities to a boolean representation.
    ```xaml
    ```

17. **DoubleMathConverter**
    - Does a simple calculation with the given value as double.
    ```xaml
    ```

18. **DoubleToStringConverter**
    - Formats a double to string.
    ```xaml
    ```

19. **DoubleToThicknessConverter**
    - Builds a Thickness object by a given single double value.
    ```xaml
    ```

20. **EqualsToBooleanConverter**
    - Compares a single value to a variable or a list of values to each other and returns its boolean representation.
    ```xaml
    ```

21. **EqualsToVisibilityConverter**
    - Compares a single value to a variable or a list of values to each other and returns its Visibility representation.
    ```xaml
    ```

22. **IntegerComparisonToBooleanConverter**
    - Executes a comparison on a single integer or list of integers to a boolean representation.
    ```xaml
    ```

23. **IntegerComparisonToVisibilityConverter**
    - Executes a comparison on a single integer or list of integers to a Visibility representation.
    ```xaml
    ```

24. **IntegerMathConverter**
    - Does a simple calculation with the given value as integer.
    ```xaml
    ```

25. **IntegerToBooleanConverter**
    - Converts a single integer or a list of integers to a boolean representation.
    ```xaml
    ```

26. **IntegerToStringConverter**
    - Formats an integer to string.
    ```xaml
    ```

27. **IsLastItemInListConverter**
    - Checks if the given item container is the last in the list.
    ```xaml
    ```

28. **IsNullToBooleanConverter**
    - Checks if a single object or a list of objects is null and returns a boolean representation.
    ```xaml
    ```

29. **IsNullToVisibilityConverter**
    - Checks if a single object or a list of objects is null and returns a Visibility representation.
    ```xaml

30. **NumberCheckToBooleanConverter**
    - Executes a check on a single number or list of numbers and returns a boolean representation of that result.
    ```xaml
    ```

31. **NumberCheckToVisibilityConverter**
    - Executes a check on a single number or list of numbers and returns a Visibility representation of that result.
    ```xaml
    ```

32. **ObjectToTypeConverter**
    - Returns the type of the given object.
    ```xaml
    ```

33. **PathToStringConverter**
    - Reads out part of a given path.
    ```xaml
    ```

34. **RoundingConverter**
    - Rounds the given value as double.
    ```xaml
    ```

35. **StringCheckToBooleanConverter**
    - Executes a check on a single string or list of strings and returns a boolean representation of that result.
    ```xaml
    ```

36. **StringCheckToVisibilityConverter**
    - Executes a check on a single string or list of strings and returns a Visibility representation of that result.
    ```xaml
    ```

37. **StringToLowerConverter**
    - Converts the given value as string to lower.
    ```xaml
    ```

38. **StringToUpperConverter**
    - Converts the given value as string to upper.
    ```xaml
    ```

39. **TimeOnlyToStringConverter**
    - Formats a single TimeOnly to a string.
    ```xaml
    ```

40. **ValueToPathConverter**
    - Combines all given strings into a path.
    ```xaml
    ```

## Links
* [NuGet](https://www.nuget.org/packages/Chapter.Net.WPF.Converters)
* [GitHub](https://github.com/dwndland/Chapter.Net.WPF.Converters)

## License
Copyright (c) David Wendland. All rights reserved.
Licensed under the MIT License. See LICENSE file in the project root for full license information.
