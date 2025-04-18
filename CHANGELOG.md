# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [3.1.0] - 2024-12-01
### Added
- Added .net 9 to the supported .net versions.
### Supported .Net Versions
- .Net 8 (Windows)
- .Net 9 (Windows)

## [3.0.0] - 2024-06-07
### Changed
- Update to support .Net 8 only.
### Supported .Net Versions
- .Net 8 (Windows)

## [2.3.0] - 2024-04-01
### Added
- Added more supported .net versions.
### Supported .Net Versions
- .Net Core 3.0
- .Net Framework 4.5
- .Net 5 (Windows)
- .Net 6 (Windows)
- .Net 7 (Windows)
- .Net 8 (Windows)

## [2.2.0] - 2024-03-21
### Added
- Added ValueConverterGroup to allow chaining of value converters with passing one result into the next converter.
- Added MultiValueConverterGroup to allow calling first a multi value converter and then chaining of value converters with passing one result into the next converter.
### Supported .Net Versions
- .Net 6
- .Net 7
- .Net 8

## [2.1.0] - 2024-02-14
### Changed
- Added NullIs option to the BooleanToBooleanConverter.
- Added NullIs option to the BooleanToVisibilityConverter.
### Supported .Net Versions
- .Net 6
- .Net 7
- .Net 8

## [2.0.0] - 2024-02-03
### Added
- Added base classes for value and  multi value converters and their combination for easy skipping of convert back.
- Added BooleanToBooleanConverter to convert a single boolean or a list of booleans to another single boolean representation.
- Added a multi boolean to integer conversion into the BooleanToIntegerConverter.
- Added BooleanToVisibilityConverter to convert a single boolean or a list of booleans into a Visibility representation.
- Added CharacterCheckToBooleanConverter to execute a check on a single character or list of characters and returns a boolean representation of that result.
- Added CharacterCheckToVisibilityConverter to execute a check on a single character or list of characters and returns a Visibility representation of that result.
- Added AcceptNullParts to the ConcatenateStringConverter to allow null part be part of the string.
- Added DoubleComparisonToBooleanConverter to execute a comparison on a single double or list of doubles to a boolean representation.
- Added DoubleComparisonToVisibilityConverter to execute a comparison on a single Visibility or list of Visibilities to a boolean representation.
- Added DoubleMathConverter to do a simple calculation with the given value as double.
- Added DoubleToStringConverter to format a double to string.
- Added multi conversion to the EqualsToBooleanConverter.
- Added IntegerComparisonToBooleanConverter to execute a comparison on a single integer or list of integers to a boolean representation.
- Added IntegerComparisonToVisibilityConverter to execute a comparison on a single integer or list of integers to a Visibility representation.
- Added IntegerMathConverter to do a simple calculation with the given value as integer.
- Added a multi integer to boolean conversion into the IntegerToBooleanConverter.
- Added IntegerToStringConverter to format a integer to string.
- Added IsNullToBooleanConverter to check if a single object or a list of objects is null and returns a boolean representation.
- Added IsNullToVisibilityConverter to check if a single object or a list of objects is null and returns a Visibility representation.
- Added NumberCheckToBooleanConverter to execute a check on a single number or list of numbers and returns a boolean representation of that result.
- Added ObjectToTypeConverter to return the type of the given object.
- Added RoundingConverter to round the given value as double.
- Added StringToLowerConverter to convert the given value as string to lower.
- Added StringToUpperConverter to convert the given value as string to upper.
- Added StringCheckToBooleanConverter to execute a check on a single string or list of strings and returns a boolean representation of that result.
- Added StringCheckToVisibilityConverter to execute a check on a single string or list of strings and returns a Visibility representation of that result.
- Added NumberCheckToVisibilityConverter to execute a check on a single number or list of numbers and returns a Visibility representation of that result.
### Changed
- Move the parameter for the EqualsToBooleanConverter to a converter property.
- Change the configurable return value for the EqualsToBooleanConverter from a single to multiple properties.
- Move the parameter for the EqualsToVisibilityConverter to a converter property.
- Change the configurable return value for the EqualsToVisibilityConverter from a single to multiple properties.
- Renamed DoubleValueToThicknessConverter to DoubleToThicknessConverter.
- Renamed MultiValueToPathConverter to ValueToPathConverter.
### Removed
- Removed InverseBooleanConverter, thats replaced by BooleanToBooleanConverter.
- Removed MultiBooleanToBooleanConverter, thats integrated into the BooleanToBooleanConverter.
- Removed BooleanToVisibilityInvertedConverter, thats repaced by BooleanToVisibilityConverter.
- Removed MultiBooleanToVisibilityConverter, thats integrated into the BooleanToVisibilityConverter.
- Removed MultiEqualsToBooleanConverter, thats integrated into the EqualsToBooleanConverter.
- Removed MultiEqualsToVisibilityConverter, thats integrated into the EqualsToVisibilityConverter.
- Remove NullToBooleanConverter, thats replaced by IsNullToBooleanConverter.
- Remove NullToVisibilityConverter, thats replaced by IsNullToVisibilityConverter.
- Remove CountToBooleanConverter, thats replaced by NumberCheckToBooleanConverter.
- Remove MultiValueToThicknessConverter, thats integrated into the DoubleToThicknessConverter.
- Remove CountToVisibilityConverter, thats replaced by NumberCheckToVisibilityConverter.
### Supported .Net Versions
- .Net 6
- .Net 7
- .Net 8

## [1.1.0] - 2024-01-17
### Added
- Added ConcatenateStringConverter to concatenage a bunch of given items to a single string.
- Added MultiBooleanToBooleanConverter to merge multiple booleans to a single one.
- Added MultiBooleanToVisibilityConverter to convert multiple booleans to a single visibility.
### Supported .Net Versions
- .Net 6
- .Net 7
- .Net 8

## [1.0.0] - 2023-12-24
### Added
- Init project
### Supported .Net Versions
- .Net 6
- .Net 7
- .Net 8
