// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IsNullToVisibilityConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters
{
    /// <summary>
    ///     Checks if a single object or a list of objects is null and returns a Visibility representation.
    /// </summary>
    [ValueConversion(typeof(object), typeof(Visibility))]
    [ValueConversion(typeof(object[]), typeof(Visibility))]
    public class IsNullToVisibilityConverter : SingleAndMultiValueConverter
    {
        /// <summary>
        ///     The return if the given value is null.
        /// </summary>
        /// <value>Default: Visibility.Collapsed.</value>
        [DefaultValue(Visibility.Collapsed)]
        public Visibility NullIs { get; set; } = Visibility.Collapsed;

        /// <summary>
        ///     The return if the given value is not null.
        /// </summary>
        /// <value>Default: Visibility.Visible.</value>
        [DefaultValue(Visibility.Visible)]
        public Visibility NotNullIs { get; set; } = Visibility.Visible;

        /// <summary>
        ///     The return if the values are partially null and partial not null.
        /// </summary>
        /// <value>Default: Visibility.Collapsed.</value>
        [DefaultValue(Visibility.Collapsed)]
        public Visibility MixedIs { get; set; } = Visibility.Collapsed;

        /// <summary>
        ///     Checks if a single object is null and returns a Visibility representation.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">Unused.</param>
        /// <param name="parameter">Unused.</param>
        /// <param name="culture">Unused.</param>
        /// <returns>The converted value.</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? NullIs : NotNullIs;
        }

        /// <summary>
        ///     Checks if a list of objects is null and returns a Visibility representation.
        /// </summary>
        /// <param name="values">The values to convert.</param>
        /// <param name="targetType">Unused.</param>
        /// <param name="parameter">Unused.</param>
        /// <param name="culture">Unused.</param>
        /// <returns>The converted value.</returns>
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                return Visibility.Collapsed;

            var booleans = values.Select(x => x == null).Distinct().ToList();
            if (booleans.Count == 0)
                return Visibility.Collapsed;
            if (booleans.Count > 1)
                return MixedIs;
            return booleans[0] ? NullIs : NotNullIs;
        }
    }
}