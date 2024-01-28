// -----------------------------------------------------------------------------------------------------------------
// <copyright file="CharacterCheckToVisibilityConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

#pragma warning disable CA2208
// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters;

/// <summary>
///     Executes a check on a single character or list of characters and returns a Visibility representation of that
///     result.
/// </summary>
[ValueConversion(typeof(char), typeof(Visibility))]
[ValueConversion(typeof(char[]), typeof(Visibility))]
public class CharacterCheckToVisibilityConverter : SingleAndMultiValueConverter
{
    /// <summary>
    ///     The check to execute on the values.
    /// </summary>
    /// <value>Default: CharacterCheckType.IsDigit.</value>
    [DefaultValue(CharacterCheckType.IsDigit)]
    public CharacterCheckType CheckType { get; set; } = CharacterCheckType.IsDigit;

    /// <summary>
    ///     The return value if the check result is true.
    /// </summary>
    /// <value>Default: Visibility.Visible.</value>
    [DefaultValue(Visibility.Visible)]
    public Visibility TrueIs { get; set; } = Visibility.Visible;

    /// <summary>
    ///     The return value if the check result is false.
    /// </summary>
    /// <value>Default: Visibility.Collapsed.</value>
    [DefaultValue(Visibility.Collapsed)]
    public Visibility FalseIs { get; set; } = Visibility.Collapsed;

    /// <summary>
    ///     The return value if the check results are mixed.
    /// </summary>
    /// <value>Default: Visibility.Hidden.</value>
    [DefaultValue(Visibility.Hidden)]
    public Visibility MixedIs { get; set; } = Visibility.Hidden;

    /// <summary>
    ///     Executes a check on a single character and returns a Visibility representation of that result.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">CharacterCheckType got extended but not covered.</exception>
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is char character ? Check(character) : FalseIs;
    }

    /// <summary>
    ///     Executes a check on a list of characters and returns a Visibility representation of that result.
    /// </summary>
    /// <param name="values">The values to convert.</param>
    /// <param name="targetType">Unused.</param>
    /// <param name="parameter">Unused.</param>
    /// <param name="culture">Unused.</param>
    /// <returns>The converted value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">CharacterCheckType got extended but not covered.</exception>
    public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null)
            return FalseIs;

        var characters = values.OfType<char>().Select(Check).Distinct().ToList();
        return characters.Count switch
        {
            0 => FalseIs,
            > 1 => MixedIs,
            _ => characters[0]
        };
    }

    private Visibility Check(char character)
    {
        return CheckType switch
        {
            CharacterCheckType.IsDigit => char.IsDigit(character) ? TrueIs : FalseIs,
            CharacterCheckType.IsLetter => char.IsLetter(character) ? TrueIs : FalseIs,
            CharacterCheckType.IsUpper => char.IsUpper(character) ? TrueIs : FalseIs,
            CharacterCheckType.IsLower => char.IsLower(character) ? TrueIs : FalseIs,
            CharacterCheckType.IsLetterOrDigit => char.IsLetterOrDigit(character) ? TrueIs : FalseIs,
            _ => throw new ArgumentOutOfRangeException(nameof(CheckType), CheckType, "CharacterCheckType got extended but not covered.")
        };
    }
}