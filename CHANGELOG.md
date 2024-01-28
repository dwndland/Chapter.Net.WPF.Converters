# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]
### Added
- Added base classes for value and  multi value converters and their combination for easy skipping of convert back.
- Added BooleanToBooleanConverter to convert a single boolean or a list of booleans to another single boolean representation.
- Added a multi boolean to integer conversion into the BooleanToIntegerConverter.
- Added BooleanToVisibilityConverter to convert a single boolean or a list of booleans into a Visibility representation.
- Added CharacterCheckToBooleanConverter to execute a check on a single character or list of characters and returns a boolean representation of that result.
- Added CharacterCheckToVisibilityConverter to execute a check on a single character or list of characters and returns a Visibility representation of that result.
- Added AcceptNullParts to the ConcatenateStringConverter to allow null part be part of the string.
- Added DelegateConverter that provides a delegate to convert a single value or a list of values.
- Added DelegateToBooleanConverter that provides a delegate to convert a single value or a list of values to boolean.
- Added DelegateToVisibilityConverter that provides a delegate to convert a single value or a list of values to Visibility.
- Added DoubleComparisonToBooleanConverter to execute a comparison on a single double or list of doubles to a boolean representation.
- Added DoubleComparisonToVisibilityConverter to execute a comparison on a single Visibility or list of Visibilities to a boolean representation.
- Added DoubleMathConverter to do a simple calculation with the given value as double.
- Added DoubleToStringConverter to format a double to string.
- Added multi conversion to the EqualsToBooleanConverter.
- Added IntegerComparisonToBooleanConverter to execute a comparison on a single integer or list of integers to a boolean representation.
- Added IntegerComparisonToVisibilityConverter to execute a comparison on a single integer or list of integers to a Visibility representation.
- Added IntegerMathConverter to do a simple calculation with the given value as integer.
- Added a multi integer to boolean conversion into the IntegerToBooleanConverter.
### Changed
- Move the parameter for the EqualsToBooleanConverter to a converter property.
- Change the configurable return value for the EqualsToBooleanConverter from a single to multiple properties.
- Move the parameter for the EqualsToVisibilityConverter to a converter property.
- Change the configurable return value for the EqualsToVisibilityConverter from a single to multiple properties.
### Removed
- Removed InverseBooleanConverter, thats replaced by BooleanToBooleanConverter.
- Removed MultiBooleanToBooleanConverter, thats integrated into the BooleanToBooleanConverter.
- Removed BooleanToVisibilityInvertedConverter, thats repaced by BooleanToVisibilityConverter.
- Removed MultiBooleanToVisibilityConverter, thats integrated into the BooleanToVisibilityConverter.
- Removed MultiEqualsToBooleanConverter, thats integrated into the EqualsToBooleanConverter.
- Removed MultiEqualsToVisibilityConverter, thats integrated into the EqualsToVisibilityConverter.
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
