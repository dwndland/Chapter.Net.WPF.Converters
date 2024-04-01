// -----------------------------------------------------------------------------------------------------------------
// <copyright file="IsNullToBooleanConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Converters
{
    /// <summary>
    ///     Checks if a single object or a list of objects is null and returns a boolean representation.
    /// </summary>
    [ValueConversion(typeof(object), typeof(bool))]
    [ValueConversion(typeof(object[]), typeof(bool))]
    public class IsNullToBooleanConverter : SingleAndMultiValueConverter
    {
        /// <summary>
        ///     The return if the given value is null.
        /// </summary>
        /// <value>Default: true.</value>
        [DefaultValue(true)]
        public bool? NullIs { get; set; } = true;

        /// <summary>
        ///     The return if the given value is not null.
        /// </summary>
        /// <value>Default: false.</value>
        [DefaultValue(false)]
        public bool? NotNullIs { get; set; } = false;

        /// <summary>
        ///     The return if the values are partially null and partial not null.
        /// </summary>
        /// <value>Default: false.</value>
        [DefaultValue(false)]
        public bool? MixedIs { get; set; } = false;

        /// <summary>
        ///     Checks if a single object is null and returns a boolean representation.
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
        ///     Checks if a list of objects is null and returns a boolean representation.
        /// </summary>
        /// <param name="values">The values to convert.</param>
        /// <param name="targetType">Unused.</param>
        /// <param name="parameter">Unused.</param>
        /// <param name="culture">Unused.</param>
        /// <returns>The converted value.</returns>
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                return NotNullIs;

            var booleans = values.Select(x => x == null).Distinct().ToList();

            switch (booleans.Count)
            {
                case 0:
                    return NotNullIs;
                case 1:
                    return booleans[0] ? NullIs : NotNullIs;
                default:
                    return MixedIs;
            }
        }
    }
}