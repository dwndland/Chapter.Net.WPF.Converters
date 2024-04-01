// -----------------------------------------------------------------------------------------------------------------
// <copyright file="StringCheckToBooleanConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

#pragma warning disable CA2208
// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters
{
    /// <summary>
    ///     Executes a check on a single string or list of strings and returns a boolean representation of that result.
    /// </summary>
    [ValueConversion(typeof(string), typeof(bool?))]
    [ValueConversion(typeof(string[]), typeof(bool?))]
    public class StringCheckToBooleanConverter : SingleAndMultiValueConverter
    {
        /// <summary>
        ///     Defines what check shall be executed.
        /// </summary>
        /// <value>Default: StringCheckType.IsNullOrWhitespace.</value>
        [DefaultValue(StringCheckType.IsNullOrWhitespace)]
        public StringCheckType CheckType { get; set; } = StringCheckType.IsNullOrWhitespace;

        /// <summary>
        ///     The return if the check is true.
        /// </summary>
        /// <value>Default: true.</value>
        [DefaultValue(true)]
        public bool? TrueIs { get; set; } = true;

        /// <summary>
        ///     Defines the result to use if the check is false.
        /// </summary>
        /// <value>Default: false.</value>
        [DefaultValue(false)]
        public bool? FalseIs { get; set; } = false;

        /// <summary>
        ///     The return if the check is false.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public bool? MixedIs { get; set; } = null;

        /// <summary>
        ///     The return if the checks are mixed.
        /// </summary>
        /// <value>Default: 30.</value>
        [DefaultValue(30)]
        public int Variable { get; set; } = 30;

        /// <summary>
        ///     Executes a check on a single string and returns a boolean representation of that result.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">Unused.</param>
        /// <param name="parameter">Unused.</param>
        /// <param name="culture">Unused.</param>
        /// <returns>The converted value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">StringCheckType got extended but not covered.</exception>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = value?.ToString();
            return Check(text);
        }

        /// <summary>
        ///     Executes a check on a list of strings and returns a boolean representation of that result.
        /// </summary>
        /// <param name="values">The values to convert.</param>
        /// <param name="targetType">Unused.</param>
        /// <param name="parameter">Unused.</param>
        /// <param name="culture">Unused.</param>
        /// <returns>The converted value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">StringCheckType got extended but not covered.</exception>
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                return FalseIs;

            var strings = values.Select(x => Check(x?.ToString())).Distinct().ToList();
            if (strings.Count == 0)
                return FalseIs;
            if (strings.Count > 1)
                return MixedIs;
            return strings[0];
        }

        private bool? Check(string text)
        {
            switch (CheckType)
            {
                case StringCheckType.IsNullOrWhitespace:
                    return string.IsNullOrWhiteSpace(text) ? TrueIs : FalseIs;
                case StringCheckType.IsNullOrEmpty:
                    return string.IsNullOrEmpty(text) ? TrueIs : FalseIs;
                case StringCheckType.IsNull:
                    return text == null ? TrueIs : FalseIs;
                case StringCheckType.IsEmpty:
                    return text != null && string.IsNullOrEmpty(text) ? TrueIs : FalseIs;
                case StringCheckType.IsWhitespace:
                    return !string.IsNullOrEmpty(text) && string.IsNullOrWhiteSpace(text) ? TrueIs : FalseIs;
                case StringCheckType.IsUpper:
                    return string.Equals(text, text.ToUpper()) ? TrueIs : FalseIs;
                case StringCheckType.IsLower:
                    return string.Equals(text, text.ToLower()) ? TrueIs : FalseIs;
                case StringCheckType.IsShorterThan:
                    return text.Length < Variable ? TrueIs : FalseIs;
                case StringCheckType.IsShorterThanOrEqualTo:
                    return text.Length <= Variable ? TrueIs : FalseIs;
                case StringCheckType.IsLongerThan:
                    return text.Length > Variable ? TrueIs : FalseIs;
                case StringCheckType.IsLongerThanOrEqualTo:
                    return text.Length >= Variable ? TrueIs : FalseIs;
                case StringCheckType.IsExactLength:
                    return text.Length == Variable ? TrueIs : FalseIs;
                default:
                    throw new ArgumentOutOfRangeException(nameof(CheckType), CheckType, "StringCheckType got extended but not covered.");
            }
        }
    }
}