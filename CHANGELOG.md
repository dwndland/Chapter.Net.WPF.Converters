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
### Removed
- Removed InverseBooleanConverter, thats replaced by BooleanToBooleanConverter.
- Removed MultiBooleanToBooleanConverter, thats integrated into the BooleanToBooleanConverter.
- Removed BooleanToVisibilityInvertedConverter, thats repaced by BooleanToVisibilityConverter.
- Removed MultiBooleanToVisibilityConverter, thats integrated into the BooleanToVisibilityConverter.
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
